using SapNwRfc;

namespace TMom.Application.Dto
{
    public class Sap_WorkOrder_Result
    {
        [SapName("GT_OUT")]
        public WorkOrderResultItem[] WorkOrderResultItems { get; set; }
    }

    public class WorkOrderResultItem
    {
        /// <summary>
        /// 工厂代码
        /// </summary>
        [SapName("WERKS")]
        public string FactoryCode { get; set; }

        /// <summary>
        /// 单号
        /// </summary>
        [SapName("AUFNR")]
        public string Code { get; set; }

        /// <summary>
        /// 计划号
        /// </summary>
        [SapName("ZJHH")]
        public string PlanNo { get; set; }

        /// <summary>
        /// 工单类型
        /// </summary>
        [SapName("AUART")]
        public string SAPType { get; set; }

        /// <summary>
        /// 主件编码
        /// </summary>
        [SapName("MATNR1")]
        public string ProductNo { get; set; }

        /// <summary>
        /// 工单数量
        /// </summary>
        [SapName("GAMNG")]
        public int Plan_Qty { get; set; }

        /// <summary>
        /// 制程段
        /// </summary>
        [SapName("DISPO")]
        public string Section { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        [SapName("GSTRP")]
        public string Sch_Start_Date { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        [SapName("GLTRP")]
        public string Sch_End_Date { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [SapName("GSUZP")]
        public TimeSpan? Sch_Start_Time { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [SapName("GLUZP")]
        public TimeSpan? Sch_End_Time { get; set; }

        [SapName("STTXT")]
        public string SAPStatus { get; set; }

        //SAPVersion

        [SapName("STLAL")]
        public string BomVersion { get; set; }

        [SapName("ZXM")]
        public string ProjectNo { get; set; }

        [SapName("ZXT")]
        public string Line { get; set; }

        [SapName("ZBANCI")]
        public string Shift { get; set; }

        /// <summary>
        /// 子件编号
        /// </summary>
        [SapName("MATNR")]
        public string PartNo { get; set; }

        /// <summary>
        /// 子件基本单位
        /// </summary>
        [SapName("MEINS")]
        public string Basic_Unit { get; set; }

        /// <summary>
        /// 物料描述
        /// </summary>
        [SapName("MATXT")]
        public string MaterialDescription { get; set; }

        /// <summary>
        /// 物料行项目
        /// </summary>
        [SapName("RSPOS")]
        public string ItemNo { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SapName("BDMNG")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// 反冲
        /// </summary>
        [SapName("RGEKZ")]
        public string Recoil { get; set; }

        /// <summary>
        /// 项目已删除
        /// </summary>
        [SapName("XLOEK")]
        public string Deleted { get; set; }

        /// <summary>
        /// 替代组
        /// </summary>
        [SapName("ALPGR")]
        public string AltGroup { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        [SapName("ALPRF")]
        public int AltPriority { get; set; }

        /// <summary>
        /// 策略（判定模式）
        /// </summary>
        [SapName("ALPST")]
        public string ALPST { get; set; }

        /// <summary>
        /// 使用可能性百分比
        /// </summary>
        [SapName("EWAHR")]
        public decimal UsePercent { get; set; }

        /// <summary>
        /// 已领料数量
        /// </summary>
        [SapName("ENMNG")]
        public decimal PickedQty { get; set; }

        /// <summary>
        /// 未发货数量
        /// </summary>
        [SapName("VMENG")]
        public decimal UnPickedQty { get; set; }
    }
}