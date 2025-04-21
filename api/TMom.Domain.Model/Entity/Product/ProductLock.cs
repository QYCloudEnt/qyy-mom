using SqlSugar;
using SqlSugar.DbConvert;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 产品锁定
    /// </summary>
    public class ProductLock : RootEntity<int>
    {
        /// <summary>
        /// 业务对象id
        /// </summary>
        public int BusinessId { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 锁定业务类型
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(20)", SqlParameterDbType = typeof(EnumToStringConvert))]
        public ProductLockType Type { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? DateS { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? DateE { get; set; }

        /// <summary>
        /// 工序id
        /// </summary>
        public int? OperationId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(20)", SqlParameterDbType = typeof(EnumToStringConvert))]
        public LockStatus Status { get; set; }

        /// <summary>
        /// 锁定原因
        /// </summary>
        public string LockReason { get; set; }

        /// <summary>
        /// 锁定人id
        /// </summary>
        public int LockUserId { get; set; }

        /// <summary>
        /// 锁定时间
        /// </summary>
        public DateTime LockTime { get; set; }

        /// <summary>
        /// 解锁人id
        /// </summary>
        public int? UnLockUserId { get; set; }

        /// <summary>
        /// 解锁时间
        /// </summary>
        public DateTime? UnLockTime { get; set; }

        /// <summary>
        /// 工序表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(OperationId))]
        public ProcessOperation? ProcessOperation { get; set; }

        /// <summary>
        /// 锁定用户
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string LockUser { get; set; }

        /// <summary>
        /// 解锁用户
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string UnLockUser { get; set; }
    }
}