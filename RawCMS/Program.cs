﻿//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina'</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Diagnostics;

namespace RawCMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Debug.WriteLine("Starting MAIN");
                Run(args);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }

        private static void Run(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args)
                 .UseStartup<Startup>()
                 .ConfigureLogging(logging =>
                 {
                     logging.ClearProviders();
                     logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                 })
                 //                 .UseUrls("http://0.0.0.0:" + Environment.GetEnvironmentVariable("PORT"))
                 .UseNLog();
            if (Environment.GetEnvironmentVariable("ASPNETCORE_SERVER_URLS") != null)
            {
                builder = builder.UseUrls(Environment.GetEnvironmentVariable("ASPNETCORE_SERVER_URLS"));
            }
            builder
                 .Build()
                 .Run();
        }
    }
}