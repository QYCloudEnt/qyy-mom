using TMom.Domain.Model;

namespace TMom.Application.Dto
{
    public class ProcessRouteStatusParams
    {
        public int Id { get; set; }

        public bool IsPublish { get; set; }
    }

    public class ProcessRouteDesignParams
    {
        /// <summary>
        /// 工艺路线表Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// AntdX6 Graph
        /// </summary>
        public string Graph { get; set; }

        /// <summary>
        /// 预览图
        /// </summary>
        public string Base64 { get; set; }

        /// <summary>
        /// 流程数据
        /// </summary>
        public List<ProcessData> ProcessData { get; set; }

        /// <summary>
        /// 工序的配置项
        /// </summary>
        public List<ConfigForm> ConfigForm { get; set; }
    }

    public class ProcessData
    {
        /// <summary>
        /// 工序Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 下一道工序Id
        /// </summary>
        public int NextId { get; set; }

        /// <summary>
        /// 流转状态
        /// </summary>
        public string Label { get; set; }
    }

    public class ConfigForm
    {
        /// <summary>
        /// 工序Id
        /// </summary>
        public int Id { get; set; }

        public ProcessBase Base { get; set; }

        public ProcessTest Test { get; set; }
    }

    public class ProcessBase
    {
        public bool IsStart { get; set; }

        public bool IsOutput { get; set; }

        public bool IsLackMaterialWarn { get; set; }

        /// <summary>
        /// 跳转的工艺路线id
        /// </summary>
        public int? JumpToRouteId { get; set; }

        /// <summary>
        /// 跳转回来后的工序id
        /// </summary>
        public int? BackOperationId { get; set; }
    }

    public class ProcessTest
    {
        public TestModeEnum? TestMode { get; set; }

        public int MaxTestCount { get; set; } = 0;
    }
}