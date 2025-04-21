using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace TMom.Infrastructure
{
    public class RedisRepository : IRedisRepository
    {
        private readonly ILogger<RedisRepository> _logger;
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _database;
        private readonly string _instanceName = Appsettings.app(["Redis", "InstanceName"]);

        public RedisRepository(ILogger<RedisRepository> logger, ConnectionMultiplexer redis)
        {
            _logger = logger;
            _redis = redis;
            _database = redis.GetDatabase();
        }

        /// <summary>
        /// 统一处理key前缀
        /// </summary>
        /// <param name="key"></param>
        /// <returns>格式: 当前项目配置的实例:key</returns>
        private string RenderKeyPrefix(string key)
        {
            if (key.StartsWith($"{_instanceName}:")) return key;
            return $"{_instanceName}:{key}";
        }

        private IServer GetServer()
        {
            var endpoint = _redis.GetEndPoints();
            return _redis.GetServer(endpoint.First());
        }

        /// <summary>
        /// redisDb
        /// </summary>
        public IDatabase Db => _database;

        /// <summary>
        /// pub/sub
        /// </summary>
        /// <returns></returns>
        public ISubscriber GetSubscriber() => _redis.GetSubscriber();

        public async Task Clear()
        {
            foreach (var endPoint in _redis.GetEndPoints())
            {
                var server = GetServer();
                foreach (var key in server.Keys())
                {
                    await _database.KeyDeleteAsync(key);
                }
            }
        }

        public async Task<bool> Exist(string key)
        {
            key = RenderKeyPrefix(key);
            return await _database.KeyExistsAsync(key);
        }

        public async Task<string> GetValue(string key)
        {
            key = RenderKeyPrefix(key);
            return await _database.StringGetAsync(key);
        }

        public async Task Remove(string key)
        {
            key = RenderKeyPrefix(key);
            await _database.KeyDeleteAsync(key);
        }

        /// <summary>
        /// 重命名key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="newKey"></param>
        /// <returns></returns>
        public async Task KeyRename(string key, string newKey)
        {
            key = RenderKeyPrefix(key);
            newKey = RenderKeyPrefix(newKey);
            await _database.KeyRenameAsync(key, newKey);
        }

        public async Task Set(string key, object value, TimeSpan cacheTime)
        {
            if (value != null)
            {
                key = RenderKeyPrefix(key);
                if (value is string cacheValue)
                {
                    // 字符串无需序列化
                    await _database.StringSetAsync(key, cacheValue, cacheTime);
                }
                else
                {
                    //序列化，将object值生成RedisValue
                    await _database.StringSetAsync(key, SerializeHelper.Serialize(value), cacheTime);
                }
            }
        }

        public async Task<TEntity> Get<TEntity>(string key)
        {
            key = RenderKeyPrefix(key);
            var value = await _database.StringGetAsync(key);
            if (value.HasValue)
            {
                //需要用的反序列化，将Redis存储的Byte[]，进行反序列化
                return SerializeHelper.Deserialize<TEntity>(value);
            }
            else
            {
                return default(TEntity);
            }
        }

        public async Task<TEntity> HashGet<TEntity>(string key, string field)
        {
            key = RenderKeyPrefix(key);
            var value = await _database.HashGetAsync(key, field);
            if (value.HasValue)
            {
                return SerializeHelper.Deserialize<TEntity>(value);
            }
            else
            {
                return default(TEntity);
            }
        }

        public async Task HashSet<TEntity>(string key, string field, TEntity value, TimeSpan? span = null, When when = When.Always, CommandFlags flags = CommandFlags.None)
        {
            key = RenderKeyPrefix(key);
            await _database.HashSetAsync(key, field, SerializeHelper.Serialize(value), when, flags);
            if (span == null) return;
            string script = "redis.call('EXPIRE', @key, @expire)";
            var prepared = LuaScript.Prepare(script);
            await _database.ScriptEvaluateAsync(prepared, new
            {
                key,
                expire = span.Value.TotalSeconds
            }, flags);
        }

        public async Task HashDelete(string key, string field)
        {
            key = RenderKeyPrefix(key);
            await _database.HashDeleteAsync(key, field);
        }

        public async Task<bool> HashExist(string key, string field)
        {
            key = RenderKeyPrefix(key);
            return await _database.HashExistsAsync(key, field);
        }

        /// <summary>
        /// 根据key模糊匹配
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public async Task<RedisResult> GetByPatternAsync(string pattern)
        {
            pattern = RenderKeyPrefix(pattern);
            return await _database.ScriptEvaluateAsync(LuaScript.Prepare(
                " local res = redis.call('KEYS', @keypattern) " +
                " return res "), new { @keypattern = pattern });
        }

        /// <summary>
        /// 根据key获取RedisValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public async Task<RedisValue[]> ListRangeAsync(string redisKey)
        {
            redisKey = RenderKeyPrefix(redisKey);
            return await _database.ListRangeAsync(redisKey);
        }

        /// <summary>
        /// 在列表头部插入值。如果键不存在，先创建再插入值
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <returns></returns>
        public async Task<long> ListLeftPushAsync(string redisKey, string redisValue, int db = -1)
        {
            redisKey = RenderKeyPrefix(redisKey);
            return await _database.ListLeftPushAsync(redisKey, redisValue);
        }

        /// <summary>
        /// 在列表尾部插入值。如果键不存在，先创建再插入值
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <returns></returns>
        public async Task<long> ListRightPushAsync(string redisKey, string redisValue, int db = -1)
        {
            redisKey = RenderKeyPrefix(redisKey);
            return await _database.ListRightPushAsync(redisKey, redisValue);
        }

        /// <summary>
        /// 在列表尾部插入数组集合。如果键不存在，先创建再插入值
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="redisValue"></param>
        /// <returns></returns>
        public async Task<long> ListRightPushAsync(string redisKey, IEnumerable<string> redisValue, int db = -1)
        {
            redisKey = RenderKeyPrefix(redisKey);
            var redislist = new List<RedisValue>();
            foreach (var item in redisValue)
            {
                redislist.Add(item);
            }
            return await _database.ListRightPushAsync(redisKey, redislist.ToArray());
        }

        /// <summary>
        /// 移除并返回存储在该键列表的第一个元素  反序列化
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public async Task<T> ListLeftPopAsync<T>(string redisKey, int db = -1) where T : class
        {
            redisKey = RenderKeyPrefix(redisKey);
            return JsonConvert.DeserializeObject<T>(await _database.ListLeftPopAsync(redisKey));
        }

        /// <summary>
        /// 移除并返回存储在该键列表的最后一个元素   反序列化
        /// 只能是对象集合
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public async Task<T> ListRightPopAsync<T>(string redisKey, int db = -1) where T : class
        {
            redisKey = RenderKeyPrefix(redisKey);
            return JsonConvert.DeserializeObject<T>(await _database.ListRightPopAsync(redisKey));
        }

        /// <summary>
        /// 移除并返回存储在该键列表的第一个元素
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public async Task<string> ListLeftPopAsync(string redisKey, int db = -1)
        {
            redisKey = RenderKeyPrefix(redisKey);
            return await _database.ListLeftPopAsync(redisKey);
        }

        /// <summary>
        /// 移除并返回存储在该键列表的最后一个元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public async Task<string> ListRightPopAsync(string redisKey, int db = -1)
        {
            redisKey = RenderKeyPrefix(redisKey);
            return await _database.ListRightPopAsync(redisKey);
        }

        /// <summary>
        /// 列表长度
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public async Task<long> ListLengthAsync(string redisKey, int db = -1)
        {
            redisKey = RenderKeyPrefix(redisKey);
            return await _database.ListLengthAsync(redisKey);
        }

        /// <summary>
        /// 返回在该列表上键所对应的元素
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> ListRangeAsync(string redisKey, int db = -1)
        {
            redisKey = RenderKeyPrefix(redisKey);
            var result = await _database.ListRangeAsync(redisKey);
            return result.Select(o => o.ToString());
        }

        /// <summary>
        /// 根据索引获取指定位置数据
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> ListRangeAsync(string redisKey, int start, int stop, int db = -1)
        {
            redisKey = RenderKeyPrefix(redisKey);
            var result = await _database.ListRangeAsync(redisKey, start, stop);
            return result.Select(o => o.ToString());
        }

        /// <summary>
        /// 删除List中的元素 并返回删除的个数
        /// </summary>
        /// <param name="redisKey">key</param>
        /// <param name="redisValue">元素</param>
        /// <param name="type">大于零 : 从表头开始向表尾搜索，小于零 : 从表尾开始向表头搜索，等于零：移除表中所有与 VALUE 相等的值</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public async Task<long> ListDelRangeAsync(string redisKey, string redisValue, long type = 0, int db = -1)
        {
            redisKey = RenderKeyPrefix(redisKey);
            return await _database.ListRemoveAsync(redisKey, redisValue, type);
        }

        /// <summary>
        /// 清空List
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="db"></param>
        public async Task ListClearAsync(string redisKey, int db = -1)
        {
            redisKey = RenderKeyPrefix(redisKey);
            await _database.ListTrimAsync(redisKey, 1, 0);
        }
    }
}