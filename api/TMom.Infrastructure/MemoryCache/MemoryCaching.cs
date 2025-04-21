using Microsoft.Extensions.Caching.Memory;

namespace TMom.Infrastructure.Common
{
    /// <summary>
    /// 实例化缓存接口ICaching
    /// </summary>
    public class MemoryCaching : ICaching
    {
        //引用Microsoft.Extensions.Caching.Memory;这个和.net 还是不一样，没有了Httpruntime了
        private readonly IMemoryCache _cache;

        //还是通过构造函数的方法，获取
        public MemoryCaching(IMemoryCache cache)
        {
            _cache = cache;
        }

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public object Get(string cacheKey)
        {
            return _cache.Get(cacheKey);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="cacheKey">缓存Key</param>
        /// <param name="cacheValue">值</param>
        /// <param name="timeSpan">分钟</param>
        public void Set(string cacheKey, object cacheValue, int timeSpan)
        {
            _cache.Set(cacheKey, cacheValue, TimeSpan.FromSeconds(timeSpan * 60));
        }
    }
}