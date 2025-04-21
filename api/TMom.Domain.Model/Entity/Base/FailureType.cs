using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 不良类型表
    /// </summary>
    [SugarTable("base_failure_type")]
    public class FailureType : RootEntity<int>
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
        /// 备注
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Remark { get; set; }
    }
}
