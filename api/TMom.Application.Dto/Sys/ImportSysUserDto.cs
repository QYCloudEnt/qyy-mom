using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;
using System.ComponentModel.DataAnnotations;

namespace TMom.Application.Dto
{
    /// <summary>
    /// 导入用户信息Dto
    /// </summary>
    [ExcelImporter(IsLabelingError = true)]
    public class ImportSysUserDto
    {
        [ImporterHeader(Name = "登录账号", IsAllowRepeat = false)]
        [Required(ErrorMessage = "登录账号不能为空")]
        public string LoginAccount { get; set; }

        [ImporterHeader(Name = "用户名称")]
        [Required(ErrorMessage = "用户名称不能为空")]
        public string RealName { get; set; }

        [ImporterHeader(Name = "性别")]
        [Required(ErrorMessage = "性别不能为空")]
        [ValueMapping("男", 1)]
        [ValueMapping("女", 0)]
        public int Gender { get; set; }

        [ImporterHeader(Name = "手机号")]
        [MaxLength(11, ErrorMessage = "最大长度为11!")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "请输入正确的手机号")]
        public string? PhoneNo { get; set; }

        [ImporterHeader(Name = "邮箱")]
        public string? Email { get; set; }
    }

    public enum GenderEnum
    {
        /// <summary>
        /// 男
        /// </summary>
        Man = 1,

        /// <summary>
        /// 女
        /// </summary>
        Female = 0
    }
}