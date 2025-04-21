namespace TMom.Domain.Model
{
    public class roleMenuParam
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 菜单Id集合
        /// </summary>
        public List<int> menus { get; set; }
    }

    public class SysUserCacheDto
    {
        public int id { get; set; }

        public string code { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        /// <summary>
        /// 是否超级管理员
        /// </summary>
        public bool isSuper { get; set; }
    }
}