using Newtonsoft.Json;

namespace TMom.Infrastructure
{
    /// <summary>
    /// 事件模型
    /// 基类
    /// </summary>
    public class IntegrationEvent
    {
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.UtcNow;
        }

        [JsonConstructor]
        public IntegrationEvent(Guid id, DateTime createTime)
        {
            Id = id;
            CreateTime = createTime;
        }

        [JsonProperty]
        public Guid Id { get; private set; }

        [JsonProperty]
        public DateTime CreateTime { get; private set; }
    }
}