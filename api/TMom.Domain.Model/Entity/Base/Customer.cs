using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 客户表
    /// </summary>
    [SugarTable("base_customer")]
    public class Customer : RootEntity<int>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string ShortName { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Phone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Addr { get; set; }

        /// <summary>
        /// 统一社会信用代码
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string CreditCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Remark { get; set; }
    }
}