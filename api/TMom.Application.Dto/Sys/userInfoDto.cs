namespace TMom.Application.Dto.Sys
{
    public class userInfoDto
    {
        public int id { get; set; }

        public string? loginAccount { get; set; }

        public string realName { get; set; }

        public string? avatar { get; set; }

        public bool? isSuper { get; set; }

        public int? orgId { get; set; }

        public string phoneNo { get; set; }

        public string? loginIp { get; set; }

        public string email { get; set; }

        public string addr { get; set; }

        public string remark { get; set; }
    }
}