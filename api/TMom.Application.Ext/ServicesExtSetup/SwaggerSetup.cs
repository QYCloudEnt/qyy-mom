﻿using log4net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TMom.Infrastructure;
using Swashbuckle.AspNetCore.Filters;
using System.Runtime.InteropServices;
using static TMom.Domain.Model.GlobalVars;
using static TMom.Infrastructure.CustomApiVersion;

namespace TMom.Application.Ext
{
    /// <summary>
    /// Swagger 启动服务
    /// </summary>
    public static class SwaggerSetup
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SwaggerSetup));

        public static void AddSwaggerSetup(this IServiceCollection services, string? soluName)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var basePath = AppContext.BaseDirectory;
            var ApiName = Appsettings.app(new string[] { "Startup", "ApiName" });

            services.AddSwaggerGen(c =>
            {
                //遍历出全部的版本，做文档信息展示
                typeof(ApiVersions).GetEnumNames().ToList().ForEach(version =>
                {
                    c.SwaggerDoc(version, new OpenApiInfo
                    {
                        Version = version,
                        Title = $"{ApiName} 接口文档——{RuntimeInformation.FrameworkDescription}",
                        Description = $"{ApiName} HTTP API " + version,
                    });
                    c.OrderActionsBy(o => o.RelativePath);
                });

                try
                {
                    //这个就是刚刚配置的xml文件名
                    var xmlPath = Path.Combine(basePath, $"{soluName}.xml");
                    //默认的第二个参数是false，这个是controller的注释，记得修改
                    c.IncludeXmlComments(xmlPath, true);

                    //这个就是Model层的xml文件名
                    var xmlModelPath = Path.Combine(basePath, "TMom.Domain.Model.xml");
                    c.IncludeXmlComments(xmlModelPath);
                }
                catch (Exception ex)
                {
                    log.Error($"{soluName}.xml和TMom.Domain.Model.xml 丢失，请检查并拷贝。\n" + ex.Message);
                }

                // 开启加权小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                // 在header中添加token，传递到后台
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                // ids4和jwt切换
                if (Permissions.IsUseIds4)
                {
                    //接入identityserver4
                    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.OAuth2,
                        Flows = new OpenApiOAuthFlows
                        {
                            Implicit = new OpenApiOAuthFlow
                            {
                                AuthorizationUrl = new Uri($"{Appsettings.app(new string[] { "Startup", "IdentityServer4", "AuthorizationUrl" })}/connect/authorize"),
                                Scopes = new Dictionary<string, string> {
                                {
                                    "TMom.api","ApiResource id"
                                }
                            }
                            }
                        }
                    });
                }
                else
                {
                    // Jwt Bearer 认证，必须是 oauth2
                    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                    {
                        Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                        Name = "Authorization",//jwt默认的参数名称
                        In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                        Type = SecuritySchemeType.ApiKey
                    });
                }
            });
        }
    }
}