using AdvancedTaskControl.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedTaskControl.Business.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace AdvancedTaskControl.Business.Services
{
    public class UserTaskSenderService : IUserTaskSenderService
    {
        private readonly ConnectionFactory _factory;
        public UserTaskSenderService()
        {
            _factory = new ConnectionFactory
            {
                HostName = "rabbitmq"
            };
        }

        public void SendMessage(UserTask userTask)
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: "usertasks-queue",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var stringfiedMessage = JsonConvert.SerializeObject(userTask);
                    var bytesMessage = Encoding.UTF8.GetBytes(stringfiedMessage);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: "usertasks-queue",
                        basicProperties: null,
                        body: bytesMessage);
                }
            }
        }
    }
}
