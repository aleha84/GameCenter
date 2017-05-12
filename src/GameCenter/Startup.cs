using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            services.AddMvc();
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
