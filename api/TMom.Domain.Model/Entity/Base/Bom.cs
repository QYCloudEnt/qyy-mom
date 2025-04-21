using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// BOM
    /// </summary>
    [SugarTable("base_bom")]
    public class Bom : RootEntity<int>
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
        /// 父级编码
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string ParentCode { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        [SugarColumn(Length = 10)]
        public string Version { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 工序Id
        /// </summary>
        public int? ProcessOperationId { get; set; }

        /// <summary>
        /// 工序用量
        /// </summary>
        [SugarColumn(DecimalDigits = 2)]
        public decimal? UseQty { get; set; }

        /// <summary>
        /// 关联的产品料号编码(为空则表示编码一致)
        /// </summary>
        public string PartCode { get; set; } = "";

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; } = "";

        /// <summary>
        /// 工序表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(ProcessOperationId))]
        public ProcessOperation? ProcessOperation { get; set; }
    }
}