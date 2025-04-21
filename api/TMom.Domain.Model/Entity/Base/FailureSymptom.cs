using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 不良现象
    /// </summary>
    [SugarTable("base_failure_symptom")]
    public class FailureSymptom: RootEntity<int>
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
        /// 不良类型Id
        /// </summary>
        public int FailureTypeId { get; set; }

        /// <summary>
        /// 不良类型表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(FailureTypeId))]
        public FailureType FailureType { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Description { get; set; }
    }
}
