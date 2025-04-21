using Microsoft.Extensions.DependencyInjection;
using TMom.Infrastructure;
using SapNwRfc.Pooling;

namespace TMom.Application.Ext
{
    public static class SapSetup
    {
        /// <summary>
        /// 注入Sap服务
        /// </summary>
        /// <param name="services"></param>
        public static void AddSapSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            bool isSapEnabled = Appsettings.app(["Erp", "Sap", "Enabled"]).ObjToBool();
            string sapConnString = Appsettings.app(["Erp", "Sap", "ConnectionString"]);

            if (isSapEnabled)
            {
                services.AddSingleton<ISapConnectionPool>(_ => new SapConnectionPool(sapConnString));
                services.AddScoped<ISapPooledConnection, SapPooledConnection>();

                var sapPooledConnection = services.BuildServiceProvider().GetRequiredService<ISapPooledConnection>();
                services.AddSingleton(new SapHelper(sapPooledConnection));
            }
        }
    }
}