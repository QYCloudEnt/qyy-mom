﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TMom.Infrastructure;
using RabbitMQ.Client;

namespace TMom.Application.Ext
{
    /// <summary>
    /// RabbitMQ 启动服务
    /// </summary>
    public static class RabbitMQSetup
    {
        public static void AddRabbitMQSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            if (Appsettings.app(new string[] { "RabbitMQ", "Enabled" }).ObjToBool())
            {
                services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
                   {
                       var logger = sp.GetRequiredService<ILogger<RabbitMQPersistentConnection>>();

                       var factory = new ConnectionFactory()
                       {
                           HostName = Appsettings.app(new string[] { "RabbitMQ", "Connection" }),
                           Port = Appsettings.app(new string[] { "RabbitMQ", "Port" }).ObjToInt(),
                           DispatchConsumersAsync = true
                       };

                       if (!string.IsNullOrEmpty(Appsettings.app(new string[] { "RabbitMQ", "UserName" })))
                       {
                           factory.UserName = Appsettings.app(new string[] { "RabbitMQ", "UserName" });
                       }

                       if (!string.IsNullOrEmpty(Appsettings.app(new string[] { "RabbitMQ", "Password" })))
                       {
                           factory.Password = Appsettings.app(new string[] { "RabbitMQ", "Password" });
                       }

                       var retryCount = 5;
                       if (!string.IsNullOrEmpty(Appsettings.app(new string[] { "RabbitMQ", "RetryCount" })))
                       {
                           retryCount = int.Parse(Appsettings.app(new string[] { "RabbitMQ", "RetryCount" }));
                       }

                       return new RabbitMQPersistentConnection(factory, logger, retryCount);
                   });
            }
        }
    }
}