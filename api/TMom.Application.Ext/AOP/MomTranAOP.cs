using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using TMom.Infrastructure;
using TMom.Infrastructure.Helper;
using TMom.Infrastructure.Repository;
using System.Reflection;

namespace TMom.Application.Ext
{
    /// <summary>
    /// 事务拦截器MomTranAOP 继承IInterceptor接口
    /// </summary>
    public class MomTranAOP : IInterceptor
    {
        private readonly ILogger<MomTranAOP> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public MomTranAOP(IUnitOfWork unitOfWork, ILogger<MomTranAOP> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// 实例化IInterceptor唯一方法
        /// </summary>
        /// <param name="invocation">包含被拦截方法的信息</param>
        public void Intercept(IInvocation invocation)
        {
            try
            {
                var method = invocation.MethodInvocationTarget ?? invocation.Method;
                //对当前方法的特性验证
                //如果需要验证
                if (method.GetCustomAttribute<UseTranAttribute>(true) is { } uta)
                {
                    try
                    {
                        ConsoleHelper.WriteSuccessLine($"Begin Transaction", ConsoleColor.Green);

                        Before(method, uta.Propagation);

                        invocation.Proceed();

                        // 异步获取异常，先执行
                        if (IsAsyncMethod(invocation.Method))
                        {
                            var result = invocation.ReturnValue;
                            if (result is Task)
                            {
                                Task.WaitAll(result as Task);
                            }
                        }
                        _unitOfWork.CommitTran(method);
                    }
                    catch (Exception ex)
                    {
                        ConsoleHelper.WriteErrorLine($"Rollback Transaction: {ex}");
                        _logger.LogError(ex.ToString());
                        _unitOfWork.RollbackTran(method);
                        throw;
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

        private void Before(MethodInfo method, Propagation propagation)
        {
            switch (propagation)
            {
                case Propagation.Required:
                    if (_unitOfWork.TranCount <= 0)
                    {
                        _logger.LogDebug($"Begin Transaction");
                        _unitOfWork.BeginTran(method);
                    }

                    break;

                case Propagation.Mandatory:
                    if (_unitOfWork.TranCount <= 0)
                    {
                        throw new Exception("事务传播机制为:[Mandatory],当前不存在事务");
                    }

                    break;

                case Propagation.Nested:
                    _logger.LogDebug($"Begin Transaction");
                    _unitOfWork.BeginTran(method);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(propagation), propagation, null);
            }
        }

        /// <summary>
        /// 获取变量的默认值
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public object GetDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }

        private async Task SuccessAction(IInvocation invocation)
        {
            await Task.Run(() =>
            {
                //...
            });
        }

        public static bool IsAsyncMethod(MethodInfo method)
        {
            return (
                method.ReturnType == typeof(Task) ||
                (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
                );
        }

        private async Task TestActionAsync(IInvocation invocation)
        {
            await Task.Run(null);
        }
    }
}