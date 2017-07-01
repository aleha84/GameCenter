using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using GameCenter.BLL;
using GameCenter.BLL.Providers;
using GameCenter.DAL.DAO;
using GameCenter.DAL.DAO.Json;
using GameCenter.Infrastructure;
using GameCenter.Infrastructure.SignalR;
using GameCenter.Security.CustomIdentity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using GameCenter.BLL.Providers.Interfaces;
using GameCenter.BLL.Processers;

namespace GameCenter
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new SignalRContractResolver()
            };

            var serializer = JsonSerializer.Create(settings);
            services.Add(new ServiceDescriptor(typeof(JsonSerializer), provider => serializer, ServiceLifetime.Transient));

            services.AddSingleton(typeof(IBaseDAO<>), typeof(BaseJsonDAO<>));
            services.AddSingleton<IUserDAO, UserJsonDAO>();
            services.AddSingleton<IApplicationsDAO, ApplicationsJsonDAO>();
            services.AddSingleton<ISessionProvider<int>, InMemorySessionProvider<int>>();
            services.AddSingleton<IConnectionsProvider, InMemoryConnectionsProvider>();
            services.AddSingleton<IApplicationsProcesser, ApplicationsProcesser>();

            services.AddTransient<ISecurity, BLL.Security>();
            services.AddTransient<IApplicationsBLL, ApplicationsBLL>();

            services.AddSignalR(options => {
                options.Hubs.EnableDetailedErrors = true;
                options.Transports.DisconnectTimeout = System.TimeSpan.FromSeconds(10);
                options.Transports.KeepAlive = System.TimeSpan.FromSeconds(10 / 4);
                options.Hubs.PipelineModules.Add(new ExceptionPipelineModule(sp.GetService<ILogger<ExceptionPipelineModule>>()));
            });

            services.AddMvc();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("loggedInOnly", policy => 
                    policy.RequireAssertion(handler => 
                        !handler.User.HasClaim(match => 
                            match.Type == ClaimTypes.Anonymous)));
            });

            services.AddAutoMapper();
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseStaticFiles();

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<CustomIdentityMiddleWare>();

            app.UseMvc(Router.GetRouter);

            app.UseWebSockets();
            app.UseSignalR();
        }
    }
}
