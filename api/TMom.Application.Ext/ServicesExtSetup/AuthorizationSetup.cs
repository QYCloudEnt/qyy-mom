using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TMom.Application.Service;
using TMom.Infrastructure;
using TMom.Infrastructure.DB;
using System.Security.Claims;
using System.Text;
using static TMom.Domain.Model.GlobalVars;

namespace TMom.Application.Ext
{
    /// <summary>
    /// 系统 授权服务 配置
    /// </summary>
    public static class AuthorizationSetup
    {
        public static void AddAuthorizationSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Client", policy => policy.RequireRole("Client").Build());
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                options.AddPolicy("SystemOrAdmin", policy => policy.RequireRole("Admin", "System"));
                options.AddPolicy("A_S_O", policy => policy.RequireRole("Admin", "System", "Others"));
            });

            #region 参数

            var symmetricKeyAsBase64 = AppSecretConfig.Audience_Secret_String;
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            var Issuer = Appsettings.app(new string[] { "Audience", "Issuer" });
            var Audience = Appsettings.app(new string[] { "Audience", "Audience" });
            var expiration = double.Parse(Appsettings.app(new string[] { "Audience", "expiration" }));

            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var permission = new List<PermissionItem>();

            var permissionRequirement = new PermissionRequirement(
                "/api/denied",
                permission,
                ClaimTypes.Role,
                Issuer,
                Audience,
                signingCredentials,
                expiration: TimeSpan.FromSeconds(expiration)
                );

            #endregion 参数

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Permissions.Name,
                         policy => policy.Requirements.Add(permissionRequirement));
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();
            services.AddSingleton(permissionRequirement);
        }
    }
}