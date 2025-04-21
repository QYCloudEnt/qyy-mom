global using TMom.Infrastructure;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using TMom.Filter;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TMom.Infrastructure.Common;
using System.Reflection;
using TMom.Application.Ext;
using TMom.Domain.Model.Seed;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(container =>
            {
                container.RegisterModule(new AutofacModuleRegister());
                container.RegisterModule<AutofacPropertityModuleReg>();
            });

builder.Logging.AddFilter("System", LogLevel.Error)
               .AddFilter("Microsoft", LogLevel.Error)
               .SetMinimumLevel(LogLevel.Error)
               .AddLog4Net(Path.Combine(Directory.GetCurrentDirectory(), "Log4net.config"));

/****************************************************/

IConfiguration configuration = builder.Configuration;

// Add services to the container.

var services = builder.Services;

services.AddSingleton(new Appsettings(configuration));
services.AddSingleton(new LogLock(builder.Environment.ContentRootPath));

var soluName = Assembly.GetExecutingAssembly().GetName().Name;

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

services.AddMemoryCacheSetup();
services.AddSqlsugarSetup();
services.AddDbSetup();
services.AddAutoMapperSetup();
services.AddCorsSetup();
services.AddSwaggerSetup(soluName);
services.AddHttpContextSetup();
services.AddHttpClient();
services.AddRedisCacheSetup();
services.AddAuthorizationSetup();
services.AddAuthentication_JWTSetup();
services.AddIpPolicyRateLimitSetup(configuration);
services.AddScoped<UseServiceDIAttribute>();
services.Configure<KestrelServerOptions>(x => x.AllowSynchronousIO = true)
        .Configure<IISServerOptions>(x => x.AllowSynchronousIO = true);
services.AddControllerSetup();

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
if (builder.Environment.IsDevelopment())
{
    SetSysStaticInfo.PrepareStaticVal(soluName, builder.Environment.ContentRootPath, builder.Environment.WebRootPath);
}

/****************************************************/

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseResponseBodyRead();

app.UseIpLimitMildd();
app.UseReuestResponseLog();
app.UseRecordAccessLogsMildd();
app.UseIPLogMildd();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwaggerMildd();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseCors(Appsettings.app(["Startup", "Cors", "PolicyName"]));
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseStatusCodePages();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseExceptionHandlerMidd();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

var lifetime = app.Lifetime;
app.UseConsulMildd(configuration, lifetime);

AutofacContainer.Instance = app.Services;
var sqlSugarClient = app.Services.GetRequiredService<SqlSugar.ISqlSugarClient>();
app.UseSeedDataMildd(new MyContext(sqlSugarClient), app.Environment.WebRootPath, sqlSugarClient);
app.Run();