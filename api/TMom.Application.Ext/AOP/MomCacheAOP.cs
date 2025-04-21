using Castle.DynamicProxy;
using TMom.Infrastructure;
using TMom.Infrastructure.Common;

namespace TMom.Application.Ext
{
    /// <summary>
    /// 面向切面的缓存使用
    /// </summary>
    public class MomCacheAOP : CacheAOPBase
    {
        //通过注入的方式，把缓存操作接口通过构造函数注入
        private readonly ICaching _cache;

        public MomCacheAOP(ICaching cache)
        {
            _cache = cache;
        }

        //Intercept方法是拦截的关键所在，也是IInterceptor接口中的唯一定义
        public override void Intercept(IInvocation invocation)
        {
            try
            {
                var method = invocation.MethodInvocationTarget ?? invocation.Method;
                //对当前方法的特性验证
                //如果需要验证
                var _cachingAttribute = method.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(CachingAttribute));
                if (_cachingAttribute is CachingAttribute qCachingAttribute)
                {
                    //获取自定义缓存键
                    var cacheKey = CustomCacheKey(invocation);
                    //根据key获取相应的缓存值
                    var cacheValue = _cache.Get(cacheKey);
                    if (cacheValue != null)
                    {
                        //将当前获取到的缓存值，赋值给当前执行方法
                        invocation.ReturnValue = cacheValue;
                        return;
                    }
                    //去执行当前的方法
                    invocation.Proceed();
                    //存入缓存
                    if (!string.IsNullOrWhiteSpace(cacheKey))
                    {
                        _cache.Set(cacheKey, invocation.ReturnValue, qCachingAttribute.AbsoluteExpiration);
                    }
                }
                else
                {
                    invocation.Proceed();//直接执行被拦截方法
                }
            }
            catch (Exception)
            {
                invocation.Proceed();//直接执行被拦截方法
            }
        }
    }
}