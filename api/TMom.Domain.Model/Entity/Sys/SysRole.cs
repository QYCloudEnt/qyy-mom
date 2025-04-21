using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 系统角色表
    /// </summary>
    [SugarTable("sys_role")]
    public class SysRole : RootEntity<int>
    {
        /// <summary>
        ///
        /// </summary>
        public SysRole()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        public SysRole(string name)
        {
            RoleName = name;
            Description = "";
            CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 角色名
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string RoleName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [SugarColumn(Length = 500, IsNullable = true)]
        public string? Description { get; set; }
    }
}