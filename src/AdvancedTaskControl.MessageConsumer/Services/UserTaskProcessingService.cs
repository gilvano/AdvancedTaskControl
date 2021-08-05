using AdvancedTaskControl.Business.Models;
using AdvancedTaskControl.GRPCProto;
using AdvancedTaskControl.MessageConsumer.Services;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly ILogger _logger;
        private readonly IServiceProvider _sp;
        private IConnection _connection;
        private IModel _channel;

        public UserTaskProcessingService(ILogger<UserTaskProcessingService> logger, IServiceProvider sp)
        {
            _logger = logger;
            _sp = sp;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await ProcessUserTaskFromMessage();

                await Task.Delay(10000, stoppingToken);
                _logger.LogInformation("Aguardando 10 segundos");
            }
        }
        private Task ProcessUserTaskFromMessage()
        {
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
            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.Received += async (sender, @event) =>
            {
                try
                {
                    var contentArray = @event.Body.ToArray();
                    var contentString = Encoding.UTF8.GetString(contentArray);
                    var message = JsonConvert.DeserializeObject<UserTask>(contentString);
                    _logger.LogInformation(contentString);

                    await SendUserTasktoGRPCAsync(contentString);

                    _channel.BasicAck(@event.DeliveryTag, false);
                }
                catch (Exception e)
                {
                    _logger.LogInformation("Erro ao inserir tarefa! Detalhes:  " + e.Message);
                }
            };
            _channel.BasicConsume("usertasks-queue", autoAck: false, consumer: consumer);
            return Task.CompletedTask;
        }

        private async Task SendUserTasktoGRPCAsync(string message)
        {
            using (var scope = _sp.CreateScope())
            {
                var scopedSendUserTasktoGRPCService =
                    scope.ServiceProvider
                        .GetRequiredService<ISendUserTasktoGRPCService>();

                await scopedSendUserTasktoGRPCService.SendUserTasktoGRPCAsync(message);
            }
        }
    }
}
