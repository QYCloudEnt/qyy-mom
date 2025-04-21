namespace TMom.Infrastructure
{
    /// <summary>
    /// 使用事务执行方法
    /// <para>service层中使用</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class UseTranAttribute : Attribute
    {
        /// <summary>
        /// 事务传播方式
        /// </summary>
        public Propagation Propagation { get; set; } = Propagation.Required;
    }
}