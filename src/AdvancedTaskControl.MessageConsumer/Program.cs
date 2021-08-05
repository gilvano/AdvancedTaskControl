using AdvancedTaskControl.GRPCProto;
using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Grpc.Core;
using Microsoft.Extensions.Hosting;
using AdvancedTaskControl.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using AdvancedTaskControl.MessageConsumer.Services;

namespace AdvancedTaskControl.MessageConsumer
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("teste");
        //    MainAsync().GetAwaiter().GetResult();
        //}

        public static void Main(string[] args)
        {
            //AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<UserTaskConsumerService>()
                            .AddLogging();
                    services.AddScoped<IScopedProcessingService, UserTaskProcessingService>();
                    services.AddScoped<ISendUserTasktoGRPCService, SendUserTasktoGRPCService>();

                });

        //public static async Task Main()
        //{
        //    try
        //    {
        //        AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

        //        var channel = GrpcChannel.ForAddress("http://AdvancedTaskControl.gRPCService:80",
        //             channelOptions: new GrpcChannelOptions()
        //             {
        //                 Credentials = ChannelCredentials.Insecure
        //             });

        //        var client = new UserTaskGRPC.UserTaskGRPCClient(channel);

        //        var userTaskValue = new UserTaskValue { Message = "teste 1" };

        //        //status.Data = Value.Parser.ParseJson(@);

        //        var resultado = await client.AddUserTaskAsync(userTaskValue);
        //        Console.WriteLine("Resposta: ${0}", resultado);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Erro grpc:  " + e.Message);
        //    }

        //var serviceProvider = new ServiceCollection()
        //.AddLogging()
        //.AddScoped<IScopedProcessingService, UserTaskProcessingService>()
        //.BuildServiceProvider();

        //configure console logging
        //serviceProvider
        //.GetService<ILoggerFactory>()
        //.AddConsole(LogLevel.Debug);

        //var logger = serviceProvider.GetService<ILoggerFactory>()
        ///    .CreateLogger<Program>();
        //logger.LogDebug("Starting application");

        //do the actual work here
        //var cancelationToke = new CancellationToken();
        ///var messageProcessor = serviceProvider.GetService<IScopedProcessingService>();

        //await messageProcessor.DoWork(cancelationToke);
        ///logger.LogDebug("All done!");

        //Console.WriteLine("teste");
        //}
    }
}

