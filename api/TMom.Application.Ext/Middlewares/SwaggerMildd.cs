using log4net;
using Microsoft.AspNetCore.Builder;
using TMom.Infrastructure;
using static TMom.Infrastructure.CustomApiVersion;
using static TMom.Domain.Model.GlobalVars;

namespace TMom.Application.Ext
{
    /// <summary>
    /// Swagger中间件
    /// </summary>
    public static class SwaggerMildd
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SwaggerMildd));

        public static void UseSwaggerMildd(this IApplicationBuilder app, Func<Stream> streamHtml = null)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //根据版本名称倒序 遍历展示
                var ApiName = Appsettings.app(new string[] { "Startup", "ApiName" });
                typeof(ApiVersions).GetEnumNames().OrderByDescending(e => e).ToList().ForEach(version =>
                {
                    c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{ApiName} {version}");
                });

                c.SwaggerEndpoint($"https://petstore.swagger.io/v2/swagger.json", $"{ApiName} pet");

                if (streamHtml != null)
                {
                    if (streamHtml.Invoke() == null)
                    {
                        var msg = "index.html的属性，必须设置为嵌入的资源";
                        log.Error(msg);
                        throw new Exception(msg);
                    }
                    c.IndexStream = streamHtml;
                }

                if (Permissions.IsUseIds4)
                {
                    c.OAuthClientId("momvue");
                }

                c.RoutePrefix = "";
                // 默认折叠
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });
        }
    }
}