﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace GameCenter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseSetting("detailedErrors", "true") 
                .CaptureStartupErrors(true) 
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5000", "http://0.0.0.0:5000")
                .Build();

            host.Run();
        }
    }
}
