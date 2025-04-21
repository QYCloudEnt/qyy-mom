namespace TMom.Application.Dto
{
    public class AppMenuDto
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public string Icon { get; set; } = "";

        /// <summary>
        /// 图标颜色
        /// </summary>
        public string Color { get; set; } = "";

        public List<AppMenuItem> Items { get; set; } = new List<AppMenuItem>();
    }

    public class AppMenuItem
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public string Icon { get; set; } = "";

        /// <summary>
        /// 图标颜色
        /// </summary>
        public string Color { get; set; } = "";

        /// <summary>
        /// 事件函数
        /// </summary>
        public string FnStr { get; set; } = "";

        /// <summary>
        /// 权限的角色Id集合
        /// </summary>
        public List<int> SysRoleIds { get; set; } = new List<int>();
    }

    public class AppMenuAddParam
    {
        /// <summary>
        /// 类型: card / item
        /// </summary>
        public string Type { get; set; } = "item";

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        public int? ParentId { get; set; }
    }
}