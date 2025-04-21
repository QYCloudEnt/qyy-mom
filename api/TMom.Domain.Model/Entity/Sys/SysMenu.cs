using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 系统菜单表
    /// </summary>
    [SugarTable("sys_menu")]
    public class SysMenu : RootEntity<int>
    {
        [SugarColumn(ColumnDescription = "菜单名称")]
        public string MenuName { get; set; }

        [SugarColumn(ColumnDescription = "父菜单Id", IsNullable = true)]
        public int? ParentId { get; set; }

        [SugarColumn(ColumnDescription = "菜单图标", IsNullable = true)]
        public string? Icon { get; set; }

        /// <summary>
        /// 类型, 0:目录  1:页面  2:按钮
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "类型, 0:目录  1:页面  2:按钮", DefaultValue = "0")]
        public int Type { get; set; }

        [SugarColumn(ColumnDescription = "菜单Url(路由router)", IsNullable = true)]
        public string? LinkUrl { get; set; }

        [SugarColumn(ColumnDescription = "前端页面存放路径", IsNullable = true)]
        public string? ViewPath { get; set; }

        [SugarColumn(ColumnDescription = "是否缓存页面 0:不缓存, 1:缓存", DefaultValue = "0")]
        public bool IsKeepAlive { get; set; }

        [SugarColumn(IsNullable = false, ColumnDescription = "是否显示", DefaultValue = "1")]
        public bool IsShow { get; set; } = true;

        /// <summary>
        /// 是否外链
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "是否外链", DefaultValue = "0")]
        public bool IsExternal { get; set; } = false;

        /// <summary>
        /// 是否内嵌
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "是否内嵌", DefaultValue = "0")]
        public bool IsEmbed { get; set; } = false;

        [SugarColumn(ColumnDescription = "排序", DefaultValue = "1")]
        public int OrderSort { get; set; }
    }
}