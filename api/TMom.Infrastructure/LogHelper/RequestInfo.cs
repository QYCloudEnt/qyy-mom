namespace TMom.Infrastructure.LogHelper
{
    public class ApiWeek
    {
        public string week { get; set; }
        public string url { get; set; }
        public int count { get; set; }
    }

    public class ApiDate
    {
        public string date { get; set; }
        public int count { get; set; }
    }

    public class ActiveUserVM
    {
        public string user { get; set; }
        public int count { get; set; }
    }

    public class RequestApiWeekView
    {
        public List<string> columns { get; set; }
        public string rows { get; set; }
    }

    public class AccessApiDateView
    {
        public string[] columns { get; set; }
        public List<ApiDate> rows { get; set; }
    }

    public class RequestInfo
    {
        public string Ip { get; set; }
        public string Url { get; set; }
        public string Datetime { get; set; }
        public string Date { get; set; }
        public string Week { get; set; }
    }

    public class UserAccessModel
    {
        public string User { get; set; }
        public string IP { get; set; }
        public string API { get; set; }
        public string BeginTime { get; set; }
        public string OPTime { get; set; }
        public string RequestMethod { get; set; }
        public string RequestData { get; set; }

        public string ResponseData { get; set; }
        public string Agent { get; set; }
    }
}