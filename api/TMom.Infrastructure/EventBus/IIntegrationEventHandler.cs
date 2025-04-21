namespace TMom.Infrastructure
{
    /// <summary>
    /// 集成事件处理程序
    /// 泛型接口
    /// </summary>
    /// <typeparam name="TIntegrationEvent"></typeparam>
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
       where TIntegrationEvent : IntegrationEvent
    {
        /// <summary>
        /// 处理订阅接收到的消息
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        Task Handle(TIntegrationEvent @event);
    }

    /// <summary>
    /// 集成事件处理程序
    /// 基 接口
    /// </summary>
    public interface IIntegrationEventHandler
    {
    }
}