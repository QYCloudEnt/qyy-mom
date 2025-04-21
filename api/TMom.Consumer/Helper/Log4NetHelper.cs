using log4net;
using log4net.Config;
using log4net.Repository;
using System.ComponentModel;

namespace TMom.Consumer
{
    public class Log4NetHelper
    {
        private static ILoggerRepository repository { get; set; }

        private static ILog _log;

        private static ILog log
        {
            get
            {
                if (_log == null)
                {
                    Configure();
                }
                return _log;
            }
        }

        public static void Configure(string repositoryName = "LogFileAppender", string configFile = "Log4net.config")
        {
            repository = LogManager.CreateRepository(repositoryName);
            XmlConfigurator.Configure(repository, new FileInfo(configFile));

            _log = LogManager.GetLogger(repositoryName, "Logger");
        }

        /// <summary>
        /// 调用Log4Net写日志，日志等级为：错误（Error）
        /// </summary>
        /// <param name="logContent">日志内容</param>
        public static void WriteLog(string logContent)
        {
            WriteLog(null, logContent, Log4NetLevel.Error);
        }

        /// <summary>
        /// 调用Log4Net写日志
        /// </summary>
        /// <param name="logContent">日志内容</param>
        /// <param name="log4NetLevel">日志等级，枚举类型</param>
        public static void WriteLog(string logContent, Log4NetLevel log4NetLevel)
        {
            WriteLog(null, logContent, log4NetLevel);
        }

        /// <summary>
        /// 调用Log4Net写日志
        /// </summary>
        /// <param name="type">类的类型，指定日志中错误的具体类。例如：typeof(Index)，Index是类名，如果为空表示不指定类</param>
        /// <param name="logContent">日志内容</param>
        /// <param name="log4NetLevel">日志等级，枚举类型</param>
        public static void WriteLog(Type type, string logContent, Log4NetLevel log4NetLevel)
        {
            switch (log4NetLevel)
            {
                case Log4NetLevel.Warn:
                    log.Warn(logContent);
                    break;

                case Log4NetLevel.Debug:
                    log.Debug(logContent);
                    break;

                case Log4NetLevel.Info:
                    log.Info(logContent);
                    break;

                case Log4NetLevel.Fatal:
                    log.Fatal(logContent);
                    break;

                case Log4NetLevel.Error:
                    log.Error(logContent);
                    break;
            }
        }

        public static void Info(string msg)
        {
            log.Info(msg);
        }
    }

    public enum Log4NetLevel
    {
        [Description("警告信息")]
        Warn = 1,

        [Description("调试信息")]
        Debug = 2,

        [Description("一般信息")]
        Info = 3,

        [Description("严重错误")]
        Fatal = 4,

        [Description("错误日志")]
        Error
    }
}