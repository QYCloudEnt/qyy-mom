using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TMom.Infrastructure;

namespace TMom.Application.Ext
{
    /// <summary>
    /// EventBus 事件总线服务
    /// </summary>
    public static class EventBusSetup
    {
        public static void AddEventBusSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            if (Appsettings.app(new string[] { "EventBus", "Enabled" }).ObjToBool())
            {
                var subscriptionClientName = Appsettings.app(new string[] { "EventBus", "SubscriptionClientName" });

                services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
                // 注入事件
                // services.AddTransient<TestSysUserEventHandler>();

                if (Appsettings.app(new string[] { "RabbitMQ", "Enabled" }).ObjToBool())
                {
                    services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
                    {
                        var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                        ILifetimeScope iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                        var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                        var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                        var retryCount = 5;
                        if (!string.IsNullOrEmpty(Appsettings.app(new string[] { "RabbitMQ", "RetryCount" })))
                        {
                            retryCount = int.Parse(Appsettings.app(new string[] { "RabbitMQ", "RetryCount" }));
                        }

                        return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
                    });
                }
                if (Appsettings.app(new string[] { "Kafka", "Enabled" }).ObjToBool())
                {
                    services.AddHostedService<KafkaConsumerHostService>();
                    services.AddSingleton<IEventBus, EventBusKafka>();
                }
            }
        }
    }
}