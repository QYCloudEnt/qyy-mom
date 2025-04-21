using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 工艺路线流程顺序表
    /// </summary>
    public class ProcessRouteSequence : RootEntity<int>
    {
        /// <summary>
        /// 工艺路线表Id
        /// </summary>
        public int ProcessRouteId { get; set; }

        /// <summary>
        /// 工序Id(-1表示开始节点)
        /// </summary>
        public int OperationId { get; set; }

        /// <summary>
        /// 下一道工序Id(-999表示结束节点)
        /// </summary>
        public int NextOperationId { get; set; }

        /// <summary>
        /// 流转状态
        /// </summary>
        [SugarColumn(Length = 10)]
        public string Status { get; set; }

        /// <summary>
        /// 工序表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(OperationId))]
        public ProcessOperation ProcessOperation { get; set; }

        /// <summary>
        /// 工序表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(NextOperationId))]
        public ProcessOperation NextProcessOperation { get; set; }
    }
}