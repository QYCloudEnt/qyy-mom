using Microsoft.Extensions.Hosting;
using Nacos.V2;

namespace TMom.Application.Ext
{
    /// <summary>
    ///
    /// </summary>
    public class NacosListenNamingTask : BackgroundService
    {
        private readonly INacosNamingService _nacosNamingService;

        /// <summary>
        /// 监听事件
        /// </summary>
        private NamingServiceEventListener eventListener = new NamingServiceEventListener();

        /// <summary>
        ///
        /// </summary>
        /// <param name="nacosNamingService"></param>
        /// <param name="serviceProvider"></param>
        /// <param name="configuration"></param>
        public NacosListenNamingTask(INacosNamingService nacosNamingService)
        {
            _nacosNamingService = nacosNamingService;
        }

        /// <summary>
        /// 订阅服务变化
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.FromResult(Task.CompletedTask);
        }
    }

    /// <summary>
    /// 服务变更事件监听
    /// </summary>
    public class NamingServiceEventListener : IEventListener
    {
        /// <summary>
        ///
        /// </summary>
        //public static redisHelper _redisCachqManager = new redisHelper();

        /// <summary>
        /// 监听事件
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        public Task OnEvent(Nacos.V2.IEvent @event)
        {
            if (@event is Nacos.V2.Naming.Event.InstancesChangeEvent e)
            {
                Console.WriteLine($"==========收到服务变更事件=======》{Newtonsoft.Json.JsonConvert.SerializeObject(e)}");

                // 配置有变动后 刷新redis配置 刷新 mq配置

                //_redisCachqManager.DisposeRedisConnection();
            }

            return Task.CompletedTask;
        }
    }
}