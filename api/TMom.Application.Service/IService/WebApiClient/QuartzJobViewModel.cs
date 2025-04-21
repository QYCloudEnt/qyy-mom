namespace TMom.Application.Service.IService
{
    public class QuartzJobViewModel
    {
        /// <summary>
        /// 定时任务表Id
        /// </summary>
        public int SysJobId { get; set; } = 0;

        /// <summary>
        /// 方法名称
        /// </summary>
        public string FuncName { get; set; }

        /// <summary>
        /// 方法参数(SysJob)
        /// </summary>
        public string FuncParams { get; set; } = "";

        /// <summary>
        /// 操作人Id
        /// </summary>
        public int SysUserId { get; set; } = 1;

        /// <summary>
        /// 操作时间
        /// </summary>
        public string OperationTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}