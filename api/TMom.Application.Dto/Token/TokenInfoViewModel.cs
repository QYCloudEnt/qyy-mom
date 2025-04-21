namespace TMom.Application.Dto
{
    public class TokenInfoViewModel
    {
        public bool success { get; set; }
        public string token { get; set; }
        public double expires_in { get; set; }
        public string token_type { get; set; }

        public long expires_timestamp { get; set; }
    }

    public class UserInfo
    {
        public int uId { get; set; }
        public string userName { get; set; }
        public string realName { get; set; }
        public string avatar { get; set; }
    }
}