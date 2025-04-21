using Microsoft.Extensions.DependencyInjection;
using TMom.Infrastructure;

namespace TMom.Application.Ext
{
    /// <summary>
    /// Cors 启动服务
    /// </summary>
    public static class CorsSetup
    {
        public static void AddCorsSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddCors(c =>
            {
                if (!Appsettings.app(["Startup", "Cors", "EnableAllIPs"]).ObjToBool())
                {
                    c.AddPolicy(Appsettings.app(["Startup", "Cors", "PolicyName"]),

                        policy =>
                        {
                            policy
                            .WithOrigins(Appsettings.app(["Startup", "Cors", "IPs"]).Split(','))
                            .AllowAnyHeader()//Ensures that the policy allows any header.
                            .AllowAnyMethod()
                            .AllowCredentials();
                        });
                }
                else
                {
                    //允许任意跨域请求
                    c.AddPolicy(Appsettings.app(["Startup", "Cors", "PolicyName"]),
                        policy =>
                        {
                            policy
                            .SetIsOriginAllowed((host) => true)
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                        });
                }
            });
        }
    }
}