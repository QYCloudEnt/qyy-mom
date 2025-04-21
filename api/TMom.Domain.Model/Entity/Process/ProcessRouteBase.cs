using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 工艺路线基础信息配置
    /// </summary>
    public class ProcessRouteBase : RootEntity<int>
    {
        /// <summary>
        /// 工艺路线表Id
        /// </summary>
        public int ProcessRouteId { get; set; }

        /// <summary>
        /// 工序Id
        /// </summary>
        public int OperationId { get; set; }

        /// <summary>
        /// 是否起始站
        /// </summary>
        public bool IsStart { get; set; } = false;

        /// <summary>
        /// 是否产出站
        /// </summary>
        public bool IsOutput { get; set; } = false;

        /// <summary>
        /// 是否缺料提醒
        /// </summary>
        public bool IsLackMaterialWarn { get; set; } = false;

        /// <summary>
        /// 跳转的工艺路线id
        /// </summary>
        public int? JumpToRouteId { get; set; }

        /// <summary>
        /// 跳转回来后的工序id
        /// </summary>
        public int? BackOperationId { get; set; }

        /// <summary>
        /// 工序表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(OperationId))]
        public ProcessOperation ProcessOperation { get; set; }
    }
}