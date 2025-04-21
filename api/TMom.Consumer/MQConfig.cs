using TMom.Application.Dto;
using TMom.Consumer.EventHandler;
using TMom.Infrastructure;
using TMom.Infrastructure.Helper;

namespace TMom.Consumer
{
    public class MQConfig
    {
        private static readonly AutoResetEvent _closingEvent = new AutoResetEvent(false);

        /// <summary>
        /// 订阅服务初始化
        /// </summary>
        public static void SubscribeInit()
        {
            var eventBus = AutofacContainer.Resolve<IEventBus>();
            // 添加事件订阅
            eventBus.Subscribe<SysLogEventModel, SysLogEventHandler>();

            ConsoleHelper.WriteSuccessLine($"消息队列服务启动成功!");
            Console.CancelKeyPress += ((s, a) =>
            {
                Console.WriteLine("程序已退出！");
                _closingEvent.Set();
            });
            _closingEvent.WaitOne();
        }
    }
}