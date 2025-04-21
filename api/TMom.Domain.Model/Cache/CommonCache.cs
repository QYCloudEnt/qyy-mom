using TMom.Domain.Model.Entity;
using TMom.Infrastructure;
using SqlSugar;
using static TMom.Domain.Model.GlobalVars;

namespace TMom.Domain.Model
{
    /// <summary>
    /// 公共缓存类
    /// </summary>
    public static class CommonCache
    {
        private static readonly IRedisRepository _redis = AutofacContainer.Resolve<IRedisRepository>();
        private static readonly ISqlSugarClient _sqlSugarClient = AutofacContainer.Resolve<ISqlSugarClient>();

        /// <summary>
        /// 获取所有缓存的用户列表
        /// </summary>
        /// <returns></returns>
        public static async Task<List<SysUserCacheDto>> GetAllUserWithCache()
        {
            var cacheUsers = await _redis.HashGet<List<SysUserCacheDto>>(RedisGlobalKey.AllUserList, RedisHashField.UserInfo);
            if (cacheUsers != null && cacheUsers.Any()) return cacheUsers;
            var list = await _sqlSugarClient.Queryable<SysUser>()
                                            .Where(x => !x.IsDeleted)
                                            .Select(x => new SysUserCacheDto()
                                            {
                                                id = x.Id,
                                                code = x.LoginAccount,
                                                name = x.RealName,
                                                email = x.Email ?? "",
                                                isSuper = x.IsSuper
                                            })
                                            .ToListAsync();
            await _redis.HashSet(RedisGlobalKey.AllUserList, RedisHashField.UserInfo, list, TimeSpan.FromHours(12));
            return list;
        }
    }
}