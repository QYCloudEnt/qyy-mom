namespace TMom.Infrastructure
{
    /// <summary>
    /// service层方法缓存特性, 外部必须直接调用此方法才生效(方法内部调用此方法不生效, 因为不走AOP)
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class CachingAttribute : Attribute
    {
        /// <summary>
        /// 缓存绝对过期时间（分钟）
        /// </summary>
        public int AbsoluteExpiration { get; set; } = 30;
    }
}