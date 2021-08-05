using AdvancedTaskControl.GRPCProto;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskControl.MessageConsumer.Services
{
    public interface ISendUserTasktoGRPCService
    { 
        Task SendUserTasktoGRPCAsync(string message);
    }
    public class SendUserTasktoGRPCService : ISendUserTasktoGRPCService
    {
        private readonly ILogger _logger;

        public SendUserTasktoGRPCService(ILogger<SendUserTasktoGRPCService> logger)
        {
            _logger = logger;
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
