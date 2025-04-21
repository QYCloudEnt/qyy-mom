using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TMom.Infrastructure.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static TMom.Application.Ext.GlobalExceptionFilter;

namespace TMom.Application.Ext
{
    public static class ControllerSetup
    {
        /// <summary>
        /// 注入控制器
        /// </summary>
        /// <param name="services"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddControllerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddControllers(o =>
            {
                // 全局异常过滤
                o.Filters.Add(typeof(GlobalExceptionsFilter));
                // 全局路由权限公约
                //o.Conventions.Insert(0, new GlobalRouteAuthorizeConvention());
                // 全局路由前缀，统一修改路由
                o.Conventions.Insert(0, new GlobalRoutePrefixFilter(new RouteAttribute(RoutePrefix.Name)));
                // 模型验证可为空
                o.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
            })
            //MVC全局配置Json序列化处理
            .AddNewtonsoftJson(options =>
            {
                //忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //不使用驼峰样式的key
                //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //设置时间格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                //忽略Model中为null的属性
                //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                //设置本地时间而非UTC时间
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
                //添加Enum转string
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            });

            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
        }
    }
}