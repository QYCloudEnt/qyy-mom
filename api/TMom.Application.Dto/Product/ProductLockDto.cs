using TMom.Domain.Model;

namespace TMom.Application.Dto
{
    public class LockDto
    {
        public List<ProductLockDto> Datas { get; set; }

        public string Reason { get; set; }
    }

    public class ProductLockDto
    {
        /// <summary>
        /// 业务对象id
        /// </summary>
        public int BusinessId { get; set; }

        public ProductLockType Type { get; set; }

        public string Code { get; set; }
        public int? OperationId { get; set; }

        public string Operation { get; set; }

        public string LockTime { get; set; }
    }

    public class ProductLockParam
    {
        public ProductLockType Type { get; set; }

        public List<string> Codes { get; set; } = new List<string>();

        public int? OperationId { get; set; }

        public DateTime? TimeS { get; set; }

        public DateTime? TimeE { get; set; }
    }

    public class SplitWorkOrderParams
    {
        /// <summary>
        /// 源工单Id
        /// </summary>
        public int SourceId { get; set; }

        /// <summary>
        /// 拆分数量
        /// </summary>
        public int SplitQty { get; set; }

        /// <summary>
        /// 产线Id
        /// </summary>
        public int LineId { get; set; }

        /// <summary>
        /// 计划开始时间
        /// </summary>
        public DateTime PlanDateS { get; set; }

        /// <summary>
        /// 计划结束时间
        /// </summary>
        public DateTime PlanDateE { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}