using AdvancedTaskControl.API.Graph.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedTaskControl.API.Configuration
{
    public static class GraphQLConfig
    {
        public static IServiceCollection AddGraphQLConfig (this IServiceCollection services)
        {
            services.AddScoped<UserQuery>();
            services.AddScoped<UserMutation>();
            services.AddGraphQLServer()
                .AddType<UserTypes>()
                .AddQueryType<UserQuery>()
                .AddMutationType<UserMutation>();

            return services;
        }
    }
}
