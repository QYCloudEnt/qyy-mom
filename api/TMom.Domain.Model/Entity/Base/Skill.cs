using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 人员技能
    /// </summary>
    [SugarTable("base_skill")]
    public class Skill : RootEntity<int>
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
        /// 描述
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Description { get; set; }
    }
}