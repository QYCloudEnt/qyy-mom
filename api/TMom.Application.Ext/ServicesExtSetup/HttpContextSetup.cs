using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TMom.Application.Service;
using TMom.Domain.Model;

namespace TMom.Application.Ext
{
    /// <summary>
    /// HttpContext 相关服务
    /// </summary>
    public static class HttpContextSetup
    {
        public static void AddHttpContextSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}