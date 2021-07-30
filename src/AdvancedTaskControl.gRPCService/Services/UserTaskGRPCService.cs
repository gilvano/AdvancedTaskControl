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

namespace AdvancedTaskControl.gRPCService
{
    public class UserTaskGRPCService : UserTask.UserTaskBase
    {
        private readonly ILogger<UserTaskGRPCService> _logger;
        public UserTaskGRPCService(ILogger<UserTaskGRPCService> logger)
        {
            _logger = logger;
        }

        public override Task<UserTaskReply> AddUserTask(UserTaskValue request, ServerCallContext context)
        {
            //var status = new UserTaskValue();
            //status.Data = Value.Parser.ParseJson(@"{
            //    ""enabled"": true,
            //    ""metadata"": [ ""value1"", ""value2"" ]
            //}");

            // Convert dynamic values to JSON.
            // JSON can be read with a library like System.Text.Json or Newtonsoft.Json
            var json = JsonFormatter.Default.Format(request.Data);
            var document = JsonDocument.Parse(json);

            _logger.LogInformation(json);

            return Task.FromResult(new UserTaskReply
            {
                Message = "Ok"
            });
        }
    }
}
