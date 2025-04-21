namespace TMom.Domain.Model
{
    /// <summary>
    /// 渲染用户信息
    /// </summary>
    public static class RenderUser
    {
        /// <summary>
        /// 渲染数据源中的用户信息(用于前端分页表格)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataList"></param>
        /// <returns></returns>
        public static async Task<List<T>> RenderUserInfoList<T>(this Task<List<T>> dataList) where T : RootField
        {
            var list = await dataList;
            var userList = await CommonCache.GetAllUserWithCache();
            if (userList != null && userList.Any())
            {
                var _list = (from e in list
                             join a in userList on e.CreateId equals a.id into aJoin
                             join u in userList on e.UpdateId equals u.id into uJoin
                             from a2 in aJoin.DefaultIfEmpty()
                             from u2 in uJoin.DefaultIfEmpty()
                             select new
                             {
                                 e,
                                 createUser = a2 == null ? null : $"({a2.code}){a2.name}",
                                 updateUser = u2 == null ? null : $"({u2.code}){u2.name}",
                             }).ToList();
                list = _list.Select(x =>
                {
                    x.e.CreateUser = x.createUser;
                    x.e.UpdateUser = x.updateUser;
                    return x.e;
                }).ToList();
            }
            return list;
        }
    }
}