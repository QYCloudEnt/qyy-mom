using Microsoft.AspNetCore.Http;

namespace TMom.Application.Dto
{
    /// <summary>
    /// 文件上传类
    /// </summary>
    public class UploadFileDto
    {
        /// <summary>
        /// 文件
        /// </summary>
        public IFormFileCollection file { get; set; }

        /// <summary>
        /// 保存文件路径(对象存储中使用)
        /// </summary>
        public string? Path { get; set; }
    }
}