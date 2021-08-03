using AdvancedTaskControl.Business.Models;
using AdvancedTaskControl.GRPCProto;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdvancedTaskControl.Business.Services
{
    public interface IScopedProcessingService
    {
        Task DoWork(CancellationToken stoppingToken);
    }
    public class UserTaskProcessingService : IScopedProcessingService
    {
        private int executionCount = 0;
        private readonly ILogger _logger;
        private readonly IServiceProvider _sp;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public UserTaskProcessingService(ILogger<UserTaskProcessingService> logger)
        {
            _logger = logger;

            var factory = new ConnectionFactory
            {
                HostName = "rabbitmq",
                DispatchConsumersAsync = true
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(
                        queue: "usertasks-queue",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                executionCount++;

                _logger.LogInformation(
                    "Scoped Processing Service is working. Count: {Count}", executionCount);

                await ProcessUserTaskFromMessage();

                await Task.Delay(10000, stoppingToken);
            }
        }
        public async Task ProcessUserTaskFromMessage()
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.Received += Consumer_Received;

            _channel.BasicConsume("usertasks-queue", false, consumer);
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            await Task.Delay(3000);
            var contentArray = @event.Body.ToArray();
            var contentString = Encoding.UTF8.GetString(contentArray);
            var message = JsonConvert.DeserializeObject<UserTask>(contentString);
            _logger.LogInformation(contentString);
            try
            {
                await SendUserTasktoGRPCAsync(contentString);

                _channel.BasicAck(@event.DeliveryTag, false);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Erro ao inserir tarefa! Detalhes:  " + e.Message);
            }
        }

        public async Task SendUserTasktoGRPCAsync(string message)
        {
            try
            {
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

                var channel = GrpcChannel.ForAddress("http://AdvancedTaskControl.gRPCService",
                     channelOptions: new GrpcChannelOptions()
                     {
                         Credentials = ChannelCredentials.Insecure
                     });

                var client = new UserTaskGRPC.UserTaskGRPCClient(channel);

                var userTaskValue = new UserTaskValue { Message = message };

                var reply = await client.AddUserTaskAsync(userTaskValue);
                _logger.LogInformation("Resposta: ${0}", reply);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Erro grpc:  " + e.Message);
            }

        }
    }
}
