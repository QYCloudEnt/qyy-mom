using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Nacos.V2;

namespace TMom.Application.Ext
{
    /// <summary>
    /// Nacos配置文件变更事件
    /// </summary>
    public class NacosListenConfigurationTask : BackgroundService
    {
        private readonly INacosConfigService _configClient;

        /// <summary>
        /// Nacos 配置文件监听事件
        /// </summary>
        private NacosConfigListener nacosConfigListener = new NacosConfigListener();

        /// <summary>
        /// 重载方法
        /// </summary>
        /// <param name="configClient"></param>
        /// <param name="serviceProvider"></param>
        public NacosListenConfigurationTask(INacosConfigService configClient, IServiceProvider serviceProvider)
        {
            _configClient = configClient;
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                // Add listener
                await _configClient.AddListener("TMom.Api.json", "DEFAULT_GROUP", nacosConfigListener);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            // Remove listener
            await _configClient.RemoveListener("TMom.Api.json", "DEFAULT_GROUP", nacosConfigListener);

            await base.StopAsync(cancellationToken);
        }
    }

    /// <summary>
    /// 配置监听事件
    /// </summary>
    public class NacosConfigListener : IListener
    {
        /// <summary>
        /// 收到配置文件变更
        /// </summary>
        /// <param name="configInfo"></param>
        public void ReceiveConfigInfo(string configInfo)
        {
            var _configurationBuilder = new ConfigurationBuilder();
            _configurationBuilder.Sources.Clear();
            var buffer = System.Text.Encoding.Default.GetBytes(configInfo);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(buffer);
            _configurationBuilder.AddJsonStream(ms);
            var configuration = _configurationBuilder.Build();
            ms.Dispose();
        }
    }
}