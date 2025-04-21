using TMom.Domain.Model;
using SqlSugar;
using System.Data;
using System.Linq.Expressions;

namespace TMom.Application
{
    public interface IBaseService<TEntity, TKey> where TEntity : RootEntity<TKey>, new() where TKey : IEquatable<TKey>
    {
        Task<TEntity> QueryById(object objId);

        Task<TEntity> QueryById(object objId, bool blnUseCache = false);

        Task<List<TEntity>> QueryByIDs(object[] lstIds);

        Task<TKey> Add(TEntity model);

        /// <summary>
        /// 写入实体数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="insertColumns">指定只插入列</param>
        /// <returns></returns>
        Task<TKey> Add(TEntity entity, Expression<Func<TEntity, object>> insertColumns = null);

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

        Task<bool> DeleteById(object id);

        Task<bool> Delete(TEntity model);

        Task<bool> DeleteByIds(object[] ids);

        Task<bool> Update(TEntity model);

        Task<bool> Update(TEntity entity, string strWhere);

        Task<bool> Update(object operateAnonymousObjects);

        Task<bool> Update(List<TEntity> entities);

        /// <summary>
        /// 按需要部分更新
        /// <para>如：Update(u =>u.Id==1,u =>new User{Name="ok"});</para>
        /// </summary>
        /// <param name="where">更新条件</param>
        /// <param name="entity">更新的字段实体</param>
        Task<bool> Update(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntity>> entity);

        /// <summary>
        /// 更新数据, 可指定列、忽略列
        /// <para>如：Update(entity, null, IgnoreColList); 忽略IgnoreColList中的列</para>
        /// </summary>
        /// <param name="entity">表实体</param>
        /// <param name="lstColumns">更新的列, null：更新所有</param>
        /// <param name="lstIgnoreColumns">忽略的列</param>
        /// <param name="strWhere"></param>
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

        Task<List<TEntity>> Query();

        Task<List<TEntity>> Query(string strWhere);

        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression);

        /// <summary>
        /// 查询单条数据
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        Task<TEntity> QuerySingle(Expression<Func<TEntity, bool>> whereExpression);

        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds);

        /// <summary>
        /// 查询某些列的数据
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selectExpression"></param>
        /// <returns></returns>
        Task<List<TResult>> Query<TResult>(Expression<Func<TEntity, TResult>> selectExpression);

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

        Task<List<TResult>> Query<TResult>(Expression<Func<TEntity, TResult>> expression, Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds);

        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true);

        Task<List<TEntity>> Query(string strWhere, string strOrderByFileds);

        Task<List<TEntity>> QuerySql(string strSql, SugarParameter[] parameters = null);

        Task<DataTable> QueryTable(string strSql, SugarParameter[] parameters = null);

        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intTop, string strOrderByFileds);

        Task<List<TEntity>> Query(string strWhere, int intTop, string strOrderByFileds);

        Task<List<TEntity>> Query(
            Expression<Func<TEntity, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds);

        Task<List<TEntity>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="pageIndex">页码（下标0）</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="selectExpression">查询表达式</param>
        /// <param name="orderbyExpression">排序表达式</param>
        /// <param name="orderByType">排序规则</param>
        /// <returns></returns>
        Task<PageModel<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression,
            int pageIndex, int pageSize, Expression<Func<TEntity, TEntity>>? selectExpression, Expression<Func<TEntity, object>>? orderbyExpression = null, OrderByType orderByType = OrderByType.Asc);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="whereExpression">条件</param>
        /// <param name="intPageIndex">页下标</param>
        /// <param name="intPageSize">每页数量</param>
        /// <param name="selectExpression">查询字段</param>
        /// <param name="orderByFileds">排序字段，如name asc,age desc(排序查询, 不是查询出结果后再排序)，如SELECT * from tbl ORDER BY CreateTime desc LIMIT 0, 10</param>
        /// <returns></returns>
        Task<PageModel<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, Expression<Func<TEntity, TEntity>>? selectExpression = null, string? orderByFileds = null);

        /// <summary>
        /// 分页查询(关联一层级表)
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="includes">一层导航表</param>
        /// <returns></returns>
        //Task<PageModel<TEntity>> QueryIncludesPage<TInclude>(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20
        //    , params Expression<Func<TEntity, TInclude>>[] includes);

        /// <summary>
        /// 分页查询(关联一层级表)
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="include1">一层导航表1</param>
        /// <param name="include2">一层导航表2</param>
        /// <returns></returns>
        //Task<PageModel<TEntity>> QueryIncludesPage<TInclude1, TInclude2>(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20
        //    , Expression<Func<TEntity, TInclude1>> include1 = null, Expression<Func<TEntity, TInclude1>> include2 = null);

        /// <summary>
        /// 分页查询(关联一层级表)
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="selectExpression">查询表达式</param>
        /// <param name="stringOrderByFields">排序字段，如name asc,age desc</param>
        /// <param name="includeWhereList">导航表查询条件集合</param>
        /// <param name="include">一层导航表</param>
        /// <returns></returns>
        Task<PageModel<TEntity>> QueryIncludesPage<TInclude>(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20
            , Expression<Func<TEntity, TEntity>>? selectExpression = null, string? stringOrderByFields = null
            , List<FormattableString> includeWhereList = null
            , Expression<Func<TEntity, TInclude>> include = null);

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
        /// 分页查询(关联一层级表)
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
            , Expression<Func<TEntity, TEntity>>? selectExpression = null, string? stringOrderByFields = null
            , List<FormattableString> includeWhereList = null
            , params string[] includes);

        Task<List<TResult>> QueryMuch<T, T2, T3, TResult>(
            Expression<Func<T, T2, T3, object[]>> joinExpression,
            Expression<Func<T, T2, T3, TResult>> selectExpression,
            Expression<Func<T, T2, T3, bool>> whereLambda = null) where T : class, new();

        Task<PageModel<TEntity>> QueryPage(PaginationModel pagination);
    }
}