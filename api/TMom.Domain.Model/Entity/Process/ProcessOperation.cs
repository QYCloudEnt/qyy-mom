using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 工序表
    /// </summary>
    public class ProcessOperation : RootEntity<int>
    {
        /// <summary>
        /// 工序编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 工序名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类型(映射字典表)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 字典表对应的类型名称
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string TypeName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string? Description { get; set; }
    }
}