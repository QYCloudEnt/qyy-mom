using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 数据字典表
    /// </summary>
    [SugarTable("dev_data_dic", "数据字典表")]
    public class DataDic : RootEntity<int>
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
        public string Remark { get; set; } = "";

        /// <summary>
        /// 排序
        /// </summary>

        [SugarColumn(IsNullable = false, DefaultValue = "1")]
        public int SortNo { get; set; }

        /// <summary>
        /// 类别编码
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public string CategoryCode { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public string CategoryName { get; set; }
    }
}