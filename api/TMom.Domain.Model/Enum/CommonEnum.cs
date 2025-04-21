namespace TMom.Domain.Model
{
    /// <summary>
    /// 主数据群组类型
    /// </summary>
    public enum PartGroupType
    {
        /// <summary>
        /// 物料
        /// </summary>
        Material,

        /// <summary>
        /// 产品
        /// </summary>
        Product,

        /// <summary>
        /// 工装
        /// </summary>
        Frock,
    }

    /// <summary>
    /// 工单状态
    /// </summary>
    public enum WorkOrderStatusEnum
    {
        /// <summary>
        /// 初始化
        /// </summary>
        Initial,

        /// <summary>
        /// 备料中
        /// </summary>
        PrepMaterial,

        /// <summary>
        /// 备料完成
        /// </summary>
        PrepMaterialComplete,

        /// <summary>
        /// 已开工
        /// </summary>
        Open,

        /// <summary>
        /// 暂停
        /// </summary>
        Pending,

        /// <summary>
        /// 完工
        /// </summary>
        Complete,

        /// <summary>
        /// 结案
        /// </summary>
        Close,
    }

    /// <summary>
    /// 工单来源
    /// </summary>
    public enum WorkOrderFromEnum
    {
        /// <summary>
        /// Erp
        /// </summary>
        Erp,

        /// <summary>
        /// Mes
        /// </summary>
        Mes,
    }

    /// <summary>
    /// 产品锁定类型
    /// </summary>
    public enum ProductLockType
    {
        /// <summary>
        /// 主数据
        /// </summary>
        Part,

        /// <summary>
        /// 工单
        /// </summary>
        WorkOrder,
    }

    /// <summary>
    /// 产品锁定状态
    /// </summary>
    public enum LockStatus
    {
        /// <summary>
        /// 锁定
        /// </summary>
        Lock,

        /// <summary>
        /// 解锁
        /// </summary>
        UnLock,
    }

    /// <summary>
    /// 测试模式
    /// </summary>
    public enum TestModeEnum
    {
        A,
        AA,
        AAA,
        AB,
        AAB,
        ABC
    }

    /// <summary>
    /// 发布状态枚举
    /// </summary>
    public enum PublishStatusEnum
    {
        /// <summary>
        /// 未发布
        /// </summary>
        UnPublish,

        /// <summary>
        /// 已发布
        /// </summary>
        Published
    }
}