namespace TMom.Application.Dto.Sys
{
    public class PermMenuDto
    {
        public List<MenuTree> menus { get; set; }

        public List<string?> perms { get; set; }
    }

    public class Menu
    {
        public int id { get; set; }
        public int? parentId { get; set; }
        public string name { get; set; }
        public string? router { get; set; }
        public string? perms { get; set; }

        /// <summary>
        /// 0:目录   1:菜单   2:权限
        /// </summary>
        public int type { get; set; }

        public string? icon { get; set; }
        public int orderNum { get; set; }
        public string? viewPath { get; set; }
        public bool keepalive { get; set; }
        public bool isShow { get; set; }

        /// <summary>
        /// 是否外链
        /// </summary>
        public bool isExternal { get; set; } = false;

        /// <summary>
        /// 是否内嵌
        /// </summary>
        public bool isEmbed { get; set; } = false;

        /// <summary>
        /// 外链true时，路由名称
        /// </summary>
        public string? externalRouteName { get; set; }

        /// <summary>
        /// 外链Url
        /// </summary>
        public string? externalUrl { get; set; }
    }

    public class MenuTree
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        /// <summary>
        /// 重定向路径(children中第一个元素的path)
        /// </summary>
        public string? Redirect { get; set; }

        public string Component { get; set; }

        public MenuMeta Meta { get; set; }

        public List<MenuTree> Children;
    }

    public class MenuMeta
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 类型, 0: 目录, 1: 菜单, 2: 权限
        /// </summary>
        public int Type { get; set; }

        public bool Show { get; set; }

        public string Icon { get; set; }

        public int OrderNo { get; set; }

        /// <summary>
        /// 是否缓存
        /// </summary>
        public bool KeepAlive { get; set; }

        /// <summary>
        /// 是否外部链接
        /// </summary>
        public bool IsExt { get; set; }

        /// <summary>
        /// 外链打开方式, 1: 新窗口打开  2: 内嵌 iframe
        /// </summary>
        public int ExtOpenMode { get; set; }

        /// <summary>
        /// 内嵌的iframe对应的路由
        /// </summary>
        public string? FrameRoute { get; set; }

        /// <summary>
        /// 设置当前路由高亮的菜单项，值为route fullPath或route name,一般用于详情页
        /// </summary>
        public string? ActiveMenu { get; set; }

        /// <summary>
        /// 不在菜单中显示(详情页)
        /// </summary>
        public bool HideInMenu { get; set; } = false;
    }
}