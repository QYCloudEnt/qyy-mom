using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 工位和人员关系表
    /// </summary>
    [SugarTable("base_workstation_and_user")]
    public class WorkstationAndUser : RootEntity<int>
    {
        /// <summary>
        /// 工位Id
        /// </summary>
        public int WorkstationId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int SysUserId { get; set; }

        /// <summary>
        /// 工位表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(WorkstationId))]
        public Workstation Workstation { get; set; }

        /// <summary>
        /// 用户表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(SysUserId))]
        public SysUser SysUser { get; set; }
    }
}