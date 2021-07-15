using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AdvancedTaskControl.Data.Context;
using AdvancedTaskControl.Data.Repository;
using Microsoft.OpenApi.Models;
using AdvancedTaskControl.Business.Interfaces;
using AdvancedTaskControl.Business.Services;
using FluentValidation.AspNetCore;
using AdvancedTaskControl.API.Models;
using FluentValidation;
using AdvancedTaskControl.Business.Models.Validations;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using AdvancedTaskControl.API.Graph.Users;
using HotChocolate;
using HotChocolate.AspNetCore.Playground;
using HotChocolate.AspNetCore;
using AdvancedTaskControl.API.Configuration;

namespace AdvancedTaskControl.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MeuDbContext>(options => {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddControllers();
            services.ResolveDependencies();

            services.AddFluentValidation();
            services.AddTransient<IValidator<User>, UserValidator>();
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerConfig();
            services.AddAuthenticationConfig(Configuration);
            services.AddGraphQLConfig();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MeuDbContext dataContext)
        {
            dataContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerConfig();

                app.UsePlayground(new PlaygroundOptions
                {
                    QueryPath = "/graph",
                    Path = "/playground"
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL();
                endpoints.MapGraphQL("/internal", schemaName: "internal");
            });
        }
    }
}
