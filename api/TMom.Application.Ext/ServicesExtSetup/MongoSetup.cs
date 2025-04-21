using Microsoft.Extensions.DependencyInjection;
using TMom.Infrastructure.MongoDB;

namespace TMom.Application.Ext
{
    public static class MongoSetup
    {
        /// <summary>
        /// MongoDB 启动服务
        /// </summary>
        /// <param name="services"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddMongoSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddTransient<IMongoRepo, MongoRepo>();
        }
    }
}