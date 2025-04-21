using TMom.Domain.Model;
using SqlSugar;
using System.Data;
using System.Linq.Expressions;

namespace TMom.Domain.IRepository
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : RootEntity<TKey>, new() where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// SqlsugarClient实体
        /// </summary>
        ISqlSugarClient Db { get; }

        /// <summary>
        /// 根据Id查询实体
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        Task<TEntity> QueryById(object objId);

        Task<TEntity> QueryById(object objId, bool blnUseCache = false);

        /// <summary>
        /// 根据id数组查询实体list
        /// </summary>
        /// <param name="lstIds"></param>
        /// <returns></returns>
        Task<List<TEntity>> QueryByIDs(object[] lstIds);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns>新增的主键id</returns>
        Task<TKey> Add(TEntity model);

        /// <summary>
        /// 写入实体数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="insertColumns">指定只插入列</param>
        /// <returns>新增的主键id</returns>
        Task<TKey> Add(TEntity entity, Expression<Func<TEntity, object>> insertColumns = null);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="listEntity"></param>
        /// <returns>新增的主键id</returns>
        Task<List<TKey>> Add(List<TEntity> listEntity);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<bool> Any(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="userId">操作用户Id</param>
        /// <returns></returns>
        Task<bool> DeleteSoft(Expression<Func<TEntity, bool>> where, int userId);

        /// <summary>
        /// 根据id 删除某一实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteById(object id);

        /// <summary>
        /// 根据对象，删除某一实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Delete(TEntity model);

        /// <summary>
        /// 根据id数组，删除实体list
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<bool> DeleteByIds(object[] ids);

        /// <summary>
        /// 更新model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Update(TEntity model);

        /// <summary>
        /// 根据model，更新，带where条件
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        Task<bool> Update(TEntity entity, string strWhere);

        Task<bool> Update(List<TEntity> listEntity);

        Task<bool> Update(object operateAnonymousObjects);

        /// <summary>
        /// 按需要部分更新
        /// <para>如：Update(u =>u.Id==1,u =>new User{Name="ok"});</para>
        /// </summary>
        /// <param name="where">更新条件</param>
        /// <param name="entity">更新的字段实体</param>
        Task<bool> Update(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntity>> entity);

        /// <summary>
        /// 根据model更新，指定列，忽略列
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="lstColumns">指定更新的列(可为null)</param>
        /// <param name="lstIgnoreColumns">忽略的列</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        Task<bool> Update(TEntity entity, List<string>? lstColumns = null, List<string>? lstIgnoreColumns = null, string strWhere = "");

        /// <summary>
        /// 更新, 指定列(默认更新列: UpdateId、UpdateTime)
        /// <para>如：Update(entity, x => new { x.Status });</para>
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="columns">指定列(已默认更新列: UpdateId、UpdateTime)</param>
        /// <returns></returns>
        Task<bool> Update(TEntity entity, Expression<Func<TEntity, object>> columns);

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> Query();

        /// <summary>
        /// 带sql where查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        Task<List<TEntity>> Query(string strWhere);

        /// <summary>
        /// 根据表达式查询多条
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression);

        /// <summary>
        /// 导航查询
        /// </summary>
        /// <typeparam name="TInclude"></typeparam>
        /// <param name="include"></param>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        Task<List<TEntity>> QueryIncludes<TInclude>(Expression<Func<TEntity, TInclude>> include, Expression<Func<TEntity, bool>> whereExpression);

        /// <summary>
        /// 导航查询
        /// </summary>
        /// <typeparam name="TInclude1"></typeparam>
        /// <typeparam name="TInclude2"></typeparam>
        /// <param name="include1"></param>
        /// <param name="include2"></param>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        Task<List<TEntity>> QueryIncludes<TInclude1, TInclude2>(Expression<Func<TEntity, TInclude1>> include1
            , Expression<Func<TEntity, TInclude2>> include2, Expression<Func<TEntity, bool>> whereExpression);

        /// <summary>
        /// 根据表达式查询单条
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        Task<TEntity> QuerySingle(Expression<Func<TEntity, bool>> whereExpression);

        /// <summary>
        /// 根据表达式，指定返回对象模型，查询
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<List<TResult>> Query<TResult>(Expression<Func<TEntity, TResult>> expression);

        /// <summary>
        /// 根据表达式，指定返回对象模型，排序，查询
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression"></param>
        /// <param name="whereExpression"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        Task<List<TResult>> Query<TResult>(Expression<Func<TEntity, TResult>> expression, Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds);

        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds);

        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true);

        Task<List<TEntity>> Query(string strWhere, string strOrderByFileds);

        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intTop, string strOrderByFileds);

        Task<List<TEntity>> Query(string strWhere, int intTop, string strOrderByFileds);

        /// <summary>
        /// 根据sql语句查询(未实现分表的查询)
        /// </summary>
        /// <param name="strSql">完整的sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>泛型集合</returns>
        Task<List<TEntity>> QuerySql(string strSql, SugarParameter[] parameters = null);

        /// <summary>
        /// 根据sql语句查询返回DataTable(未实现分表的查询)
        /// </summary>
        /// <param name="strSql">完整的sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>DataTable</returns>
        Task<DataTable> QueryTable(string strSql, SugarParameter[] parameters = null);

        Task<List<TEntity>> Query(
            Expression<Func<TEntity, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds);

        Task<List<TEntity>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds);

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
        Task<PageModel<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex, int intPageSize
            , Expression<Func<TEntity, TEntity>>? selectExpression, Expression<Func<TEntity, object>>? orderbyExpression = null, OrderByType orderByType = OrderByType.Asc);

        /// <summary>
        /// 根据表达式，排序字段，分页查询
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="selectExpression"></param>
        /// <param name="strOrderByFileds">排序字段，如name asc,age desc(排序查询, 不是查询出结果后再排序)，如SELECT * from tbl ORDER BY CreateTime desc LIMIT 0, 10</param>
        /// <returns></returns>
        Task<PageModel<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, Expression<Func<TEntity, TEntity>>? selectExpression = null, string? strOrderByFileds = null);

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
        Task<PageModel<TEntity>> QueryIncludesPage<TInclude>(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20
            , Expression<Func<TEntity, TEntity>>? selectExpression = null, string? stringOrderByFields = null, List<FormattableString>? includeWhereList = null
            , Expression<Func<TEntity, TInclude>>? include = null);

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
        Task<PageModel<TEntity>> QueryIncludesPage<TInclude1, TInclude2>(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20
            , Expression<Func<TEntity, TEntity>>? selectExpression = null, string? stringOrderByFields = null, List<FormattableString> includeWhereList = null, Expression<Func<TEntity, TInclude1>> include1 = null, Expression<Func<TEntity, TInclude2>> include2 = null);

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
        /// <param name="include3">一层导航表3</param>
        /// <returns></returns>
        Task<PageModel<TEntity>> QueryIncludesPage<TInclude1, TInclude2, TInclude3>(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20
            , Expression<Func<TEntity, TEntity>>? selectExpression = null, string? stringOrderByFields = null
            , List<FormattableString> includeWhereList = null
            , Expression<Func<TEntity, TInclude1>> include1 = null, Expression<Func<TEntity, TInclude2>> include2 = null
            , Expression<Func<TEntity, TInclude3>> include3 = null);

        /// <summary>
        /// 分页查询(关联一层级表)
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="intPageIndex">页码（下标0）</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="selectExpression">查询表达式</param>
        /// <param name="orderbyExpression"></param>
        /// <param name="orderByType"></param>
        /// <param name="includeWhereList">导航表查询条件集合</param>
        /// <param name="includes">排序字段，如name asc,age desc</param>
        /// <returns></returns>
        Task<PageModel<TEntity>> QueryIncludesPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20
            , Expression<Func<TEntity, TEntity>>? selectExpression = null, Expression<Func<TEntity, object>>? orderbyExpression = null
            , OrderByType orderByType = OrderByType.Asc, List<FormattableString> includeWhereList = null, params string[] includes);

        /// <summary>
        /// 分页查询(关联一层级表)(弃用)
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="intPageIndex">页码（下标0）</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="selectExpression">查询表达式</param>
        /// <param name="stringOrderByFields">排序字段，如name asc,age desc</param>
        /// <param name="includeWhereList">导航表查询条件集合</param>
        /// <param name="includes">nameof(Equipment.EquipmentType), nameof(Equipment.Supplier), nameof(Equipment.Workshop)</param>
        /// <returns></returns>
        Task<PageModel<TEntity>> QueryIncludesPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20
            , Expression<Func<TEntity, TEntity>>? selectExpression = null, string? stringOrderByFields = null, List<FormattableString> includeWhereList = null
            , params string[] includes);

        /// <summary>
        /// 三表联查
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="joinExpression"></param>
        /// <param name="selectExpression"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        Task<List<TResult>> QueryMuch<T, T2, T3, TResult>(
            Expression<Func<T, T2, T3, object[]>> joinExpression,
            Expression<Func<T, T2, T3, TResult>> selectExpression,
            Expression<Func<T, T2, T3, bool>> whereLambda = null) where T : class, new();

        /// <summary>
        /// 两表联查-分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="joinExpression"></param>
        /// <param name="selectExpression"></param>
        /// <param name="whereExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        Task<PageModel<TResult>> QueryTabsPage<T, T2, TResult>(
            Expression<Func<T, T2, object[]>> joinExpression,
            Expression<Func<T, T2, TResult>> selectExpression,
            Expression<Func<TResult, bool>> whereExpression,
            int intPageIndex = 1,
            int intPageSize = 20,
            string strOrderByFileds = null);

        /// <summary>
        /// 两表联合查询-分页-分组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="joinExpression"></param>
        /// <param name="selectExpression"></param>
        /// <param name="whereExpression"></param>
        /// <param name="groupExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        Task<PageModel<TResult>> QueryTabsPage<T, T2, TResult>(
            Expression<Func<T, T2, object[]>> joinExpression,
            Expression<Func<T, T2, TResult>> selectExpression,
            Expression<Func<TResult, bool>> whereExpression,
            Expression<Func<T, object>> groupExpression,
            int intPageIndex = 1,
            int intPageSize = 20,
            string strOrderByFileds = null);
    }
}