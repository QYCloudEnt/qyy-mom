using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 假期设置
    /// </summary>
    [SugarTable("base_holidays")]
    public class Holidays : RootEntity<int>
    {
        /// <summary>
        /// 假期日期
        /// </summary>
        public DateTime Date { get; set; }
    }
}