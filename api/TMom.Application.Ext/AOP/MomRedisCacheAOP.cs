using Castle.DynamicProxy;
using TMom.Infrastructure;

namespace TMom.Application.Ext
{
    /// <summary>
    /// 面向切面的缓存使用
    /// </summary>
    public class MomRedisCacheAOP : CacheAOPBase
    {
        //通过注入的方式，把缓存操作接口通过构造函数注入
        private readonly IRedisRepository _cache;

        public MomRedisCacheAOP(IRedisRepository cache)
        {
            _cache = cache;
        }

        //Intercept方法是拦截的关键所在，也是IInterceptor接口中的唯一定义
        public override void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;
            if (method.ReturnType == typeof(void) || method.ReturnType == typeof(Task))
            {
                invocation.Proceed();
                return;
            }
            //对当前方法的特性验证
            var s = method.Name;
            var qCachingAttribute = method.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(CachingAttribute)) as CachingAttribute;

            if (qCachingAttribute != null)
            {
                //获取自定义缓存键
                var cacheKey = CustomCacheKey(invocation);
                //注意是 string 类型，方法GetValue
                var cacheValue = _cache.GetValue(cacheKey).Result;
                if (cacheValue != null)
                {
                    //将当前获取到的缓存值，赋值给当前执行方法
                    Type returnType;
                    if (typeof(Task).IsAssignableFrom(method.ReturnType))
                    {
                        returnType = method.ReturnType.GenericTypeArguments.FirstOrDefault();
                    }
                    else
                    {
                        returnType = method.ReturnType;
                    }

                    dynamic _result = Newtonsoft.Json.JsonConvert.DeserializeObject(cacheValue, returnType);
                    invocation.ReturnValue = (typeof(Task).IsAssignableFrom(method.ReturnType)) ? Task.FromResult(_result) : _result;
                    return;
                }
                //去执行当前的方法
                invocation.Proceed();

                //存入缓存
                if (!string.IsNullOrWhiteSpace(cacheKey))
                {
                    object response;

                    //Type type = invocation.ReturnValue?.GetType();
                    var type = invocation.Method.ReturnType;
                    if (typeof(Task).IsAssignableFrom(type))
                    {
                        var resultProperty = type.GetProperty("Result");
                        response = resultProperty.GetValue(invocation.ReturnValue);
                    }
                    else
                    {
                        response = invocation.ReturnValue;
                    }
                    if (response == null) response = string.Empty;

                    _cache.Set(cacheKey, response, TimeSpan.FromMinutes(qCachingAttribute.AbsoluteExpiration)).Wait();
                }
            }
            else
            {
                invocation.Proceed();//直接执行被拦截方法
            }
        }
    }
}