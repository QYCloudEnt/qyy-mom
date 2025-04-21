namespace TMom.Application.Dto
{
    public class FileResponseDto
    {
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类型: dir / file
        /// </summary>
        public TypeEnum Type { get; set; }

        /// <summary>
        /// 文件格式
        /// </summary>
        public string? MimeType { get; set; }

        /// <summary>
        /// 储存大小
        /// </summary>
        public ulong Fsize { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? PutTime { get; set; }
    }

    public enum TypeEnum
    {
        dir,
        file
    }

    public class RenameParam
    {
        public TypeEnum type { get; set; }

        /// <summary>
        /// 新名称
        /// </summary>
        public string toName { get; set; }

        public string name { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string path { get; set; }
    }

    public class MkdirParam
    {
        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 文件夹名称
        /// </summary>
        public string DirName { get; set; }
    }

    public class DelFileOrDirParams
    {
        public string Path { get; set; }

        public List<DelFileDto> Files { get; set; } = new List<DelFileDto>();
    }

    public class DelFileDto
    {
        public DelFileTypeEnum Type { get; set; }

        public string Name { get; set; }
    }

    public enum DelFileTypeEnum
    {
        dir,
        file
    }
}