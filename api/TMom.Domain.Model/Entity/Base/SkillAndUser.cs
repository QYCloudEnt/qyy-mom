using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 技能和用户关系表
    /// </summary>
    [SugarTable("base_skill_and_user")]
    public class SkillAndUser : RootEntity<int>
    {
        /// <summary>
        /// 技能Id
        /// </summary>
        public int SkillId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int SysUserId { get; set; }

        /// <summary>
        /// 技能表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(SkillId))]
        public Skill Skill { get; set; }

        /// <summary>
        /// 用户表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(SysUserId))]
        public SysUser SysUser { get; set; }
    }
}