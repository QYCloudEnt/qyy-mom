using SqlSugar.DbConvert;
using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 主数据群组表
    /// </summary>
    [SugarTable("base_part_group")]
    public class PartGroup : RootEntity<int>
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
        /// 类型
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(20)", SqlParameterDbType = typeof(EnumToStringConvert))]
        public PartGroupType Type { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Description { get; set; }
    }
}