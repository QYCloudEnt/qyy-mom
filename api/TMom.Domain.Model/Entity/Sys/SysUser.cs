using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 系统用户表
    /// </summary>
    [SugarTable("sys_user")]
    [Tenant("maindb")]
    public class SysUser : RootEntity<int>
    {
        /// <summary>
        /// 登录账号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "登录账号")]
        public string LoginAccount { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [SugarColumn(ColumnDescription = "密码")]
        public string? Password { get; set; }

        /// <summary>
        /// 真实名
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "真实名")]
        public string RealName { get; set; }

        /// <summary>
        /// 是否超级管理员
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "是否超级管理员", DefaultValue = "0")]
        public bool IsSuper { get; set; } = false;

        /// <summary>
        /// 是否可用
        /// </summary>
        [SugarColumn(ColumnDescription = "是否可用", IsNullable = false, DefaultValue = "1")]
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// 头像
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDescription = "头像")]
        public string? Avatar { get; set; }

        /// <summary>
        /// 登录Ip
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDescription = "登录Ip")]
        public string? Ip { get; set; }

        /// <summary>
        /// 组织Id
        /// </summary>
        [SugarColumn(ColumnDescription = "组织Id", IsNullable = true)]
        public int? OrgId { get; set; }

        /// <summary>
        /// 组织架构表
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(OrgId))]
        [SugarColumn(IsIgnore = true)]
        public SysOrg? SysOrg { get; set; }

        /// <summary>
        /// 性别 1：男，0：女
        /// </summary>
        [SugarColumn(ColumnDescription = "性别 1:男, 0:女", DefaultValue = "1")]
        public int Gender { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDescription = "手机号", Length = 11)]
        public string? PhoneNo { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDescription = "邮箱", Length = 30)]
        public string? Email { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string? Addr { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string? Remark { get; set; }

        /*********** 忽略的列 ***********/

        /// <summary>
        /// 组织架构名称
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string? OrgName { get; set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<int> SysRoleIds { get; set; }
    }
}