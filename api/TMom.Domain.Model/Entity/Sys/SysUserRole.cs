using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 用户和角色表
    /// </summary>
    [SugarTable("sys_user_role")]
    public class SysUserRole : RootEntity<int>
    {
        [SugarColumn(ColumnDescription = "系统用户Id", IsNullable = false)]
        public int SysUserId { get; set; }

        [SugarColumn(ColumnDescription = "系统角色Id", IsNullable = false)]
        public int SysRoleId { get; set; }
    }
}