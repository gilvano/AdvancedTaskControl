using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Google.Protobuf.Reflection;
using Google.Protobuf.WellKnownTypes;
using System.Text.Json;
using AdvancedTaskControl.GRPCProto;
using AdvancedTaskControl.Business.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;
using AdvancedTaskControl.Business.Interfaces;

namespace AdvancedTaskControl.gRPCService
{
    public class UserTaskGRPCService : UserTaskGRPC.UserTaskGRPCBase
    {
        private readonly ILogger<UserTaskGRPCService> _logger;
        private readonly IUserTaskService _userTaskService;
        public UserTaskGRPCService(ILogger<UserTaskGRPCService> logger, IUserTaskService userTaskService)
        {
            _logger = logger;
            _userTaskService = userTaskService;
        }

        public override async Task <UserTaskReply> AddUserTask(UserTaskValue request, ServerCallContext context)
        {
            _logger.LogInformation("Mensagem recebida");
            _logger.LogInformation(request.Message.ToString());

            var jsonString = request.Message.ToString();
            UserTask userTask = JsonSerializer.Deserialize<UserTask>(@jsonString);

            try
            {
                await _userTaskService.Insert(userTask);

                return new UserTaskReply
                {
                    Message = "Ok"
                };
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return new UserTaskReply
                {
                    Message = $"Erro: {e.Message}"
                };
            }
        }
    }
}
