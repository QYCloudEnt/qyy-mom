using Microsoft.Extensions.Logging;
using TMom.Application.Dto;
using TMom.Application.Service.IService;
using TMom.Domain.Model.Entity;
using TMom.Infrastructure;
using TMom.Infrastructure.Helper;
using TMom.Infrastructure.LogHelper;
using Newtonsoft.Json;

namespace TMom.Consumer.EventHandler
{
    public class SysLogEventHandler : IIntegrationEventHandler<SysLogEventModel>
    {
        private readonly ILogger<SysLogEventHandler> _logger;

        public SysLogEventHandler(ILogger<SysLogEventHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 消费消息
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Handle(SysLogEventModel model)
        {
            ConsoleHelper.WriteSuccessLine($"接收到日志消息:");
            var apiLog = JsonConvert.DeserializeObject<UserAccessModel>(model.LogText);
            SysLog sysLog = new SysLog()
            {
                LogType = model.LogType,
                HttpType = apiLog.RequestMethod,
                ApiUrl = apiLog.API,
                RequestParams = apiLog.RequestData,
                ResponseData = apiLog.ResponseData,
                Agent = apiLog.Agent,
                Ip = apiLog.IP,
                TotalMilliseconds = apiLog.OPTime,
                CreateId = model.SysUserId,
                OperationTime = DateTime.Parse(apiLog.BeginTime),
            };
        }
    }
}