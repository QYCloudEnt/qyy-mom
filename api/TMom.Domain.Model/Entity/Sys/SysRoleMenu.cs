using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 角色和菜单关系表
    /// </summary>
    [SugarTable("sys_role_menu")]
    public class SysRoleMenu : RootEntity<int>
    {
        public SysRoleMenu()
        {
        }

        /// <summary>
        /// 系统角色Id
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int SysRoleId { get; set; }

        /// <summary>
        /// 系统菜单Id
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int SysMenuId { get; set; }

        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(SysRoleId))]
        public SysRole SysRole { get; set; }

        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(SysMenuId))]
        public SysMenu SysMenu { get; set; }
    }
}