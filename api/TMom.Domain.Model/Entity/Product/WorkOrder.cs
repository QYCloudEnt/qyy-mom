using SqlSugar;
using SqlSugar.DbConvert;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 工单表
    /// </summary>
    public class WorkOrder : RootEntity<int>
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 类型(映射字典表)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(20)", SqlParameterDbType = typeof(EnumToStringConvert))]
        public WorkOrderStatusEnum Status { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(20)", SqlParameterDbType = typeof(EnumToStringConvert))]
        public WorkOrderFromEnum From { get; set; } = WorkOrderFromEnum.Mes;

        /// <summary>
        /// 源工单号(工单拆分记录原先工单编码)
        /// </summary>
        public string SourceCode { get; set; } = "";

        /// <summary>
        /// 工艺路线Id
        /// </summary>
        public int? ProcessRouteId { get; set; }

        /// <summary>
        /// 产品料号Id
        /// </summary>
        public int PartId { get; set; }

        /// <summary>
        /// 产线Id
        /// </summary>
        public int LineId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// 已完成数量
        /// </summary>
        public int CompletedQty { get; set; } = 0;

        /// <summary>
        /// 计划开始时间
        /// </summary>
        public DateTime? PlanDateS { get; set; }

        /// <summary>
        /// 计划完成时间
        /// </summary>
        public DateTime? PlanDateE { get; set; }

        /// <summary>
        /// 实际开始时间
        /// </summary>
        public DateTime? ActualDateS { get; set; }

        /// <summary>
        /// 实际完成时间
        /// </summary>
        public DateTime? ActualDateE { get; set; }

        /// <summary>
        /// 投入数量
        /// </summary>
        public int InputQty { get; set; } = 0;

        /// <summary>
        /// 良品数
        /// </summary>
        public int OkQty { get; set; } = 0;

        /// <summary>
        /// 报废数量
        /// </summary>
        public int ScrapedQty { get; set; } = 0;

        /// <summary>
        /// 字典表对应的类型名称
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string TypeName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Remark { get; set; }

        /// <summary>
        /// 工艺路线表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(ProcessRouteId))]
        public ProcessRoute? ProcessRoute { get; set; }

        /// <summary>
        /// 产品料号表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(PartId))]
        public PartMaterial Part { get; set; }

        /// <summary>
        /// 产线表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(LineId))]
        public Line Line { get; set; }
    }
}