namespace TMom.Infrastructure
{
    public static class ListHelper
    {
        /// <summary>
        /// 大数据量List分组拆分
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="pagenumber">每组数量, 默认1000</param>
        /// <returns></returns>
        public static Dictionary<int, List<T>> SeperateList<T>(this IList<T> entities, int pagenumber = 1000) where T : class
        {
            Dictionary<int, List<T>> dicList = new Dictionary<int, List<T>>();
            int len = (entities.Count / pagenumber) + 1;
            for (int i = 1; i <= len; i++)
            {
                var curRows = entities.Skip((i - 1) * pagenumber).Take(pagenumber).ToList();
                dicList.Add(i, curRows);
            }
            return dicList;
        }
    }
}