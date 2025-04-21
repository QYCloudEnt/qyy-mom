using TMom.Domain.IRepository;
using TMom.Domain.Model;
using TMom.Infrastructure.Helper;
using SqlSugar;
using System.Data;
using System.Linq.Expressions;

namespace TMom.Application.Service
{
    public class BaseService<TEntity, TKey> : IBaseService<TEntity, TKey> where TEntity : RootEntity<TKey>, new() where TKey : IEquatable<TKey>
    {
        public IBaseRepository<TEntity, TKey> BaseRepo { get; set; }//通过在子类的构造函数中注入，这里是基类，不用构造函数

        public async Task<TEntity> QueryById(object objId)
        {
            return await BaseRepo.QueryById(objId);
        }

        /// <summary>
        /// 功能描述:根据ID查询一条数据
        /// 作　　者:TMom
        /// </summary>
        /// <param name="objId">id（必须指定主键特性 [SugarColumn(IsPrimaryKey=true)]），如果是联合主键，请使用Where条件</param>
        /// <param name="blnUseCache">是否使用缓存</param>
        /// <returns>数据实体</returns>
        public async Task<TEntity> QueryById(object objId, bool blnUseCache = false)
        {
            return await BaseRepo.QueryById(objId, blnUseCache);
        }

        /// <summary>
        /// 功能描述:根据ID查询数据
        /// 作　　者:TMom
        /// </summary>
        /// <param name="lstIds">id列表（必须指定主键特性 [SugarColumn(IsPrimaryKey=true)]），如果是联合主键，请使用Where条件</param>
        /// <returns>数据实体列表</returns>
        public async Task<List<TEntity>> QueryByIDs(object[] lstIds)
        {
            return await BaseRepo.QueryByIDs(lstIds);
        }

        /// <summary>
        /// 写入实体数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public async Task<TKey> Add(TEntity entity)
        {
            return await BaseRepo.Add(entity);
        }

        /// <summary>
        /// 写入实体数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="insertColumns">指定只插入列</param>
        /// <returns></returns>
        public async Task<TKey> Add(TEntity entity, Expression<Func<TEntity, object>> insertColumns = null)
        {
            return await BaseRepo.Add(entity, insertColumns);
        }

        /// <summary>
        /// 批量插入实体(速度快)
        /// </summary>
        /// <param name="listEntity">实体集合</param>
        /// <returns>影响行数</returns>
        public async Task<List<TKey>> Add(List<TEntity> listEntity)
        {
            return await BaseRepo.Add(listEntity);
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<bool> Any(Expression<Func<TEntity, bool>> where)
        {
            return await BaseRepo.Any(where);
        }

        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public async Task<bool> Update(TEntity entity)
        {
            return await BaseRepo.Update(entity);
        }

        public async Task<bool> Update(TEntity entity, string strWhere)
        {
            return await BaseRepo.Update(entity, strWhere);
        }

        public async Task<bool> Update(object operateAnonymousObjects)
        {
            return await BaseRepo.Update(operateAnonymousObjects);
        }

        public async Task<bool> Update(List<TEntity> entities)
        {
            return await BaseRepo.Update(entities);
        }

        /// <summary>
        /// 按需要部分更新
        /// <para>如：Update(u =>u.Id==1,u =>new User{Name="ok"});</para>
        /// </summary>
        /// <param name="where">更新条件</param>
        /// <param name="entity">更新的字段实体</param>
        public async Task<bool> Update(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntity>> entity)
        {
            return await BaseRepo.Update(where, entity);
        }

        /// <summary>
        /// 更新数据, 可指定列、忽略列
        /// <para>如：Update(entity, null, IgnoreColList); 忽略IgnoreColList中的列</para>
        /// </summary>
        /// <param name="entity">表实体</param>
        /// <param name="lstColumns">更新的列, null：更新所有</param>
        /// <param name="lstIgnoreColumns">忽略的列</param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public async Task<bool> Update(
         TEntity entity,
         List<string>? lstColumns = null,
         List<string>? lstIgnoreColumns = null,
         string strWhere = ""
            )
        {
            return await BaseRepo.Update(entity, lstColumns, lstIgnoreColumns, strWhere);
        }

        /// <summary>
        /// 更新, 指定列(默认更新列: UpdateId、UpdateTime)
        /// <para>如：Update(entity, x => new { x.Status });</para>
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="columns">指定列(已默认更新列: UpdateId、UpdateTime)</param>
        /// <returns></returns>
        public async Task<bool> Update(TEntity entity, Expression<Func<TEntity, object>> columns)
        {
            return await BaseRepo.Update(entity, columns);
        }

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="userId">操作用户Id</param>
        /// <returns></returns>
        public async Task<bool> DeleteSoft(Expression<Func<TEntity, bool>> where, int userId)
        {
            return await BaseRepo.DeleteSoft(where, userId);
        }

        /// <summary>
        /// 根据实体删除一条数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public async Task<bool> Delete(TEntity entity)
        {
            return await BaseRepo.Delete(entity);
        }

