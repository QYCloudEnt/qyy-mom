using TMom.Infrastructure.Helper;
using Polly;
using Polly.Retry;
using SapNwRfc.Pooling;
using System.Diagnostics;
using System.Net.Sockets;

namespace TMom.Infrastructure
{
    /// <summary>
    /// Sap帮助类
    /// </summary>
    public class SapHelper
    {
        private static ISapPooledConnection _sapPooledConnection { get; set; }
        private static Stopwatch _stopwatch = new Stopwatch();
        private static int _retryCount = 3;

        public SapHelper(ISapPooledConnection sapPooledConnection)
        {
            _sapPooledConnection = sapPooledConnection;
        }

        /// <summary>
        /// 调用Sap接口带参数, 内部记录日志
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="funcName"></param>
        /// <param name="input"></param>
        /// <param name="addLog">添加日志的方法</param>
        /// <returns></returns>
        public static async Task<TOutput> InvokeRfcFuncAsync<TOutput>(string funcName, object input, Action<string> addLog = null) where TOutput : class
        {
            return await InvokeFunc<TOutput>(funcName, input, addLog);
        }

        /// <summary>
        /// 调用Sap接口无参数, 内部记录日志
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="funcName"></param>
        /// <param name="addLog">添加日志的方法</param>
        /// <returns></returns>
        public static async Task<TOutput> InvokeRfcFuncAsync<TOutput>(string funcName, Action<string> addLog = null) where TOutput : class
        {
            return await InvokeFunc<TOutput>(funcName, null, addLog);
        }

        #region 私有方法

        /// <summary>
        /// 调用Sap接口
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="funcName"></param>
        /// <param name="input"></param>
        /// <param name="addLog"></param>
        /// <returns></returns>
        private static async Task<TOutput> InvokeFunc<TOutput>(string funcName, object input, Action<string> addLog = null)
        {
            TOutput output = default(TOutput);
            addLog($"调用Sap接口: {funcName}开始, 参数: {JsonHelper.ObjToJson(input)}");
            var policy = RetryPolicy.Handle<Exception>()
                .Or<SocketException>()
                .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time, cnt, context) =>
                {
                    if (cnt == _retryCount)
                    {
                        addLog($"重试{_retryCount}次(耗时{time.TotalSeconds}秒)后仍然失败!");
                    }
                });
            _stopwatch.Restart();
            await Task.Factory.StartNew(() =>
            {
                policy.Execute(() =>
                {
                    if (input != null)
                    {
                        output = _sapPooledConnection.InvokeFunction<TOutput>(funcName, input);
                    }
                    else
                    {
                        output = _sapPooledConnection.InvokeFunction<TOutput>(funcName);
                    }
                });
            }, TaskCreationOptions.LongRunning);
            _stopwatch.Stop();
            addLog($"调用Sap接口: {funcName}结束, 耗时: {_stopwatch.ElapsedMilliseconds}ms");

            return output;
        }

        #endregion 私有方法
    }
}