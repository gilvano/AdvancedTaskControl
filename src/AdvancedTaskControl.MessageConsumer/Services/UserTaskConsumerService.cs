using AdvancedTaskControl.Business.Interfaces;
using AdvancedTaskControl.Business.Models;
using AdvancedTaskControl.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdvancedTaskControl.Business.Services
{
    public class UserTaskConsumerService : BackgroundService
    {
        private readonly IServiceProvider _sp;               

        public UserTaskConsumerService(IServiceProvider sp)
        {
            _sp = sp;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Factory.StartNew(async () =>
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    try
                    {
                        await DoWork(stoppingToken);

                        await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
                    }
                    catch (OperationCanceledException) { }
                }
            }, stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            using (var scope = _sp.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<IScopedProcessingService>();

                await scopedProcessingService.DoWork(stoppingToken);
            }
        }
    }
}
