using SqlSugar;
using SqlSugar.DbConvert;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 工艺路线测试相关配置
    /// </summary>
    public class ProcessRouteTest : RootEntity<int>
    {
        /// <summary>
        /// 工艺路线表Id
        /// </summary>
        public int ProcessRouteId { get; set; }

        /// <summary>
        /// 工序Id
        /// </summary>
        public int OperationId { get; set; }

        /// <summary>
        /// 测试模式
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(20)", SqlParameterDbType = typeof(EnumToStringConvert))]
        public TestModeEnum? TestMode { get; set; }

        /// <summary>
        /// 最大测试次数
        /// </summary>
        public int? MaxTestCount { get; set; }

        /// <summary>
        /// 工序表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(OperationId))]
        public ProcessOperation ProcessOperation { get; set; }
    }
}