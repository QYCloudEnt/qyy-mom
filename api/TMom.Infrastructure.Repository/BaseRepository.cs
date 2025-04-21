using Microsoft.AspNetCore.Http;
using TMom.Domain.IRepository;
using TMom.Domain.Model;
using TMom.Infrastructure.Helper;
using SqlSugar;
using System.Data;
using System.Linq.Expressions;

namespace TMom.Infrastructure.Repository
{
    /// <summary>
    /// 数据库交互
    ///  添加 TKey 不再限制仅int型
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : RootEntity<TKey>, new() where TKey : IEquatable<TKey>
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 主DB
        /// </summary>
        private SqlSugarScope _dbBase;

        private ISqlSugarClient _db
        {
            get
            {
                return _dbBase;
            }
        }

        // 不要改成SqlSugarScope
        public ISqlSugarClient Db
        {
            get { return _db; }
        }

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbBase = unitOfWork.GetDbClient();
        }

        public async Task<TEntity> QueryById(object objId)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted).In(objId).SplitTable(tbl => tbl).SingleAsync();
            }
            else
            {
                return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted).In(objId).SingleAsync();
            }
        }

        /// <summary>
        /// 功能描述:根据ID查询一条数据
        /// </summary>
        /// <param name="objId">id（必须指定主键特性 [SugarColumn(IsPrimaryKey=true)]），如果是联合主键，请使用Where条件</param>
        /// <param name="blnUseCache">是否使用缓存</param>
        /// <returns>数据实体</returns>
        public async Task<TEntity> QueryById(object objId, bool blnUseCache = false)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted).WithCacheIF(blnUseCache).In(objId).SplitTable(tbl => tbl).SingleAsync();
            }
            else
            {
                return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted).WithCacheIF(blnUseCache).In(objId).SingleAsync();
            }
        }

        /// <summary>
        /// 功能描述:根据ID查询数据
        /// </summary>
        /// <param name="lstIds">id列表（必须指定主键特性 [SugarColumn(IsPrimaryKey=true)]），如果是联合主键，请使用Where条件</param>
        /// <returns>数据实体列表</returns>
        public async Task<List<TEntity>> QueryByIDs(object[] lstIds)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted).In(lstIds).SplitTable(tbl => tbl).ToListAsync();
            }
            else
            {
                return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted).In(lstIds).ToListAsync();
            }
        }

        /// <summary>
        /// 写入实体数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public async Task<TKey> Add(TEntity entity)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return (TKey)(object)await _db.Insertable(entity).SplitTable().ExecuteReturnSnowflakeIdAsync();
            }
            else
            {
                var insert = _db.Insertable(entity);
                var model = await insert.ExecuteReturnEntityAsync();
                return model.Id;
            }
        }

        /// <summary>
        /// 写入实体数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="insertColumns">指定只插入列</param>
        /// <returns>返回自增量列</returns>
        public async Task<TKey> Add(TEntity entity, Expression<Func<TEntity, object>> insertColumns = null)
        {
            if (insertColumns == null) return await Add(entity);
            if (IsSplitTable(typeof(TEntity)))
            {
                return (TKey)(object)await _db.Insertable(entity).InsertColumns(insertColumns).SplitTable().ExecuteReturnSnowflakeIdAsync();
            }
            else
            {
                var insert = _db.Insertable(entity).InsertColumns(insertColumns);
                var model = await insert.ExecuteReturnEntityAsync();
                return model.Id;
            }
        }

        /// <summary>
        /// 批量插入实体(速度快)
        /// </summary>
        /// <param name="listEntity">实体集合</param>
        /// <returns>影响行数</returns>
        public async Task<List<TKey>> Add(List<TEntity> listEntity)
        {
            if (!listEntity.Any()) return default(List<TKey>);
            if (IsSplitTable(typeof(TEntity)))
            {
                var list = await _db.Insertable(listEntity.ToArray()).SplitTable().ExecuteReturnSnowflakeIdListAsync();
                return list as List<TKey>;
            }
            else
            {
                var idList = await _db.Insertable(listEntity.ToArray()).ExecuteReturnPkListAsync<TKey>();
                return idList;
            }
        }

        /// <summary>
        /// 判断实体类是否分表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private bool IsSplitTable(Type type)
        {
            return type.GetCustomAttributes(false).Any(x => x is SplitTableAttribute);
        }

        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> Update(TEntity entity)
        {
            //这种方式会以主键为条件
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Updateable(entity).SplitTable().ExecuteCommandAsync() > 0;
            }
            return await _db.Updateable(entity).ExecuteCommandHasChangeAsync(); // 不要加多余的where条件，加了where以where的条件更新数据
        }

        public async Task<bool> Update(TEntity entity, string strWhere)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Updateable(entity).Where(strWhere).SplitTable().ExecuteCommandAsync() > 0;
            }
            return await _db.Updateable(entity).Where(strWhere).ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> Update(List<TEntity> listEntity)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Updateable(listEntity).SplitTable().ExecuteCommandAsync() > 0;
            }
            return await _db.Updateable(listEntity).ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> Update(object operateAnonymousObjects)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Updateable<TEntity>(operateAnonymousObjects).SplitTable().ExecuteCommandAsync() > 0;
            }
            return await _db.Updateable<TEntity>(operateAnonymousObjects).ExecuteCommandHasChangeAsync();
        }

        /// <summary>
        /// 按需要部分更新
        /// <para>如：Update(u =>u.Id==1,u =>new User{Name="ok"});</para>
        /// </summary>
        /// <param name="where">更新条件</param>
        /// <param name="entity">更新的字段实体</param>
        public async Task<bool> Update(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntity>> entity)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Updateable(entity).Where(where).SplitTable().ExecuteCommandAsync() > 0;
            }
            return await _db.Updateable(entity).Where(where).ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> Update(
          TEntity entity,
          List<string>? lstColumns = null,
          List<string>? lstIgnoreColumns = null,
          string strWhere = ""
            )
        {
            IUpdateable<TEntity> up = _db.Updateable(entity);
            if (lstIgnoreColumns != null && lstIgnoreColumns.Count > 0)
            {
                up = up.IgnoreColumns(lstIgnoreColumns.ToArray());
            }
            if (lstColumns != null && lstColumns.Count > 0)
            {
                up = up.UpdateColumns(lstColumns.ToArray());
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                up = up.Where(strWhere);
            }
            if (IsSplitTable(typeof(TEntity)))
            {
                return await up.SplitTable().ExecuteCommandAsync() > 0;
            }
            return await up.ExecuteCommandHasChangeAsync();
        }

        /// <summary>
        /// 更新某些列(默认更新列: UpdateId、UpdateTime)
        /// <para>如：Update(entity, x => new { x.Status });</para>
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="columns">默认更新列: UpdateId、UpdateTime</param>
        /// <returns></returns>
        public async Task<bool> Update(TEntity entity, Expression<Func<TEntity, object>> columns)
        {
            Expression<Func<TEntity, object>> defCols = x => new { x.UpdateId, x.UpdateTime };
            var up = _db.Updateable(entity)
                        .UpdateColumns(columns)
                        .UpdateColumns(defCols);
            if (IsSplitTable(typeof(TEntity)))
            {
                return await up.SplitTable().ExecuteCommandAsync() > 0;
            }
            return await up.ExecuteCommandHasChangeAsync();
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<bool> Any(Expression<Func<TEntity, bool>> where)
        {
            where = where.And(x => !x.IsDeleted);
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Queryable<TEntity>().Where(where).SplitTable().AnyAsync();
            }
            bool res = await _db.Queryable<TEntity>().AnyAsync(where);
            return res;
        }

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="userId">操作用户Id</param>
        /// <returns></returns>
        public async Task<bool> DeleteSoft(Expression<Func<TEntity, bool>> where, int userId)
        {
            bool res = await Update(where, x => new TEntity() { UpdateId = userId, UpdateTime = DateTime.Now, IsDeleted = true });
            return res;
        }

        /// <summary>
        /// 根据实体删除一条数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public async Task<bool> Delete(TEntity entity)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Deleteable(entity).SplitTable().ExecuteCommandAsync() > 0;
            }
            return await _db.Deleteable(entity).ExecuteCommandHasChangeAsync();
        }

        /// <summary>
        /// 删除指定ID的数据
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public async Task<bool> DeleteById(object id)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Deleteable<TEntity>(id).SplitTable().ExecuteCommandAsync() > 0;
            }
            return await _db.Deleteable<TEntity>(id).ExecuteCommandHasChangeAsync();
        }

        /// <summary>
        /// 删除指定ID集合的数据(批量删除)
        /// </summary>
        /// <param name="ids">主键ID集合</param>
        /// <returns></returns>
        public async Task<bool> DeleteByIds(object[] ids)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Deleteable<TEntity>().In(ids).SplitTable().ExecuteCommandAsync() > 0;
            }
            return await _db.Deleteable<TEntity>().In(ids).ExecuteCommandHasChangeAsync();
        }

        /// <summary>
        /// 功能描述:查询所有数据
        /// </summary>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query()
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                // 性能会差点，因为没有指定具体哪些表
                return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted).SplitTable(tbl => tbl).ToListAsync();
            }
            return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted).ToListAsync();
        }

        /// <summary>
        /// 功能描述:查询数据列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(string strWhere)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted).WhereIF(!string.IsNullOrEmpty(strWhere), strWhere).SplitTable(tbl => tbl).ToListAsync();
            }
            return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted).WhereIF(!string.IsNullOrEmpty(strWhere), strWhere).ToListAsync();
        }

        /// <summary>
        /// 功能描述:查询数据列表
        /// </summary>
        /// <param name="whereExpression">whereExpression</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted).WhereIF(whereExpression != null, whereExpression).SplitTable(tbl => tbl).ToListAsync();
            }
            return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted).WhereIF(whereExpression != null, whereExpression).ToListAsync();
        }

        /// <summary>
        /// 导航查询
        /// </summary>
        /// <typeparam name="TInclude"></typeparam>
        /// <param name="include"></param>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> QueryIncludes<TInclude>(Expression<Func<TEntity, TInclude>> include, Expression<Func<TEntity, bool>> whereExpression)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Queryable<TEntity>()
                    .Includes(include)
                    .Where(x => !x.IsDeleted).WhereIF(whereExpression != null, whereExpression).SplitTable(tbl => tbl).ToListAsync();
            }
            return await _db.Queryable<TEntity>()
                    .Includes(include)
                    .Where(x => !x.IsDeleted).WhereIF(whereExpression != null, whereExpression).ToListAsync();
        }

        /// <summary>
        /// 导航查询
        /// </summary>
        /// <typeparam name="TInclude1"></typeparam>
        /// <typeparam name="TInclude2"></typeparam>
        /// <param name="include1"></param>
        /// <param name="include2"></param>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> QueryIncludes<TInclude1, TInclude2>(Expression<Func<TEntity, TInclude1>> include1
            , Expression<Func<TEntity, TInclude2>> include2, Expression<Func<TEntity, bool>> whereExpression)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Queryable<TEntity>()
                    .Includes(include1)
                    .Includes(include2)
                    .Where(x => !x.IsDeleted).WhereIF(whereExpression != null, whereExpression).SplitTable(tbl => tbl).ToListAsync();
            }
            return await _db.Queryable<TEntity>()
                    .Includes(include1)
                    .Includes(include2)
                    .Where(x => !x.IsDeleted).WhereIF(whereExpression != null, whereExpression).ToListAsync();
        }

        /// <summary>
        /// 查询单条数据
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<TEntity> QuerySingle(Expression<Func<TEntity, bool>> whereExpression)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted).WhereIF(whereExpression != null, whereExpression).SplitTable(tbl => tbl).FirstAsync();
            }
            return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted).WhereIF(whereExpression != null, whereExpression).FirstAsync();
        }

        /// <summary>
        /// 功能描述:按照特定列查询数据列表
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<List<TResult>> Query<TResult>(Expression<Func<TEntity, TResult>> expression)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted).Select(expression).SplitTable(tbl => tbl).ToListAsync();
            }
            return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted).Select(expression).ToListAsync();
        }

        /// <summary>
        /// 功能描述:按照特定列查询数据列表带条件排序
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="whereExpression">过滤条件</param>
        /// <param name="expression">查询实体条件</param>
        /// <param name="strOrderByFileds">排序条件</param>
        /// <returns></returns>
        public async Task<List<TResult>> Query<TResult>(Expression<Func<TEntity, TResult>> expression, Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted)
                                                     .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
                                                     .WhereIF(whereExpression != null, whereExpression)
                                                     .Select(expression)
                                                     .SplitTable(tbl => tbl)
                                                     .ToListAsync();
            }
            return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted)
                                                 .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
                                                 .WhereIF(whereExpression != null, whereExpression)
                                                 .Select(expression)
                                                 .ToListAsync();
        }

        /// <summary>
        /// 功能描述:查询一个列表
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="strOrderByFileds">排序字段，如name asc,age desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted)
                                                     .WhereIF(whereExpression != null, whereExpression)
                                                     .OrderByIF(strOrderByFileds != null, strOrderByFileds)
                                                     .SplitTable(tbl => tbl)
                                                     .ToListAsync();
            }
            return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted)
                                                 .WhereIF(whereExpression != null, whereExpression)
                                                 .OrderByIF(strOrderByFileds != null, strOrderByFileds)
                                                 .ToListAsync();
        }

        /// <summary>
        /// 功能描述:查询一个列表
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted)
                                                     .OrderByIF(orderByExpression != null, orderByExpression, isAsc ? OrderByType.Asc : OrderByType.Desc)
                                                     .WhereIF(whereExpression != null, whereExpression)
                                                     .SplitTable(tbl => tbl)
                                                     .ToListAsync();
            }
            return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted)
                                                 .OrderByIF(orderByExpression != null, orderByExpression, isAsc ? OrderByType.Asc : OrderByType.Desc)
                                                 .WhereIF(whereExpression != null, whereExpression)
                                                 .ToListAsync();
        }

        /// <summary>
        /// 功能描述:查询一个列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="strOrderByFileds">排序字段，如name asc,age desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(string strWhere, string strOrderByFileds)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted)
                                                     .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
                                                     .WhereIF(!string.IsNullOrEmpty(strWhere), strWhere)
                                                     .SplitTable(tbl => tbl)
                                                     .ToListAsync();
            }
            return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted)
                                                 .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
                                                 .WhereIF(!string.IsNullOrEmpty(strWhere), strWhere)
                                                 .ToListAsync();
        }

        /// <summary>
        /// 功能描述:查询前N条数据
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="intTop">前N条</param>
        /// <param name="strOrderByFileds">排序字段，如name asc,age desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intTop, string strOrderByFileds)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted)
                                                     .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
                                                     .WhereIF(whereExpression != null, whereExpression)
                                                     .Take(intTop)
                                                     .SplitTable(tbl => tbl)
                                                     .ToListAsync();
            }
            return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted)
                                                 .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
                                                 .WhereIF(whereExpression != null, whereExpression)
                                                 .Take(intTop)
                                                 .ToListAsync();
        }

        /// <summary>
        /// 功能描述:查询前N条数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="intTop">前N条</param>
        /// <param name="strOrderByFileds">排序字段，如name asc,age desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(string strWhere, int intTop, string strOrderByFileds)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted)
                                                     .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
                                                     .WhereIF(!string.IsNullOrEmpty(strWhere), strWhere)
                                                     .Take(intTop)
                                                     .SplitTable(tbl => tbl)
                                                     .ToListAsync();
            }
            return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted)
                                                 .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
                                                 .WhereIF(!string.IsNullOrEmpty(strWhere), strWhere)
                                                 .Take(intTop)
                                                 .ToListAsync();
        }

        /// <summary>
        /// 根据sql语句查询(未实现分表的查询)
        /// </summary>
        /// <param name="strSql">完整的sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>泛型集合</returns>
        public async Task<List<TEntity>> QuerySql(string strSql, SugarParameter[] parameters = null)
        {
            return await _db.Ado.SqlQueryAsync<TEntity>(strSql, parameters);
        }

        /// <summary>
        /// 根据sql语句查询返回DataTable(未实现分表的查询)
        /// </summary>
        /// <param name="strSql">完整的sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>DataTable</returns>
        public async Task<DataTable> QueryTable(string strSql, SugarParameter[] parameters = null)
        {
            return await _db.Ado.GetDataTableAsync(strSql, parameters);
        }

        /// <summary>
        /// 功能描述:分页查询
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="intPageIndex">页码（下标0）</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="strOrderByFileds">排序字段，如name asc,age desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(
            Expression<Func<TEntity, bool>> whereExpression,
            int intPageIndex,
            int intPageSize,
            string strOrderByFileds)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted)
                                                     .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
                                                     .WhereIF(whereExpression != null, whereExpression)
                                                     .SplitTable(tbl => tbl)
                                                     .ToPageListAsync(intPageIndex, intPageSize);
            }
            return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted)
                                                 .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
                                                 .WhereIF(whereExpression != null, whereExpression)
                                                 .ToPageListAsync(intPageIndex, intPageSize);
        }

        /// <summary>
        /// 功能描述:分页查询
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="intPageIndex">页码（下标0）</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="strOrderByFileds">排序字段，如name asc,age desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(
          string strWhere,
          int intPageIndex,
          int intPageSize,

          string strOrderByFileds)
        {
            if (IsSplitTable(typeof(TEntity)))
            {
                return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted)
                                                     .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
                                                     .WhereIF(!string.IsNullOrEmpty(strWhere), strWhere)
                                                     .SplitTable(tbl => tbl)
                                                     .ToPageListAsync(intPageIndex, intPageSize);
            }
            return await _db.Queryable<TEntity>().Where(x => !x.IsDeleted)
                                                 .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
                                                 .WhereIF(!string.IsNullOrEmpty(strWhere), strWhere)
                                                 .ToPageListAsync(intPageIndex, intPageSize);
        }

        //public async Task<PageModel<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, Expression<Func<TEntity, TEntity>> selectExpression = null, string strOrderByFileds = null)
        //{
        //    if (selectExpression == null) return await QueryPage(whereExpression, intPageIndex, intPageSize, strOrderByFileds);

        //    RefAsync<int> totalCount = 0;
        //    var list = await _db.Queryable<TEntity>()
        //                        .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
        //                        .Where(x => !x.IsDeleted)
        //                        .WhereIF(whereExpression != null, whereExpression)
        //                        .Select(selectExpression)
        //                        .ToPageListAsync(intPageIndex, intPageSize, totalCount);
        //}

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="intPageIndex">页码（下标0）</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="selectExpression">查询表达式</param>
        /// <param name="orderbyExpression">排序表达式</param>
        /// <param name="orderByType">排序规则</param>
        /// <returns></returns>
        public async Task<PageModel<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20
            , Expression<Func<TEntity, TEntity>>? selectExpression = null, Expression<Func<TEntity, object>>? orderbyExpression = null, OrderByType orderByType = OrderByType.Asc)
        {
            RefAsync<int> totalCount = 0;
            var list = new List<TEntity>();

            //1、 分页有 OrderBy写 SplitTable 后面 ,uinon all后在排序
            //2、 Where尽量写到 SplitTable 前面，先过滤在union all

            #region 构建表达式

            if (selectExpression == null)
            {
                if (IsSplitTable(typeof(TEntity)))
                {
                    list = await _db.Queryable<TEntity>()
                                    .Where(x => !x.IsDeleted)
                                    .WhereIF(whereExpression != null, whereExpression)
                                    .SplitTable(tbl => tbl)
                                    .OrderByIF(orderbyExpression != null, orderbyExpression, orderByType)
                                    .ToPageListAsync(intPageIndex, intPageSize, totalCount)
                                    .RenderUserInfoList();
                }
                else
                {
                    list = await _db.Queryable<TEntity>()
                                    .Where(x => !x.IsDeleted)
                                    .WhereIF(whereExpression != null, whereExpression)
                                    .OrderByIF(orderbyExpression != null, orderbyExpression, orderByType)
                                    .ToPageListAsync(intPageIndex, intPageSize, totalCount)
                                    .RenderUserInfoList();
                }
            }
            else
            {
                if (IsSplitTable(typeof(TEntity)))
                {
                    list = await _db.Queryable<TEntity>()
                                    .Where(x => !x.IsDeleted)
                                    .WhereIF(whereExpression != null, whereExpression)
                                    .Select(selectExpression)
                                    .SplitTable(tbl => tbl)
                                    .OrderByIF(orderbyExpression != null, orderbyExpression, orderByType)
                                    .ToPageListAsync(intPageIndex, intPageSize, totalCount)
                                    .RenderUserInfoList();
                }
                else
                {
                    list = await _db.Queryable<TEntity>()
                                    .Where(x => !x.IsDeleted)
                                    .WhereIF(whereExpression != null, whereExpression)
                                    .Select(selectExpression)
                                    .OrderByIF(orderbyExpression != null, orderbyExpression, orderByType)
                                    .ToPageListAsync(intPageIndex, intPageSize, totalCount)
                                    .RenderUserInfoList();
                }
            }

            #endregion 构建表达式

            return new PageModel<TEntity>() { pagination = new pageInfo() { total = totalCount, pageIndex = intPageIndex, pageSize = intPageSize }, list = list };
        }

        /// <summary>
        /// 分页查询[使用版本，其他分页未测试]
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="intPageIndex">页码（下标0）</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="selectExpression">查询表达式</param>
        /// <param name="strOrderByFileds">排序字段，如name asc,age desc</param>
        /// <returns></returns>
        public async Task<PageModel<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, Expression<Func<TEntity, TEntity>>? selectExpression = null, string? strOrderByFileds = null)
        {
            // 不要随意改动表达式中的变量: x、s、u

            #region old

            //RenderFullTableName(_dbBase, out string databaseTableName);
            //RefAsync<int> totalCount = 0;
            //var list = await _db.Queryable<TEntity>()
            // .LeftJoin(_db.Queryable<SysUser>().AS(databaseTableName).Select(s => new { Id = s.Id, LoginAccount = s.LoginAccount, RealName = s.RealName }), (x, s) => x.CreateId == s.Id)
            // .LeftJoin(_db.Queryable<SysUser>().AS(databaseTableName).Select(u => new { Id = u.Id, LoginAccount = u.LoginAccount, RealName = u.RealName }), (x, s, u) => x.UpdateId == u.Id)
            // //.Includes(x => x.CreateUserTable).AS<SysUser>("mom_dev.sysuser")
            // //.Includes(x => x.UpdateUserTable).AS<SysUser>("mom_dev.sysuser")
            // .Where(x => !x.IsDeleted)
            // .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
            // .WhereIF(whereExpression != null, whereExpression)
            // .Select((x, s, u) => new TEntity
            // {
            //     Id = x.Id.SelectAll(),
            //     CreateCode = s.LoginAccount,
            //     CreateUser = s.RealName,
            //     UpdateCode = u.LoginAccount,
            //     UpdateUser = u.RealName
            // })
            // .Mapper(x =>
            // {
            //     x.CreateUser = $"({x.CreateCode}){x.CreateUser}";
            //     x.UpdateUser = !string.IsNullOrEmpty(x.UpdateCode) ? $"({x.UpdateCode}){x.UpdateUser}" : null;
            // })
            // .ToPageListAsync(intPageIndex, intPageSize, totalCount);

            #endregion old

            RefAsync<int> totalCount = 0;
            var list = new List<TEntity>();

            //1、 分页有 OrderBy写 SplitTable 后面 ,uinon all后在排序
            //2、 Where尽量写到 SplitTable 前面，先过滤在union all

            #region 构建表达式

            if (selectExpression == null)
            {
                if (IsSplitTable(typeof(TEntity)))
                {
                    list = await _db.Queryable<TEntity>()
                                    .Where(x => !x.IsDeleted)
                                    .WhereIF(whereExpression != null, whereExpression)
                                    .SplitTable(tbl => tbl)
                                    .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
                                    .ToPageListAsync(intPageIndex, intPageSize, totalCount)
                                    .RenderUserInfoList();
                }
                else
                {
                    list = await _db.Queryable<TEntity>()
                                    .Where(x => !x.IsDeleted)
                                    .WhereIF(whereExpression != null, whereExpression)
                                    .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
                                    .ToPageListAsync(intPageIndex, intPageSize, totalCount)
                                    .RenderUserInfoList();
                }
            }
            else
            {
                if (IsSplitTable(typeof(TEntity)))
                {
                    list = await _db.Queryable<TEntity>()
                                    .Where(x => !x.IsDeleted)
                                    .WhereIF(whereExpression != null, whereExpression)
                                    .Select(selectExpression)
                                    .SplitTable(tbl => tbl)
                                    .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
                                    .ToPageListAsync(intPageIndex, intPageSize, totalCount)
                                    .RenderUserInfoList();
                }
                else
                {
                    list = await _db.Queryable<TEntity>()
                                    .Where(x => !x.IsDeleted)
                                    .WhereIF(whereExpression != null, whereExpression)
                                    .Select(selectExpression)
                                    .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
                                    .ToPageListAsync(intPageIndex, intPageSize, totalCount)
                                    .RenderUserInfoList();
                }
            }

            #endregion 构建表达式

            return new PageModel<TEntity>() { pagination = new pageInfo() { total = totalCount, pageIndex = intPageIndex, pageSize = intPageSize }, list = list };
        }

        /// <summary>
        /// 分页查询(关联一层级表)
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="selectExpression">查询表达式</param>
        /// <param name="stringOrderByFields">排序字段，如name asc,age desc</param>
        /// <param name="includeWhereList">导航表条件集合</param>
        /// <param name="include">一层导航表</param>
        /// <returns></returns>
        public async Task<PageModel<TEntity>> QueryIncludesPage<TInclude>(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20
            , Expression<Func<TEntity, TEntity>>? selectExpression = null, string? stringOrderByFields = null, List<FormattableString>? includeWhereList = null,
            Expression<Func<TEntity, TInclude>>? include = null)
        {
            var iQueryable = _db.Queryable<TEntity>()
                                .Includes(include)
                                .Where(x => !x.IsDeleted)
                                .Where(whereExpression);

            return await CommonQueryIncludes(iQueryable, intPageIndex, intPageSize, selectExpression, stringOrderByFields, includeWhereList);
        }

        /// <summary>
        /// 分页查询(关联一层级表)
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="selectExpression">查询表达式</param>
        /// <param name="stringOrderByFields">排序字段，如name asc,age desc</param>
        /// <param name="includeWhereList">导航表查询条件集合</param>
        /// <param name="include1">一层导航表1</param>
        /// <param name="include2">一层导航表2</param>
        /// <returns></returns>
        public async Task<PageModel<TEntity>> QueryIncludesPage<TInclude1, TInclude2>(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20
            , Expression<Func<TEntity, TEntity>>? selectExpression = null, string? stringOrderByFields = null, List<FormattableString> includeWhereList = null, Expression<Func<TEntity, TInclude1>> include1 = null, Expression<Func<TEntity, TInclude2>> include2 = null)
        {
            var iQueryable = _db.Queryable<TEntity>()
                                .Includes(include1)
                                .Includes(include2)
                                .Where(x => !x.IsDeleted)
                                .Where(whereExpression);
            return await CommonQueryIncludes(iQueryable, intPageIndex, intPageSize, selectExpression, stringOrderByFields, includeWhereList);
        }

        /// <summary>
        /// 分页查询(关联一层级表)
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="selectExpression">查询表达式</param>
        /// <param name="stringOrderByFields">排序字段，如name asc,age desc</param>
        /// <param name="includeWhereList">导航表条件集合</param>
        /// <param name="include1">一层导航表1</param>
        /// <param name="include2">一层导航表2</param>
        /// <param name="include3">一层导航表3</param>
        /// <returns></returns>
        public async Task<PageModel<TEntity>> QueryIncludesPage<TInclude1, TInclude2, TInclude3>(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20
            , Expression<Func<TEntity, TEntity>>? selectExpression = null, string? stringOrderByFields = null, List<FormattableString> includeWhereList = null
            , Expression<Func<TEntity, TInclude1>> include1 = null, Expression<Func<TEntity, TInclude2>> include2 = null
            , Expression<Func<TEntity, TInclude3>> include3 = null)
        {
            var iQueryable = _db.Queryable<TEntity>()
                                .Includes(include1)
                                .Includes(include2)
                                .Includes(include3)
                                .Where(x => !x.IsDeleted)
                                .Where(whereExpression);
            return await CommonQueryIncludes(iQueryable, intPageIndex, intPageSize, selectExpression, stringOrderByFields, includeWhereList);
        }

        private async Task<PageModel<TEntity>> CommonQueryIncludes(ISugarQueryable<TEntity> iQueryable, int intPageIndex = 1, int intPageSize = 20,
            Expression<Func<TEntity, TEntity>>? selectExpression = null, string? stringOrderByFields = null, List<FormattableString> includeWhereList = null)
        {
            RefAsync<int> totalCount = 0;
            var list = new List<TEntity>();

            if (includeWhereList != null)
            {
                foreach (var where in includeWhereList)
                {
                    iQueryable = iQueryable.Where("x", where); // Where("x", $"x => x.sourceMaterial.code=={"001"}")
                }
            }

            #region 构建表达式

            if (selectExpression == null)
            {
                if (IsSplitTable(typeof(TEntity)))
                {
                    iQueryable = iQueryable.SplitTable(tbl => tbl);
                }
            }
            else
            {
                if (IsSplitTable(typeof(TEntity)))
                {
                    iQueryable = iQueryable.Select(selectExpression).SplitTable(tbl => tbl);
                }
                else
                {
                    iQueryable = iQueryable.Select(selectExpression);
                }
            }

            #endregion 构建表达式

            list = await iQueryable.OrderByIF(!string.IsNullOrWhiteSpace(stringOrderByFields), stringOrderByFields)
                                   .ToPageListAsync(intPageIndex, intPageSize, totalCount)
                                   .RenderUserInfoList();

            return new PageModel<TEntity>() { pagination = new pageInfo() { total = totalCount, pageIndex = intPageIndex, pageSize = intPageSize }, list = list };
        }

        /// <summary>
        /// 分页查询(关联一层级表)
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="intPageIndex">页码（下标0）</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="selectExpression">查询表达式</param>
        /// <param name="orderbyExpression"></param>
        /// <param name="orderByType"></param>
        /// <param name="includeWhereList">导航表条件集合</param>
        /// <param name="includes">排序字段，如name asc,age desc</param>
        /// <returns></returns>
        public async Task<PageModel<TEntity>> QueryIncludesPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20
            , Expression<Func<TEntity, TEntity>>? selectExpression = null, Expression<Func<TEntity, object>>? orderbyExpression = null
            , OrderByType orderByType = OrderByType.Asc, List<FormattableString> includeWhereList = null, params string[] includes)
        {
            RefAsync<int> totalCount = 0;
            var list = new List<TEntity>();

            var iQueryable = _db.Queryable<TEntity>();
            foreach (var navTable in includes)
            {
                iQueryable = iQueryable.IncludesByNameString(navTable);
            }
            iQueryable = iQueryable.Where(x => !x.IsDeleted).WhereIF(whereExpression != null, whereExpression);

            if (includeWhereList != null)
            {
                foreach (var where in includeWhereList)
                {
                    iQueryable = iQueryable.Where("x", where); // Where("x", $"x => x.sourceMaterial.code=={"001"}")
                }
            }

            //1、 分页有 OrderBy写 SplitTable 后面 ,uinon all后在排序
            //2、 Where尽量写到 SplitTable 前面，先过滤在union all

            #region 构建表达式

            if (selectExpression == null)
            {
                if (IsSplitTable(typeof(TEntity)))
                {
                    iQueryable = iQueryable.SplitTable(tbl => tbl);
                }
            }
            else
            {
                if (IsSplitTable(typeof(TEntity)))
                {
                    iQueryable = iQueryable.Select(selectExpression).SplitTable(tbl => tbl);
                }
                else
                {
                    iQueryable = iQueryable.Select(selectExpression);
                }
            }

            #endregion 构建表达式

            list = await iQueryable.OrderByIF(orderbyExpression != null, orderbyExpression, orderByType)
                                   .ToPageListAsync(intPageIndex, intPageSize, totalCount)
                                   .RenderUserInfoList();

            return new PageModel<TEntity>() { pagination = new pageInfo() { total = totalCount, pageIndex = intPageIndex, pageSize = intPageSize }, list = list };
        }

        /// <summary>
        /// 分页查询(关联一层级表)
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="intPageIndex">页码（下标0）</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="selectExpression">查询表达式</param>
        /// <param name="stringOrderByFields">排序字段，如name asc,age desc</param>
        /// <param name="includeWhereList">导航表条件集合</param>
        /// <param name="includes">nameof(Equipment.EquipmentType), nameof(Equipment.Supplier), nameof(Equipment.Workshop)</param>
        /// <returns></returns>
        public async Task<PageModel<TEntity>> QueryIncludesPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20
            , Expression<Func<TEntity, TEntity>>? selectExpression = null, string? stringOrderByFields = null, List<FormattableString> includeWhereList = null
            , params string[] includes)
        {
            RefAsync<int> totalCount = 0;
            var list = new List<TEntity>();

            var iQueryable = _db.Queryable<TEntity>();
            foreach (var navTable in includes)
            {
                iQueryable = iQueryable.IncludesByNameString(navTable);
            }
            iQueryable = iQueryable.Where(x => !x.IsDeleted).WhereIF(whereExpression != null, whereExpression);

            if (includeWhereList != null)
            {
                foreach (var where in includeWhereList)
                {
                    iQueryable = iQueryable.Where("x", where); // Where("x", $"x => x.sourceMaterial.code=={"001"}")
                }
            }

            //1、 分页有 OrderBy写 SplitTable 后面 ,uinon all后在排序
            //2、 Where尽量写到 SplitTable 前面，先过滤在union all

            #region 构建表达式

            if (selectExpression == null)
            {
                if (IsSplitTable(typeof(TEntity)))
                {
                    iQueryable = iQueryable.SplitTable(tbl => tbl);
                }
            }
            else
            {
                if (IsSplitTable(typeof(TEntity)))
                {
                    iQueryable = iQueryable.Select(selectExpression).SplitTable(tbl => tbl);
                }
                else
                {
                    iQueryable = iQueryable.Select(selectExpression);
                }
            }

            #endregion 构建表达式

            list = await iQueryable.OrderByIF(!string.IsNullOrWhiteSpace(stringOrderByFields), stringOrderByFields)
                                   .ToPageListAsync(intPageIndex, intPageSize, totalCount)
                                   .RenderUserInfoList();

            return new PageModel<TEntity>() { pagination = new pageInfo() { total = totalCount, pageIndex = intPageIndex, pageSize = intPageSize }, list = list };
        }

        /// <summary>
        ///查询-多表查询(不支持分表的查询)
        /// </summary>
        /// <typeparam name="T">实体1</typeparam>
        /// <typeparam name="T2">实体2</typeparam>
        /// <typeparam name="T3">实体3</typeparam>
        /// <typeparam name="TResult">返回对象</typeparam>
        /// <param name="joinExpression">关联表达式 (join1,join2) => new object[] {JoinType.Left,join1.UserNo==join2.UserNo}</param>
        /// <param name="selectExpression">返回表达式 (s1, s2) => new { Id =s1.UserNo, Id1 = s2.UserNo}</param>
        /// <param name="whereLambda">查询表达式 (w1, w2) =>w1.UserNo == "")</param>
        /// <returns>值</returns>
        public async Task<List<TResult>> QueryMuch<T, T2, T3, TResult>(
            Expression<Func<T, T2, T3, object[]>> joinExpression,
            Expression<Func<T, T2, T3, TResult>> selectExpression,
            Expression<Func<T, T2, T3, bool>> whereLambda = null) where T : class, new()
        {
            if (whereLambda == null)
            {
                return await _db.Queryable(joinExpression).Select(selectExpression).ToListAsync();
            }
            else
            {
                return await _db.Queryable(joinExpression).Where(whereLambda).Select(selectExpression).ToListAsync();
            }
        }

        /// <summary>
        /// 两表联合查询-分页(不支持分表的查询)
        /// </summary>
        /// <typeparam name="T">实体1</typeparam>
        /// <typeparam name="T2">实体1</typeparam>
        /// <typeparam name="TResult">返回对象</typeparam>
        /// <param name="joinExpression">关联表达式</param>
        /// <param name="selectExpression">返回表达式</param>
        /// <param name="whereExpression">查询表达式</param>
        /// <param name="intPageIndex">页码</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="strOrderByFileds">排序字段</param>
        /// <returns></returns>
        public async Task<PageModel<TResult>> QueryTabsPage<T, T2, TResult>(
            Expression<Func<T, T2, object[]>> joinExpression,
            Expression<Func<T, T2, TResult>> selectExpression,
            Expression<Func<TResult, bool>> whereExpression,
            int intPageIndex = 1,
            int intPageSize = 20,
            string strOrderByFileds = null)
        {
            RefAsync<int> totalCount = 0;
            var list = await _db.Queryable<T, T2>(joinExpression)
             .Select(selectExpression)
             .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
             .WhereIF(whereExpression != null, whereExpression)
             .ToPageListAsync(intPageIndex, intPageSize, totalCount);
            return new PageModel<TResult>() { pagination = new pageInfo() { total = totalCount, pageIndex = intPageIndex, pageSize = intPageSize }, list = list };
        }

        /// <summary>
        /// 两表联合查询-分页-分组(不支持分表的查询)
        /// </summary>
        /// <typeparam name="T">实体1</typeparam>
        /// <typeparam name="T2">实体1</typeparam>
        /// <typeparam name="TResult">返回对象</typeparam>
        /// <param name="joinExpression">关联表达式</param>
        /// <param name="selectExpression">返回表达式</param>
        /// <param name="whereExpression">查询表达式</param>
        /// <param name="intPageIndex">页码</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="strOrderByFileds">排序字段</param>
        /// <returns></returns>
        public async Task<PageModel<TResult>> QueryTabsPage<T, T2, TResult>(
            Expression<Func<T, T2, object[]>> joinExpression,
            Expression<Func<T, T2, TResult>> selectExpression,
            Expression<Func<TResult, bool>> whereExpression,
            Expression<Func<T, object>> groupExpression,
            int intPageIndex = 1,
            int intPageSize = 20,
            string strOrderByFileds = null)
        {
            RefAsync<int> totalCount = 0;
            var list = await _db.Queryable<T, T2>(joinExpression).GroupBy(groupExpression)
             .Select(selectExpression)
             .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds)
             .WhereIF(whereExpression != null, whereExpression)
             .ToPageListAsync(intPageIndex, intPageSize, totalCount);
            //int pageCount = (Math.Ceiling(totalCount.ObjToDecimal() / intPageSize.ObjToDecimal())).ObjToInt();
            return new PageModel<TResult>() { pagination = new pageInfo() { total = totalCount, pageIndex = intPageIndex, pageSize = intPageSize }, list = list };
        }

        //var exp = Expressionable.Create<ProjectToUser>()
        //        .And(s => s.tdIsDelete != true)
        //        .And(p => p.IsDeleted != true)
        //        .And(p => p.pmId != null)
        //        .AndIF(!string.IsNullOrEmpty(model.paramCode1), (s) => s.uID == model.paramCode1.ObjToInt())
        //                .AndIF(!string.IsNullOrEmpty(model.searchText), (s) => (s.groupName != null && s.groupName.Contains(model.searchText))
        //                        || (s.jobName != null && s.jobName.Contains(model.searchText))
        //                        || (s.uRealName != null && s.uRealName.Contains(model.searchText)))
        //                .ToExpression();//拼接表达式
        //var data = await _projectMemberServices.QueryTabsPage<sysUserInfo, ProjectMember, ProjectToUser>(
        //    (s, p) => new object[] { JoinType.Left, s.uID == p.uId },
        //    (s, p) => new ProjectToUser
        //    {
        //        uID = s.uID,
        //        uRealName = s.uRealName,
        //        groupName = s.groupName,
        //        jobName = s.jobName
        //    }, exp, s => new { s.uID, s.uRealName, s.groupName, s.jobName }, model.currentPage, model.pageSize, model.orderField + " " + model.orderType);
    }
}