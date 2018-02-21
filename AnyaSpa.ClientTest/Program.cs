using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using AnyaSpa.Dal;
using AnyaSpa.Dal.CommandHandlers;
using AnyaSpa.Dal.Commands;
using AnyaSpa.Dal.CreateQueries;
using AnyaSpa.Dal.Mappers;
using AnyaSpa.Infrastructure.Command;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace AnyaSpa.ClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var serviceProvider = BuildDi(configuration);

            serviceProvider.GetRequiredService<Runner>();

            Console.WriteLine("Press ANY key to exit");
            Console.ReadLine();
        }

        private static IServiceProvider BuildDi(IConfigurationRoot root)
        {
            var services = new ServiceCollection();

            services.AddTransient(r => root);
            services.AddTransient<Runner>();

            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddLogging((builder) => builder.SetMinimumLevel(LogLevel.Trace));

            services.AddTransient<IConfigConnection, ConfigConnection>();
            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            services.AddTransient<ICommandHandler<CreateStaffCommand>, CreateStaffHandler>();
            services.AddTransient<ICreateStaffQuery, CreateStaffQuery>();

            services.AddTransient<TestConnection>();
            services.AddAutoMapper();

            var serviceProvider = services.BuildServiceProvider();

            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

            loggerFactory.AddNLog(new NLogProviderOptions
            {
                CaptureMessageTemplates = true,
                CaptureMessageProperties = false
            });
            loggerFactory.ConfigureNLog("NLog.config");

            return serviceProvider;
        }
    }
}
