using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 产品料号表
    /// </summary>
    [SugarTable("base_part_material")]
    public class PartMaterial : RootEntity<int>
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
        public string Spec { get; set; } = "";

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 预警值
        /// </summary>
        public decimal? WarnQty { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; } = "";

        /// <summary>
        /// 群组Id
        /// </summary>
        public int PartGroupId { get; set; }

        /// <summary>
        /// 工艺路线Id
        /// </summary>
        public int? ProcessRouteId { get; set; }

        /// <summary>
        /// 主数据群组表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(PartGroupId))]
        public PartGroup PartGroup { get; set; }
    }
}