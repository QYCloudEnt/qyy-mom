using Autofac;
using Autofac.Extras.DynamicProxy;
using log4net;
using TMom.Domain.IRepository;
using TMom.Infrastructure;
using TMom.Infrastructure.Repository;
using System.Reflection;

namespace TMom.Application.Ext
{
    public class AutofacModuleRegister : Autofac.Module
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(AutofacModuleRegister));

        protected override void Load(ContainerBuilder builder)
        {
            var basePath = AppContext.BaseDirectory;

            #region 带有接口层的服务注入

            var servicesDllFile = Path.Combine(basePath, "TMom.Application.Service.dll");
            var repositoryDllFile = Path.Combine(basePath, "TMom.Infrastructure.Repository.dll");

            if (!(File.Exists(servicesDllFile) && File.Exists(repositoryDllFile)))
            {
                var msg = "Repository.dll和Service.dll 丢失，因为项目解耦了，所以需要先F6编译，再F5运行，请检查 bin 文件夹，并拷贝。";
                log.Error(msg);
                throw new Exception(msg);
            }

            var cacheType = new List<Type>();
            if (Appsettings.app(new string[] { "AppSettings", "RedisCachingAOP", "Enabled" }).ObjToBool())
            {
                builder.RegisterType<MomRedisCacheAOP>();
                cacheType.Add(typeof(MomRedisCacheAOP));
            }
            if (Appsettings.app(new string[] { "AppSettings", "MemoryCachingAOP", "Enabled" }).ObjToBool())
            {
                builder.RegisterType<MomCacheAOP>();
                cacheType.Add(typeof(MomCacheAOP));
            }
            if (Appsettings.app(new string[] { "AppSettings", "TranAOP", "Enabled" }).ObjToBool())
            {
                builder.RegisterType<MomTranAOP>();
                cacheType.Add(typeof(MomTranAOP));
            }
            if (Appsettings.app(new string[] { "AppSettings", "LogAOP", "Enabled" }).ObjToBool())
            {
                builder.RegisterType<MomLogAOP>();
                cacheType.Add(typeof(MomLogAOP));
            }

            builder.RegisterGeneric(typeof(BaseRepository<,>)).As(typeof(IBaseRepository<,>)).InstancePerDependency();//注册仓储

            // 获取 Service.dll 程序集服务，并注册
            var assemblysServices = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(assemblysServices)
                      .AsImplementedInterfaces()
                      .InstancePerDependency()
                      .PropertiesAutowired()
                      .EnableInterfaceInterceptors()//引用Autofac.Extras.DynamicProxy;
                      .InterceptedBy(cacheType.ToArray());//允许将拦截器服务的列表分配给注册。

            // 获取 Repository.dll 程序集服务，并注册
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository)
                   .AsImplementedInterfaces()
                   .PropertiesAutowired()
                   .InstancePerDependency();

            #endregion 带有接口层的服务注入

            #region 没有接口层的服务层注入

            //因为没有接口层，所以不能实现解耦，只能用 Load 方法。
            //注意如果使用没有接口的服务，并想对其使用 AOP 拦截，就必须设置为虚方法
            //var assemblysServicesNoInterfaces = Assembly.Load("TMom.Application.Service");
            //builder.RegisterAssemblyTypes(assemblysServicesNoInterfaces);

            #endregion 没有接口层的服务层注入

            #region 没有接口的单独类，启用class代理拦截

            //只能注入该类中的虚方法，且必须是public
            //这里仅仅是一个单独类无接口测试，不用过多追问
            //builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(Love)))
            //    .EnableClassInterceptors()
            //    .InterceptedBy(cacheType.ToArray());

            #endregion 没有接口的单独类，启用class代理拦截

            #region 单独注册一个含有接口的类，启用interface代理拦截

            //不用虚方法
            //builder.RegisterType<TasksQzServices>().As<ITasksQzServices>()
            //   .AsImplementedInterfaces()
            //   .EnableInterfaceInterceptors()
            //   .InterceptedBy(typeof(MomCacheAOP));

            #endregion 单独注册一个含有接口的类，启用interface代理拦截
        }
    }
}