        /// <summary>
        /// 删除指定ID的数据
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public async Task<bool> DeleteById(object id)
        {
            return await BaseRepo.DeleteById(id);
        }

        /// <summary>
        /// 删除指定ID集合的数据(批量删除)
        /// </summary>
        /// <param name="ids">主键ID集合</param>
        /// <returns></returns>
        public async Task<bool> DeleteByIds(object[] ids)
        {
            return await BaseRepo.DeleteByIds(ids);
        }

        /// <summary>
        /// 功能描述:查询所有数据
        /// 作　　者:TMom
        /// </summary>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query()
        {
            return await BaseRepo.Query();
        }

        /// <summary>
        /// 功能描述:查询数据列表
        /// 作　　者:TMom
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(string strWhere)
        {
            return await BaseRepo.Query(strWhere);
        }

        /// <summary>
        /// 功能描述:查询数据列表
        /// 作　　者:TMom
        /// </summary>
        /// <param name="whereExpression">whereExpression</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await BaseRepo.Query(whereExpression);
        }

        /// <summary>
        /// 查询单条数据
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<TEntity> QuerySingle(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await BaseRepo.QuerySingle(whereExpression);
        }

        /// <summary>
        /// 功能描述:按照特定列查询数据列表
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<List<TResult>> Query<TResult>(Expression<Func<TEntity, TResult>> expression)
        {
            return await BaseRepo.Query(expression);
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
            return await BaseRepo.QueryIncludes(include, whereExpression);
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
            return await BaseRepo.QueryIncludes(include1, include2, whereExpression);
        }

        /// <summary>
        /// 功能描述:按照特定列查询数据列表带条件排序
        /// 作　　者:TMom
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="whereExpression">过滤条件</param>
        /// <param name="expression">查询实体条件</param>
        /// <param name="orderByFileds">排序条件</param>
        /// <returns></returns>
        public async Task<List<TResult>> Query<TResult>(Expression<Func<TEntity, TResult>> expression, Expression<Func<TEntity, bool>> whereExpression, string orderByFileds)
        {
            return await BaseRepo.Query(expression, whereExpression, orderByFileds);
        }

