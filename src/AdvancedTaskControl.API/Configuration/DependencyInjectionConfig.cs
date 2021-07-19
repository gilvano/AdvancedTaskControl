using AdvancedTaskControl.Business.Interfaces;
using AdvancedTaskControl.Business.Services;
using AdvancedTaskControl.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedTaskControl.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserTaskRepository, UserTaskRepository>();
            services.AddScoped<IUserTaskService, UserTaskService>();
            return services;
        }
    }
}
