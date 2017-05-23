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
using GameCenter.Security.CustomIdentity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GameCenter
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(IBaseDAO<>), typeof(BaseJsonDAO<>));
            services.AddSingleton<IUserDAO, UserJsonDAO>();
            services.AddSingleton<IApplicationsDAO, ApplicationsJsonDAO>();
            services.AddSingleton<ISessionProvider<int>, InMemorySessionProvider<int>>();

            services.AddTransient<ISecurity, BLL.Security>();
            services.AddTransient<IApplicationsBLL, ApplicationsBLL>();


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
        }
    }
}
