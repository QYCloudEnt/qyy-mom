using System.Globalization;

namespace TMom.Infrastructure.Helper
{
    public static class DateHelper
    {
        public static DateTime StampToDateTime(string time)
        {
            time = time.Substring(0, 10);
            double timestamp = Convert.ToInt64(time);
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddSeconds(timestamp).ToLocalTime();
            return dateTime;
        }

        public static string TimeSubTract(DateTime time1, DateTime time2)
        {
            TimeSpan subTract = time1.Subtract(time2);
            return $"{subTract.Days} 天 {subTract.Hours} 时 {subTract.Minutes} 分 ";
        }

        /// <summary>
        ///  时间戳转本地时间-时间戳精确到秒
        /// </summary>
        public static DateTime ToLocalTimeDateBySeconds(long unix)
        {
            var dto = DateTimeOffset.FromUnixTimeSeconds(unix);
            return dto.ToLocalTime().DateTime;
        }

        /// <summary>
        ///  时间转时间戳Unix-时间戳精确到秒
        /// </summary>
        public static long ToUnixTimestampBySeconds(DateTime dt)
        {
            DateTimeOffset dto = new DateTimeOffset(dt);
            return dto.ToUnixTimeSeconds();
        }

        /// <summary>
        ///  时间戳转本地时间-时间戳精确到毫秒
        /// </summary>
        public static DateTime ToLocalTimeDateByMilliseconds(long unix)
        {
            var dto = DateTimeOffset.FromUnixTimeMilliseconds(unix);
            return dto.ToLocalTime().DateTime;
        }

        /// <summary>
        ///  时间转时间戳Unix-时间戳精确到毫秒
        /// </summary>
        public static long ToUnixTimestampByMilliseconds(this DateTime dt)
        {
            DateTimeOffset dto = new DateTimeOffset(dt);
            return dto.ToUnixTimeMilliseconds();
        }

        /// <summary>
        /// 获取当前时间是一年中的第几周(中文周: 周一 ~ 周日)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>eg: 2023-32</returns>
        public static string ToYearWeekByZh(this DateTime dt)
        {
            // 创建一个GregorianCalendar对象
            Calendar calendar = new GregorianCalendar();

            // 计算当前是一年中的第几周
            int weekOfYear = calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return $"{dt.Year}-{weekOfYear}";
        }

        /// <summary>
        /// 获取当前时间是一年中的第几周(英文周: 周日 ~ 周六)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>eg: 2023-32</returns>
        public static string ToYearWeekByEn(this DateTime dt)
        {
            // 创建一个GregorianCalendar对象
            Calendar calendar = new GregorianCalendar();

            // 计算当前是一年中的第几周
            int weekOfYear = calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstFullWeek, DayOfWeek.Sunday);
            return $"{dt.Year}-{weekOfYear}";
        }

        /// <summary>
        /// 判断两个时间段是否有交集(开始日期可以和结束日期相同)
        /// </summary>
        /// <param name="start1"></param>
        /// <param name="end1"></param>
        /// <param name="start2"></param>
        /// <param name="end2"></param>
        /// <returns></returns>
        public static bool IsDatePeriodOverlap(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            // 如果第一个时间段的结束时间小于第二个时间段的开始时间，则无交集
            if (end1.Date <= start2.Date)
            {
                return false;
            }
            // 如果第二个时间段的结束时间小于第一个时间段的开始时间，则无交集
            else if (end2.Date <= start1.Date)
            {
                return false;
            }
            return true;
        }
    }
}