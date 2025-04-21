using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TMom.Application.Ext;
using TMom.Consumer;
using TMom.Infrastructure;
using System.Reflection;

var build = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
IServiceCollection services = new ServiceCollection()
                                  .AddLogging(cfg => cfg.AddFilter("System", LogLevel.Error)
                                                        .AddFilter("Microsoft", LogLevel.Error)
                                                        .SetMinimumLevel(LogLevel.Error)
                                                        .AddConsole()
                                                        .AddLog4Net(Path.Combine(Directory.GetCurrentDirectory(), "log4net.config"))
                                              );

services.AddSingleton(new Appsettings(build));

services.AddRedisCacheSetup();
services.AddSqlsugarSetup();
services.AddHttpContextSetup();
services.AddAutoMapperSetup();
services.AddRabbitMQSetup();
services.AddKafkaSetup(build);
services.AddEventBusSetup();

// 使用Autofac代替默认的服务注册
AutofacContainer.RegisterModule(new AutofacModuleRegister());
AutofacContainer.Register(Assembly.GetExecutingAssembly().GetName().Name);
AutofacContainer.Build(services);

// 订阅服务
MQConfig.SubscribeInit();