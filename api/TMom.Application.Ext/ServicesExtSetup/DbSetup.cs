using Microsoft.Extensions.DependencyInjection;
using TMom.Domain.Model;
using TMom.Domain.Model.Seed;

namespace TMom.Application.Ext
{
    /// <summary>
    /// Db 启动服务
    /// </summary>
    public static class DbSetup
    {
        public static void AddDbSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<DBSeed>();
            services.AddScoped<MyContext>();
        }
    }
}