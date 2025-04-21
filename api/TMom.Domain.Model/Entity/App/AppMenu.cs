using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// APP菜单表
    /// </summary>
    
    [SugarTable("app_menu")]
    public class AppMenu : RootEntity<int>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父菜单id
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string Icon { get; set; } = "";

        /// <summary>
        /// 图标颜色(为空则默认跟随系统主题色)
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string IconColor { get; set; } = "";

        /// <summary>
        /// 函数体(单击事件)
        /// </summary>
        public string FnStr { get; set; } = "";

        /// <summary>
        /// 权限的角色Id集合
        /// </summary>
        public string SysRoleIds { get; set; } = "";

        /// <summary>
        /// 排序
        /// </summary>
        public int SortNo { get; set; } = 0;
    }
}