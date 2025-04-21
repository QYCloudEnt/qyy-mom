using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 工位表
    /// </summary>
    [SugarTable("base_workstation")]
    public class Workstation : RootEntity<int>
    {
        /// <summary>
        /// 工位编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 工位名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 工序Id
        /// </summary>
        public int ProcessOperationId { get; set; }

        /// <summary>
        /// 产线Id
        /// </summary>
        public int LineId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string? Description { get; set; }

        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(ProcessOperationId))]
        public ProcessOperation ProcessOperation { get; set; }

        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(LineId))]
        public Line Line { get; set; }
    }
}