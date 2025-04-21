using Microsoft.Extensions.DependencyInjection;
using TMom.Infrastructure;
using StackExchange.Redis;

namespace TMom.Application.Ext
{
    /// <summary>
    /// Redis缓存 启动服务
    /// </summary>
    public static class RedisCacheSetup
    {
        public static void AddRedisCacheSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddTransient<IRedisRepository, RedisRepository>();

            services.AddSingleton<ConnectionMultiplexer>(sp =>
               {
                   string redisConfiguration = Appsettings.app(["Redis", "ConnectionString"]);

                   var configuration = ConfigurationOptions.Parse(redisConfiguration, true);
                   configuration.ResolveDns = true;
                   configuration.AbortOnConnectFail = false;
                   configuration.SyncTimeout = Appsettings.app(["Redis", "Timeout"]).ObjToInt();

                   return ConnectionMultiplexer.Connect(configuration);
               });
        }
    }
}