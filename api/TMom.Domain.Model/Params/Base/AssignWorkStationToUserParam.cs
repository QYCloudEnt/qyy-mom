namespace TMom.Domain.Model.Params
{
    public class AssignWorkStationToUserParam
    {
        /// <summary>
        /// 工位id
        /// </summary>
        public int workStationId { get; set; }

        /// <summary>
        /// 用户id集合
        /// </summary>
        public List<int> sysUserIds { get; set; }
    }

    public class AssignSkillToUserParam
    {
        /// <summary>
        /// 技能id
        /// </summary>
        public int skillId { get; set; }

        /// <summary>
        /// 用户id集合
        /// </summary>
        public List<int> sysUserIds { get; set; }
    }

    public class AssignTemplateToUserParam
    {
        /// <summary>
        /// 模板id
        /// </summary>
        public int templateId { get; set; }

        /// <summary>
        /// 用户id集合
        /// </summary>
        public List<int> sysUserIds { get; set; }
    }
}