        /// <summary>
        /// 功能描述:查询一个列表
        /// 作　　者:TMom
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="orderByFileds">排序字段，如name asc,age desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true)
        {
            return await BaseRepo.Query(whereExpression, orderByExpression, isAsc);
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string orderByFileds)
        {
            return await BaseRepo.Query(whereExpression, orderByFileds);
        }

        /// <summary>
        /// 功能描述:查询一个列表
        /// 作　　者:TMom
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="orderByFileds">排序字段，如name asc, age desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(string strWhere, string orderByFileds)
        {
            return await BaseRepo.Query(strWhere, orderByFileds);
        }

        /// <summary>
        /// 根据sql语句查询
        /// </summary>
        /// <param name="strSql">完整的sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>泛型集合</returns>
        public async Task<List<TEntity>> QuerySql(string strSql, SugarParameter[] parameters = null)
        {
            return await BaseRepo.QuerySql(strSql, parameters);
        }

        /// <summary>
        /// 根据sql语句查询
        /// </summary>
        /// <param name="strSql">完整的sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>DataTable</returns>
        public async Task<DataTable> QueryTable(string strSql, SugarParameter[] parameters = null)
        {
            return await BaseRepo.QueryTable(strSql, parameters);
        }

        /// <summary>
        /// 功能描述:查询前N条数据
        /// 作　　者:TMom
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="intTop">前N条</param>
        /// <param name="orderByFileds">排序字段，如name asc, age desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intTop, string orderByFileds)
        {
            return await BaseRepo.Query(whereExpression, intTop, orderByFileds);
        }

        /// <summary>
        /// 功能描述:查询前N条数据
        /// 作　　者:TMom
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="intTop">前N条</param>
        /// <param name="orderByFileds">排序字段，如name asc,age desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(
            string strWhere,
            int intTop,
            string orderByFileds)
        {
            return await BaseRepo.Query(strWhere, intTop, orderByFileds);
        }

        /// <summary>
        /// 功能描述:分页查询
        /// 作　　者:TMom
        /// </summary>
        /// <param name="whereExpression">条件表达式</param>
        /// <param name="pageIndex">页码（下标0）</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="orderByFileds">排序字段，如name asc,age desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(
            Expression<Func<TEntity, bool>> whereExpression,
            int pageIndex,
            int pageSize,
            string orderByFileds)
        {
            return await BaseRepo.Query(
              whereExpression,
              pageIndex,
              pageSize,
              orderByFileds);
        }

        /// <summary>
        /// 功能描述:分页查询
        /// 作　　者:TMom
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="pageIndex">页码（下标0）</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="orderByFileds">排序字段，如name asc,age desc</param>
        /// <returns>数据列表</returns>
        public async Task<List<TEntity>> Query(
          string strWhere,
          int pageIndex,
          int pageSize,
          string orderByFileds)
        {
            return await BaseRepo.Query(
            strWhere,
            pageIndex,
            pageSize,
            orderByFileds);
        }

        public async Task<PageModel<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression,
            int pageIndex, int pageSize, Expression<Func<TEntity, TEntity>>? selectExpression, Expression<Func<TEntity, object>>? orderbyExpression = null, OrderByType orderByType = OrderByType.Asc)
        {
            return await BaseRepo.QueryPage(whereExpression, pageIndex, pageSize, selectExpression, orderbyExpression, orderByType);
        }

        public async Task<PageModel<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression,
            int pageIndex = 1, int pageSize = 10, Expression<Func<TEntity, TEntity>>? selectExpression = null, string? orderByFileds = null)
        {
            return await BaseRepo.QueryPage(whereExpression, pageIndex, pageSize, selectExpression, orderByFileds);
        }

        /// <summary>
        /// 分页查询(关联一层级表)
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="includes">一层导航表</param>
        /// <returns></returns>
        //public async Task<PageModel<TEntity>> QueryIncludesPage<TInclude>(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20
        //    , params Expression<Func<TEntity, TInclude>>[] includes)
        //{
        //    return await BaseRepo.QueryIncludesPage(whereExpression, intPageIndex, intPageSize, includes);
        //}

        /// <summary>
        /// 分页查询(关联一层级表)
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="include1">一层导航表1</param>
        /// <param name="include2">一层导航表2</param>
        /// <returns></returns>
        //public async Task<PageModel<TEntity>> QueryIncludesPage<TInclude1, TInclude2>(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20
        //    , Expression<Func<TEntity, TInclude1>> include1 = null, Expression<Func<TEntity, TInclude1>> include2 = null)
        //{
        //    return await BaseRepo.QueryIncludesPage(whereExpression, intPageIndex, intPageSize, include1, include2);
        //}

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
        public async Task<PageModel<TEntity>> QueryIncludesPage<TInclude>(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20
            , Expression<Func<TEntity, TEntity>>? selectExpression = null, string? stringOrderByFields = null, List<FormattableString> includeWhereList = null
            , Expression<Func<TEntity, TInclude>> include = null)
        {
            return await BaseRepo.QueryIncludesPage(whereExpression, intPageIndex, intPageSize, selectExpression, stringOrderByFields, includeWhereList, include);
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
            return await BaseRepo.QueryIncludesPage(whereExpression, intPageIndex, intPageSize, selectExpression, stringOrderByFields, includeWhereList, include1, include2);
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
        /// <param name="include3">一层导航表3</param>
        /// <returns></returns>
        public async Task<PageModel<TEntity>> QueryIncludesPage<TInclude1, TInclude2, TInclude3>(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20
            , Expression<Func<TEntity, TEntity>>? selectExpression = null, string? stringOrderByFields = null
            , List<FormattableString> includeWhereList = null
            , Expression<Func<TEntity, TInclude1>> include1 = null, Expression<Func<TEntity, TInclude2>> include2 = null
            , Expression<Func<TEntity, TInclude3>> include3 = null)
        {
            return await BaseRepo.QueryIncludesPage(whereExpression, intPageIndex, intPageSize, selectExpression, stringOrderByFields, includeWhereList, include1, include2, include3);
        }

        /// <summary>
        /// 分页查询(自动关联所有一层级表)
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
        public async Task<PageModel<TEntity>> QueryIncludesPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20
            , Expression<Func<TEntity, TEntity>>? selectExpression = null, Expression<Func<TEntity, object>>? orderbyExpression = null,
            OrderByType orderByType = OrderByType.Asc, List<FormattableString> includeWhereList = null, params string[] includes)
        {
            return await BaseRepo.QueryIncludesPage(whereExpression, intPageIndex, intPageSize, selectExpression
                , orderbyExpression, orderByType, includeWhereList, includes);
        }

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
        public async Task<PageModel<TEntity>> QueryIncludesPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20
            , Expression<Func<TEntity, TEntity>>? selectExpression = null, string? stringOrderByFields = null
            , List<FormattableString> includeWhereList = null
            , params string[] includes)
        {
            return await BaseRepo.QueryIncludesPage(whereExpression, intPageIndex, intPageSize, selectExpression, stringOrderByFields, includeWhereList, includes);
        }

        public async Task<List<TResult>> QueryMuch<T, T2, T3, TResult>(Expression<Func<T, T2, T3, object[]>> joinExpression, Expression<Func<T, T2, T3, TResult>> selectExpression, Expression<Func<T, T2, T3, bool>> whereLambda = null) where T : class, new()
        {
            return await BaseRepo.QueryMuch(joinExpression, selectExpression, whereLambda);
        }

        public async Task<PageModel<TEntity>> QueryPage(PaginationModel pagination)
        {
            var express = DynamicLinqFactory.CreateLambda<TEntity>(pagination.conditions);
            return await QueryPage(express, pagination.pageIndex, pagination.pageSize, null, "");
        }
    }
}