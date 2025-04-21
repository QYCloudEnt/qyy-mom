using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 替代料表
    /// </summary>
    [SugarTable("base_material_replace")]
    public class MaterialReplace : RootEntity<int>
    {
        /// <summary>
        /// 源物料Id
        /// </summary>
        public int SourceMaterialId { get; set; }

        /// <summary>
        /// 替代物料Id
        /// </summary>
        public int ReplaceMaterialId { get; set; }

        /// <summary>
        /// 工单Id
        /// </summary>
        public int? WorkOrderId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; } = "";

        /// <summary>
        /// 有效开始日期
        /// </summary>
        public DateTime? ExpDateS { get; set; }

        /// <summary>
        /// 有效截止日期
        /// </summary>
        public DateTime? ExpDateE { get; set; }

        /// <summary>
        /// 源物料表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(SourceMaterialId))]
        public PartMaterial SourceMaterial { get; set; }

        /// <summary>
        /// 替代物料表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(ReplaceMaterialId))]
        public PartMaterial ReplaceMaterial { get; set; }
    }
}