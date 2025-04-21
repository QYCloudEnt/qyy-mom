using TMom.Infrastructure.Common;
using TMom.Infrastructure.Helper;
using SqlSugar;
using System.Text;

namespace TMom.Domain.Model.Seed
{
    public class FrameSeed
    {
        /// <summary>
        /// 生成Controller层
        /// </summary>
        /// <param name="sqlSugarClient">sqlsugar实例</param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="isMuti"></param>
        /// <param name="tableNames">数据库表名数组，默认空，生成所有表</param>
        /// <param name="path">生成文件所在路径</param>
        /// <returns></returns>
        public static bool CreateControllers(SqlSugarScope sqlSugarClient, string ConnId = null, bool isMuti = false, string[] tableNames = null, string path = null, string? menuName = "", string tKey = "int")
        {
            Create_Controller_ClassFileByDBTalbe(sqlSugarClient, ConnId, $@"{path}" ?? $@"C:\my-file\TMom.Api.Controllers", "TMom.Api.Controllers", tableNames, "", isMuti, menuName, tKey);
            return true;
        }

        /// <summary>
        /// 生成Model层
        /// </summary>
        /// <param name="sqlSugarClient">sqlsugar实例</param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="tableNames">数据库表名数组，默认空，生成所有表</param>
        /// <param name="isMuti"></param>
        /// <param name="fileName">生成文件所在路径</param>
        /// <returns></returns>
        public static bool CreateModels(SqlSugarScope sqlSugarClient, string ConnId, bool isMuti = false, string[] tableNames = null, string fileName = null)
        {
            Create_Model_ClassFileByDBTalbe(sqlSugarClient, ConnId, $@"{SystemInfo.EntityPath}\{fileName}" ?? $@"C:\my-file\TMom.Model", "TMom.Domain.Model.Entity", tableNames, "", isMuti);
            return true;
        }

        /// <summary>
        /// 生成IRepository层
        /// </summary>
        /// <param name="sqlSugarClient">sqlsugar实例</param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="isMuti"></param>
        /// <param name="tableNames">数据库表名数组，默认空，生成所有表</param>
        /// <param name="fileName">生成文件所在路径</param>
        /// <returns></returns>
        public static bool CreateIRepositorys(SqlSugarScope sqlSugarClient, string ConnId, bool isMuti = false, string[] tableNames = null, string fileName = null, string tKey = "int")
        {
            Create_IRepository_ClassFileByDBTalbe(sqlSugarClient, ConnId, $@"{SystemInfo.IRepositoryPath}\{fileName}" ?? $@"C:\my-file\TMom.IRepository", "TMom.Domain.IRepository", tableNames, "", isMuti, tKey);
            return true;
        }

        /// <summary>
        /// 生成 IService 层
        /// </summary>
        /// <param name="sqlSugarClient">sqlsugar实例</param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="isMuti"></param>
        /// <param name="tableNames">数据库表名数组，默认空，生成所有表</param>
        /// <param name="fileName">生成文件所在路径</param>
        /// <returns></returns>
        public static bool CreateIServices(SqlSugarScope sqlSugarClient, string ConnId, bool isMuti = false, string[] tableNames = null, string fileName = null, string tKey = "int")
        {
            Create_IServices_ClassFileByDBTalbe(sqlSugarClient, ConnId, $@"{SystemInfo.IServicePath}\{fileName}" ?? $@"C:\my-file\TMom.IServices", "TMom.Application.Service.IService", tableNames, "", isMuti, tKey);
            return true;
        }

        /// <summary>
        /// 生成 Repository 层
        /// </summary>
        /// <param name="sqlSugarClient">sqlsugar实例</param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="isMuti"></param>
        /// <param name="tableNames">数据库表名数组，默认空，生成所有表</param>
        /// <param name="fileName">生成文件所在路径</param>
        /// <returns></returns>
        public static bool CreateRepository(SqlSugarScope sqlSugarClient, string ConnId, bool isMuti = false, string[] tableNames = null, string fileName = null, string tKey = "int")
        {
            Create_Repository_ClassFileByDBTalbe(sqlSugarClient, ConnId, $@"{SystemInfo.RepositoryPath}\{fileName}" ?? $@"C:\my-file\TMom.Repository", "TMom.Infrastructure.Repository", tableNames, "", isMuti, tKey);
            return true;
        }

        /// <summary>
        /// 生成 Service 层
        /// </summary>
        /// <param name="sqlSugarClient">sqlsugar实例</param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="isMuti"></param>
        /// <param name="tableNames">数据库表名数组，默认空，生成所有表</param>
        /// <param name="fileName">生成文件所在路径</param>
        /// <returns></returns>
        public static bool CreateServices(SqlSugarScope sqlSugarClient, string ConnId, bool isMuti = false, string[] tableNames = null, string fileName = null, string tKey = "int")
        {
            Create_Services_ClassFileByDBTalbe(sqlSugarClient, ConnId, $@"{SystemInfo.ServicePath}\{fileName}" ?? $@"C:\my-file\TMom.Services", "TMom.Application.Service.Service", tableNames, "", isMuti, tKey);
            return true;
        }

        #region 根据数据库表生产Controller层

        /// <summary>
        /// 功能描述:根据数据库表生产Controller层
        /// 作　　者:TMom
        /// </summary>
        /// <param name="sqlSugarClient"></param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="strPath">实体类存放路径</param>
        /// <param name="strNameSpace">命名空间</param>
        /// <param name="lstTableNames">生产指定的表</param>
        /// <param name="strInterface">实现接口</param>
        /// <param name="isMuti"></param>
        private static void Create_Controller_ClassFileByDBTalbe(
          SqlSugarScope sqlSugarClient,
          string ConnId,
          string strPath,
          string strNameSpace,
          string[] lstTableNames,
          string strInterface,
          bool isMuti = false,
          string? menuName = "", string tKey = "int")
        {
            var ls = new Dictionary<string, string>();
            foreach (var tblName in lstTableNames)
            {
                #region content

                var fileContent = @$"using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using TMom.Domain.Model.Entity;
using TMom.Application.Service.IService;
using static TMom.Domain.Model.GlobalVars;
using TMom.Application;
using TMom.Domain.Model;
using TMom.Application.Dto;

namespace " + strNameSpace + @"
{
    /// <summary>
    /// " + menuName + @$"
    /// </summary>
	[Route(""api/[controller]/[action]"")]
	[ApiController]
     public class ~" + tblName + @"Controller: BaseApiController<~" + tblName + @", " + tKey + @">
    {
        private readonly I~" + tblName + @"Service _~" + tblName + @"Service;
        private readonly IMapper _mapper;

        public ~" + tblName + @"Controller(I~" + tblName + @"Service FL~" + tblName + @"Service, IMapper mapper)
        {
            _~" + tblName + @"Service = FL~" + tblName + @"Service;
            _mapper = mapper;
        }

        #region 模板生成 CRUD

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name=""pageIndex"">页标, 默认1</param>
        /// <param name=""pageSize"">页数, 默认10</param>
        /// <param name=""field"">排序字段</param>
        /// <param name=""order"">排序类型: ascend|descend</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<PageModel<~" + tblName + @">>> GetWithPage(int pageIndex = 1, int pageSize = 10, string field = """", string order = """")
        {
            PageModel<~" + tblName + @"> data = await _~" + tblName + @"Service.GetWithPage(DynamicFilterExpress(), pageIndex, pageSize, FormatOrderField(field, order));
            return SuccessPage(data);
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name=""id""></param>
        /// <returns></returns>
        [HttpGet(""{id}"")]
        public async Task<MessageModel<~" + tblName + @">> Get(" + tKey + @" id)
        {
            ~" + tblName + @" entity = await _~" + tblName + @"Service.GetById(id);
            return Success(entity);
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name=""model""></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Add([FromBody] ~" + tblName + @" model)
        {
            var id = await _~" + tblName + @"Service.AddData(model);
            return id > 0 ? Success(id.ObjToString(), ""添加成功!"") : Failed();
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name=""model""></param>
        /// <returns>修改的主键Id</returns>
        [HttpPut]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Update([FromBody] ~" + tblName + @" model)
        {
            bool res = await _~" + tblName + @"Service.UpdateData(model);
            return res ? Success(""更新成功!"") : Failed();
        }

        /// <summary>
        /// 根据主键Id删除数据
        /// </summary>
        /// <param name=""ids""></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Delete(string ids)
        {
            bool res = await _~" + tblName + @"Service.DeleteData(ids);
            return res ? Success(""删除成功!"") : Failed();
        }

        #endregion 模板生成 CRUD
    }
}";

                #endregion content

                ls.Add(tblName, fileContent);
            }

            RenderNetTempKey(ls, lstTableNames, out Dictionary<string, string> newdic);
            CreateFilesByClassStringList(newdic, strPath, "{0}Controller");
        }

        #endregion 根据数据库表生产Controller层

        #region 根据数据库表生产Model层

        /// <summary>
        /// 功能描述:根据数据库表生产Model层
        /// 作　　者:TMom
        /// </summary>
        /// <param name="sqlSugarClient"></param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="strPath">实体类存放路径</param>
        /// <param name="strNameSpace">命名空间</param>
        /// <param name="lstTableNames">生产指定的表</param>
        /// <param name="strInterface">实现接口</param>
        /// <param name="isMuti"></param>
        /// <param name="blnSerializable">是否序列化</param>
        private static void Create_Model_ClassFileByDBTalbe(
          SqlSugarScope sqlSugarClient,
          string ConnId,
          string strPath,
          string strNameSpace,
          string[] lstTableNames,
          string strInterface,
          bool isMuti = false,
          bool blnSerializable = false)
        {
            //            //多库文件分离
            //            if (isMuti)
            //            {
            //                strPath = strPath + @"\Entity\" + ConnId;
            //                strNameSpace = strNameSpace + "." + ConnId;
            //            }
            //            var ICodeFirst = sqlSugarClient.CodeFirst;
            //            ICodeFirst.InitTables();

            //            var IDbFirst = sqlSugarClient.DbFirst;
            //            if (lstTableNames != null && lstTableNames.Length > 0)
            //            {
            //                IDbFirst = IDbFirst.Where(lstTableNames);
            //            }
            //            var ls = IDbFirst.IsCreateDefaultValue().IsCreateAttribute()

            //                  .SettingClassTemplate(p => p =
            //@"{using}

            //namespace " + strNameSpace + @"
            //{
            //{ClassDescription}
            //    [SugarTable( """ + tblName + @""", """ + ConnId + @""")]" + (blnSerializable ? "\n    [Serializable]" : "") + @"
            //    public class " + tblName + @"" + (string.IsNullOrEmpty(strInterface) ? "" : (" : " + strInterface)) + @": RootEntity<int>
            //    {
            //           public " + tblName + @"()
            //           {
            //           }
            //{PropertyName}
            //    }
            //}")
            //                  //.SettingPropertyDescriptionTemplate(p => p = string.Empty)
            //                  .SettingPropertyTemplate(p => p =
            //@"
            //{SugarColumn}
            //           public {PropertyType} {PropertyName} { get; set; }")

            //                   //.SettingConstructorTemplate(p => p = "              this._{PropertyName} ={DefaultValue};")

            //                   .ToClassStringList(strNameSpace);
            //            CreateFilesByClassStringList(ls, strPath, "{0}");
        }

        #endregion 根据数据库表生产Model层

        #region 根据数据库表生产IRepository层

        /// <summary>
        /// 功能描述:根据数据库表生产IRepository层
        /// 作　　者:TMom
        /// </summary>
        /// <param name="sqlSugarClient"></param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="strPath">实体类存放路径</param>
        /// <param name="strNameSpace">命名空间</param>
        /// <param name="lstTableNames">生产指定的表</param>
        /// <param name="strInterface">实现接口</param>
        /// <param name="isMuti"></param>
        private static void Create_IRepository_ClassFileByDBTalbe(
          SqlSugarScope sqlSugarClient,
          string ConnId,
          string strPath,
          string strNameSpace,
          string[] lstTableNames,
          string strInterface,
          bool isMuti = false, string tKey = "int"
            )
        {
            var ls = new Dictionary<string, string>();
            foreach (var tblName in lstTableNames)
            {
                #region content

                var fileContent = @"using TMom.Domain.Model;
using SqlSugar;
using System.Data;
using System.Linq.Expressions;
using TMom.Domain.Model.Entity" + (isMuti ? "." + ConnId + "" : "") + @";

namespace " + strNameSpace + @"
{
	/// <summary>
	/// I~" + tblName + @"Repository
	/// </summary>
    public interface I~" + tblName + @"Repository : IBaseRepository<~" + tblName + @", " + tKey + @">" + (string.IsNullOrEmpty(strInterface) ? "" : (" , " + strInterface)) + @"
    {
    }
}";

                #endregion content

                ls.Add(tblName, fileContent);
            }

            RenderNetTempKey(ls, lstTableNames, out Dictionary<string, string> newdic);
            CreateFilesByClassStringList(newdic, strPath, "I{0}Repository");
        }

        #endregion 根据数据库表生产IRepository层

        #region 根据数据库表生产IService层

        /// <summary>
        /// 功能描述:根据数据库表生产IService层
        /// 作　　者:TMom
        /// </summary>
        /// <param name="sqlSugarClient"></param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="strPath">实体类存放路径</param>
        /// <param name="strNameSpace">命名空间</param>
        /// <param name="lstTableNames">生产指定的表</param>
        /// <param name="strInterface">实现接口</param>
        /// <param name="isMuti"></param>
        private static void Create_IServices_ClassFileByDBTalbe(
          SqlSugarScope sqlSugarClient,
          string ConnId,
          string strPath,
          string strNameSpace,
          string[] lstTableNames,
          string strInterface,
          bool isMuti = false, string tKey = "int")
        {
            var ls = new Dictionary<string, string>();
            foreach (var tblName in lstTableNames)
            {
                #region content

                var fileContent = @"using TMom.Domain.Model.Entity" + (isMuti ? "." + ConnId + "" : "") + @";
using TMom.Domain.Model;
using System.Linq.Expressions;

namespace " + strNameSpace + @"
{
	/// <summary>
	/// I~" + tblName + @"Service
	/// </summary>
    public interface I~" + tblName + @"Service: IBaseService<~" + tblName + @", " + tKey + @">" + (string.IsNullOrEmpty(strInterface) ? "" : (" , " + strInterface)) + @"
	{
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name=""whereExp"">查询条件表达式 Item1: 主表查询条件表达式, Item2: 导航表查询条件集合</param>
        /// <param name=""pageIndex"">页标, 默认1</param>
        /// <param name=""pageSize"">页数, 默认10</param>
        /// <param name=""orderByFields"">排序字段, 如name asc,age desc</param>
        /// <returns></returns>
        Task<PageModel<~" + tblName + @">> GetWithPage((Expression<Func<~" + tblName + @", bool>>, List<FormattableString>) whereExp, int pageIndex, int pageSize, string orderByFields = """");

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name=""id""></param>
        /// <returns></returns>
        Task<~" + tblName + @"> GetById(" + tKey + @" id);

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name=""entity""></param>
        /// <returns></returns>
        Task<" + tKey + @"> AddData(~" + tblName + @" entity);

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name=""entity""></param>
        /// <returns>修改的主键Id</returns>
        Task<bool> UpdateData(~" + tblName + @" entity);

        /// <summary>
        /// 根据主键Id删除数据
        /// </summary>
        /// <param name=""ids"">多个以逗号分隔</param>
        /// <returns></returns>
        Task<bool> DeleteData(string ids);
    }
}";

                #endregion content

                ls.Add(tblName, fileContent);
            }

            RenderNetTempKey(ls, lstTableNames, out Dictionary<string, string> newdic);
            CreateFilesByClassStringList(newdic, strPath, "I{0}Service");
        }

        #endregion 根据数据库表生产IService层

        #region 根据数据库表生产 Repository 层

        /// <summary>
        /// 功能描述:根据数据库表生产 Repository 层
        /// 作　　者:TMom
        /// </summary>
        /// <param name="sqlSugarClient"></param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="strPath">实体类存放路径</param>
        /// <param name="strNameSpace">命名空间</param>
        /// <param name="lstTableNames">生产指定的表</param>
        /// <param name="strInterface">实现接口</param>
        /// <param name="isMuti"></param>
        private static void Create_Repository_ClassFileByDBTalbe(
          SqlSugarScope sqlSugarClient,
          string ConnId,
          string strPath,
          string strNameSpace,
          string[] lstTableNames,
          string strInterface,
          bool isMuti = false, string tKey = "int")
        {
            var ls = new Dictionary<string, string>();
            foreach (var tblName in lstTableNames)
            {
                #region content

                var fileContent = @"using TMom.Domain.IRepository" + (isMuti ? "." + ConnId + "" : "") + @";
using TMom.Domain.Model;
using TMom.Domain.Model.Entity" + (isMuti ? "." + ConnId + "" : "") + @";

namespace " + strNameSpace + @"
{
	/// <summary>
	/// ~" + tblName + @"Repository
	/// </summary>
    public class ~" + tblName + @"Repository : BaseRepository<~" + tblName + @", " + tKey + @">, I~" + tblName + @"Repository" + (string.IsNullOrEmpty(strInterface) ? "" : (" , " + strInterface)) + @"
    {
        public ~" + tblName + @"Repository(IUnitOfWork unitOfWork): base(unitOfWork)
        {
        }
    }
}";

                #endregion content

                ls.Add(tblName, fileContent);
            }

            RenderNetTempKey(ls, lstTableNames, out Dictionary<string, string> newdic);
            CreateFilesByClassStringList(newdic, strPath, "{0}Repository");
        }

        #endregion 根据数据库表生产 Repository 层

        #region 根据数据库表生成 Service 层

        /// <summary>
        /// 功能描述:根据数据库表生产 Service 层
        /// 作　　者:TMom
        /// </summary>
        /// <param name="sqlSugarClient"></param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="strPath">实体类存放路径</param>
        /// <param name="strNameSpace">命名空间</param>
        /// <param name="lstTableNames">生产指定的表</param>
        /// <param name="strInterface">实现接口</param>
        /// <param name="isMuti"></param>
        private static void Create_Services_ClassFileByDBTalbe(
          SqlSugarScope sqlSugarClient,
          string ConnId,
          string strPath,
          string strNameSpace,
          string[] lstTableNames,
          string strInterface,
          bool isMuti = false, string tKey = "int")
        {
            var ls = new Dictionary<string, string>();
            foreach (var tblName in lstTableNames)
            {
                #region content

                var fileContent = @"using TMom.Application.Service.IService" + (isMuti ? "." + ConnId + "" : "") + @";
using TMom.Domain.Model.Entity" + (isMuti ? "." + ConnId + "" : "") + @";
using TMom.Domain.IRepository;
using SqlSugar;
using TMom.Domain.Model;
using System.Linq.Expressions;
using TMom.Infrastructure;

namespace " + strNameSpace + @"
{
    public class ~" + tblName + @"Service : BaseService<~" + tblName + @", " + tKey + @">, I~" + tblName + @"Service" + (string.IsNullOrEmpty(strInterface) ? "" : (" , " + strInterface)) + @"
    {
        private readonly IBaseRepository<~" + tblName + @", " + tKey + @"> _dal;
        private readonly I~" + tblName + @"Repository _~" + tblName + @"Repository;
        private readonly IUser _user;
        public ~" + tblName + @"Service(IBaseRepository<~" + tblName + @", " + tKey + @"> dal, I~" + tblName + @"Repository FL~" + tblName + @"Repository, IUser user)
        {
            this._dal = dal;
            base.BaseRepo = dal;
            _~" + tblName + @"Repository = FL~" + tblName + @"Repository;
            _user = user;
        }

        #region 模板生成 CRUD

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name=""whereExp"">查询条件表达式 Item1: 主表查询条件表达式, Item2: 导航表查询条件集合</param>
        /// <param name=""pageIndex"">页标, 默认1</param>
        /// <param name=""pageSize"">页数, 默认10</param>
        /// <param name=""orderByFields"">排序字段, 如name asc,age desc</param>
        /// <returns></returns>
        public async Task<PageModel<~" + tblName + @">> GetWithPage((Expression<Func<~" + tblName + @", bool>>, List<FormattableString>) whereExp
            , int pageIndex, int pageSize, string orderByFields = """")
        {
            var data = await _~" + tblName + @"Repository.QueryPage(whereExp.Item1, pageIndex, pageSize, null, orderByFields);
            return data;
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name=""id""></param>
        /// <returns></returns>
        public async Task<~" + tblName + @"> GetById(" + tKey + @" id)
        {
            var entity = await _~" + tblName + @"Repository.QueryById(id);
            return entity;
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name=""entity""></param>
        /// <returns></returns>
        public async Task<" + tKey + @"> AddData(~" + tblName + @" entity)
        {
            entity.UpdateCommonFields(_user.Id);
            var id = await _~" + tblName + @"Repository.Add(entity);
            return id;
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name=""entity""></param>
        /// <returns>修改的主键Id</returns>
        public async Task<bool> UpdateData(~" + tblName + @" entity)
        {
            entity.UpdateCommonFields(_user.Id, false);
            bool isSuccess = await _~" + tblName + @"Repository.Update(entity);
            return isSuccess;
        }

        /// <summary>
        /// 根据主键Id删除数据
        /// </summary>
        /// <param name=""ids"">多个以逗号分隔</param>
        /// <returns></returns>
        public async Task<bool> DeleteData(string ids)
        {
            List<int> idList = ids.Split(',').Select(id => id.ObjToInt()).ToList();
            bool isSuccess = await _~" + tblName + @"Repository.DeleteSoft(x => idList.Contains(x.Id), _user.Id);
            return isSuccess;
        }

        #endregion 模板生成 CRUD
    }
}";

                #endregion content

                ls.Add(tblName, fileContent);
            }

            RenderNetTempKey(ls, lstTableNames, out Dictionary<string, string> newdic);
            CreateFilesByClassStringList(newdic, strPath, "{0}Service");
        }

        #endregion 根据数据库表生成 Service 层

        #region 统一处理.Net文件模板的Key

        /// <summary>
        /// 统一处理.Net文件模板的Key
        /// </summary>
        /// <param name="ls"></param>
        /// <param name="lstTableNames"></param>
        /// <param name="newdic"></param>
        private static void RenderNetTempKey(Dictionary<string, string> ls, string[] lstTableNames, out Dictionary<string, string> newdic)
        {
            newdic = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> item in ls)
            {
                // key优先从lstTableNames中获取
                string? key = lstTableNames?.Where(tabName => tabName.Equals(item.Key, StringComparison.OrdinalIgnoreCase))
                                            .Select(x => x).FirstOrDefault();
                if (string.IsNullOrEmpty(key))
                {
                    key = item.Key;
                }

                string newVal = item.Value.Replace($"FL~{item.Key}", $"{key.First().ToString().ToLower()}{key.Substring(1)}")//SysUserService -> sysUserService
                                          .Replace($"_~{item.Key}", $"_{key.First().ToString().ToLower()}{key.Substring(1)}")//_SysUserService -> _sysUserService
                                          .Replace($"~{item.Key}", key);
                newdic.Add(key, newVal);
            }
        }

        #endregion 统一处理.Net文件模板的Key

        #region 根据数据库表生成 Vue 文件

        #region 查询表格

        /// <summary>
        /// 生成查询表格模板
        /// </summary>
        /// <param name="sqlSugarClient"></param>
        /// <param name="vuePath">vue配置的路径: xxx/views/sys</param>
        /// <param name="fileFolderName">存放的文件夹: Sys</param>
        /// <param name="lstTableNames">实体类名称: SysUser</param>
        public static void Create_Vue_SearchTable_FileByDBTalbe(SqlSugarScope sqlSugarClient, string vuePath, string fileFolderName, string[] lstTableNames)
        {
            var ls = new Dictionary<string, string>();
            foreach (var tblName in lstTableNames)
            {
                #region index.vue

                var fileContent = @"<template>
  <div>
    <DynamicTable
      row-key=""id""
      :data-request=""loadData""
      :columns=""columns""
      bordered
      size=""small""
      :row-selection=""rowSelection""
    >
      <template v-if=""checkRows.count"" #title>
        <Alert class=""w-full"" type=""info"" show-icon>
          <template #message>
            {{ $t('common.selected', [checkRows.count]) }}
            <a-button type=""link"" @click=""handleCancelSelect"">
              {{ $t('common.cancelChoose') }}
            </a-button>
          </template>
        </Alert>
      </template>
      <template #toolbar>
        <a-button v-if=""$auth('/api/api" + tblName + @"/Add')"" type=""primary"" @click=""openModal({})"">
          {{ $t('common.add') }}
        </a-button>
        <a-button type=""primary"" :loading=""exportLoading"" @click=""aoaToExcel"">
          {{ $t('common.export') }}
        </a-button>
        <a-button
          v-if=""$auth('/api/api" + tblName + @"/Delete')""
          type=""error""
          :disabled=""!checkRows.count""
          @click=""delRowConfirm(rowSelection.selectedRowKeys)""
        >
          {{ $t('common.delete') }}
        </a-button>
      </template>
    </DynamicTable>
  </div>
</template>

<script lang=""tsx"" setup>
  import { Alert } from 'ant-design-vue'
  import { useTable, useTablePlugin, type TableColumn } from '@/components/core/dynamic-table'
  import { useI18n } from '@/hooks/useI18n'
  import { baseColumns } from './columns'
  import { formSchemas } from './formSchemas'
  import action from '@/api/" + fileFolderName.FirstToLower() + @"/action" + tblName + @"'

  defineOptions({
    name: 'name" + tblName + @"',
  })

  const { t } = useI18n()
  const [DynamicTable, dynamicTableInstance] = useTable()
  const {
    rowSelection,
    checkRows,
    exportLoading,
    loadData,
    aoaToExcel,
    handleCancelSelect,
    openModal,
    delRowConfirm,
  } = useTablePlugin({ dynamicTableInstance, action, columns: baseColumns, formSchemas })

  /**
   * 表格列
   */
  const columns: TableColumn<any>[] = [
    ...baseColumns,
    {
      title: '操作',
      width: 200,
      dataIndex: 'ACTION',
      hideInSearch: true,
      align: 'center',
      fixed: 'right',
      actions: ({ record }) => [
        {
          label: t('common.edit'),
          auth: {
            perm: '/api/api" + tblName + @"/Update',
            effect: 'disable',
          },
          onClick: () => openModal(record),
        },
        {
          label: t('common.delete'),
          danger: true,
          auth: {
            perm: '/api/api" + tblName + @"/Delete',
            effect: 'disable',
          },
          popConfirm: {
            title: t('column.confirmDel'),
            onConfirm: () => delRowConfirm(record.id),
          },
        },
      ],
    },
  ]
</script>
";

                #endregion index.vue

                ls.Add(tblName, fileContent);
            }
            var IDbFirst = sqlSugarClient.DbFirst;

            RenderTempKey(ls, fileFolderName, lstTableNames, out Dictionary<string, string> newdic);

            CreateVueFilesByClassStringList(newdic, vuePath, fileFolderName, "index.vue");
            CreateTsFilesByClassStringList(IDbFirst, vuePath, fileFolderName, lstTableNames);
            Create_Columns_File(vuePath, fileFolderName, lstTableNames);
            Create_Formschemas_File(vuePath, fileFolderName, lstTableNames);
        }

        #endregion 查询表格

        #region 列和表单

        public static void Create_Columns_File(string vuePath, string fileFolderName, string[] lstTableNames)
        {
            var lst = new Dictionary<string, string>();
            foreach (var tblName in lstTableNames)
            {
                var fileContent = @"import type { TableColumn } from '@/components/core/dynamic-table'
import { Tag } from 'ant-design-vue'
import { PublishStatusEnum, getEmunIndex, transformEnumToOptions } from '@/enums/commonEnum'

export const baseColumns: TableColumn[] = [
  {
    title: 'id',
    dataIndex: 'id',
    width: 60,
    sorter: true,
    hideInTable: true,
    hideInSearch: true,
  },
  {
    title: '名称',
    width: 150,
    dataIndex: 'name',
  },
  {
    title: '类型',
    dataIndex: 'typeName',
    hideInSearch: true,
  },
  {
    title: '状态',
    dataIndex: 'status',
    formItemProps: {
      component: 'Select',
      componentProps: {
        options: transformEnumToOptions(PublishStatusEnum),
      },
    },
    customRender: ({ text }) => (
      <Tag color={['error', 'success'][getEmunIndex(PublishStatusEnum, text)]}>
        {PublishStatusEnum[text]}
      </Tag>
    ),
  },
  {
    title: '描述',
    dataIndex: 'description',
    hideInSearch: true,
  },
  {
    title: '创建人',
    dataIndex: 'createUser',
    width: 160,
    hideInSearch: true,
  },
  {
    title: '创建时间',
    dataIndex: 'createTime',
    width: 160,
    sorter: true,
    hideInSearch: true,
  },
  {
    title: '更新人',
    dataIndex: 'updateUser',
    width: 160,
    hideInSearch: true,
    hideInTable: true,
  },
  {
    title: '更新时间',
    dataIndex: 'updateTime',
    width: 160,
    hideInSearch: true,
  },
]
";
                lst.Add(tblName, fileContent);
            }

            Dictionary<string, string> newdic = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> item in lst)
            {
                string? key = lstTableNames.Where(tabName => tabName.Equals(item.Key, StringComparison.OrdinalIgnoreCase))
                                           .Select(x => x).FirstOrDefault();
                if (string.IsNullOrEmpty(key))
                {
                    key = item.Key;
                }
                string newValue = item.Value.Replace(item.Key, key);
                newdic.Add(key, newValue);
            }
            CreateVueFilesByClassStringList(newdic, vuePath, fileFolderName, "columns.tsx");
        }

        public static void Create_Formschemas_File(string vuePath, string fileFolderName, string[] lstTableNames)
        {
            var lst = new Dictionary<string, string>();
            foreach (var tblName in lstTableNames)
            {
                var fileContent = @"import type { FormSchema } from '@/components/core/schema-form'
import dicAction from '@/api/dev/dataDic'

/**
 * 表单信息
 */
export const formSchemas: FormSchema[] = [
  {
    field: 'name',
    component: 'Input',
    label: '名称',
    required: true,
    colProps: {
      span: 24,
    },
  },
  {
    field: 'content',
    component: 'Input',
    label: '内容',
    vIf: () => false,
  },
  {
    field: 'type',
    component: 'Select',
    label: '类型',
    required: true,
    componentProps: {
      request: async () => await dicAction.getForSelect('工艺路线类型'),
    },
  },
  {
    field: 'description',
    component: 'InputTextArea',
    label: '描述',
  },
]
";
                lst.Add(tblName, fileContent);
            }

            Dictionary<string, string> newdic = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> item in lst)
            {
                string? key = lstTableNames.Where(tabName => tabName.Equals(item.Key, StringComparison.OrdinalIgnoreCase))
                                           .Select(x => x).FirstOrDefault();
                if (string.IsNullOrEmpty(key))
                {
                    key = item.Key;
                }
                string newValue = item.Value.Replace(item.Key, key);
                newdic.Add(key, newValue);
            }
            CreateVueFilesByClassStringList(newdic, vuePath, fileFolderName, "formSchemas.ts");
        }

        #endregion 列和表单

        #region 查询表格(有详情页)

        public static void Create_Vue_SearchTableHasDetail_FileByDBTalbe(SqlSugarScope sqlSugarClient, string vuePath, string fileFolderName, string[] lstTableNames)
        {
            var IDbFirst = sqlSugarClient.DbFirst;
            var ls = new Dictionary<string, string>();
            foreach (var tblName in lstTableNames)
            {
                #region index.vue

                var fileContent = @"<template>
  <div>
    <DynamicTable
      ref=""dynamicTableRef""
      row-key=""id""
      :data-request=""loadData""
      :columns=""columns""
      bordered
      size=""small""
      :row-selection=""rowSelection""
    >
      <template #title v-if=""isCheckRows"">
        <Alert class=""w-full"" type=""info"" show-icon>
          <template #message>
            已选 {{ isCheckRows }} 项
            <a-button type=""link"" @click=""rowSelection.selectedRowKeys = []"">取消选择</a-button>
          </template>
        </Alert>
      </template>
      <template #toolbar>
        <a-button type=""primary"" v-if=""$auth('/api/api" + tblName + @"/Add')"" @click=""openModal({})"">
          新增
        </a-button>
        <a-button type=""primary"" :loading=""exportLoading"" @click=""aoaToExcel""> 导出 </a-button>
        <a-button
          type=""danger""
          :disabled=""!isCheckRows""
          v-if=""$auth('/api/api" + tblName + @"/Delete')""
          @click=""delRowConfirm(rowSelection.selectedRowKeys)""
        >
          删除
        </a-button>
      </template>
    </DynamicTable>
  </div>
</template>

<script lang=""tsx"" setup>
  import { ref, computed } from 'vue'
  import { Avatar, Tag, Tooltip, Modal, Alert } from 'ant-design-vue'
  import { ExclamationCircleOutlined } from '@ant-design/icons-vue'
  import { useRoute, useRouter } from 'vue-router'
  import { DynamicTable } from '@/components/core/dynamic-table'
  import { useFormModal } from '@/hooks/useModal/useFormModal'
  import type { FormSchema } from '@/components/core/schema-form/src/types/form'
  import type { TableColumn } from '@/components/core/dynamic-table'
  import { formatToDate, formatToDateTime } from '@/utils/dateUtil'
  import { aoaToSheetXlsx } from '@/components/basic/excel'
  import { exportPageParam } from '@/utils/global'
  import action from '@/api/" + fileFolderName.FirstToLower() + @"/action" + tblName + @"'

  defineOptions({
    name: 'name" + tblName + @"'
  })

  const dynamicTableRef = ref<InstanceType<typeof DynamicTable>>()

  const [showModal] = useFormModal()
  const route = useRoute()
  const router = useRouter()
  const exportLoading = ref(false)
  let searchParams: any = {}

  /**
   * 选中的行数据
   */
  const rowSelection = ref({
    selectedRowKeys: [] as number[],
    onChange: (selectedRowKeys: number[], selectedRows) => {
      console.log(`selectedRowKeys: ${selectedRowKeys}`, 'selectedRows: ', selectedRows)
      rowSelection.value.selectedRowKeys = selectedRowKeys
    }
  })

  /**
   * 是否勾选了表格行
   */
  const isCheckRows = computed(() => rowSelection.value.selectedRowKeys.length)

  /**
   * 导出
   */
  const aoaToExcel = async () => {
    exportLoading.value = true
    Object.assign(searchParams, exportPageParam)
    const {
      data: { list: exportData }
    } = await action.getWithPage(searchParams).finally(() => (exportLoading.value = false))
    const colFilters = columns.filter(n => n.dataIndex !== '$action')
    const colFilterKeys = colFilters.map(n => n.dataIndex)
    // 保证data顺序与header一致
    aoaToSheetXlsx({
      data: exportData
        .map(item => {
          return colFilterKeys.reduce((p, k) => {
            p[k] = Array.isArray(item[k]) ? item[k].toString() : item[k]
            return p
          }, {})
        })
        .map(item => Object.values(item)),
      header: colFilters.map(column => column.title),
      filename: `${route.meta.title}${formatToDateTime()}.xlsx`
    })
  }

  /**
   * 加载数据
   */
  const loadData = async params => {
    if (params?.createTime) {
      params.createTimeS = formatToDate(params.createTime[0])
      params.createTimeE = formatToDate(params.createTime[1])
      delete params.createTime
    }
    searchParams = params
    const { data } = await action.getWithPage(params)
    rowSelection.value.selectedRowKeys = []
    return { data }
  }

  /**
   * 打开新增/编辑弹窗
   */
  const openModal = async record => {
    const [formRef] = await showModal({
      modalProps: {
        title: `${record.id ? '编辑' : '新增'}数据`,
        width: '40%',
        onFinish: async values => {
          values.id = record.id
          const params = { ...values }
          console.log('新增/编辑参数', params)
          await (record.id ? action.update : action.add)(params)
          dynamicTableRef.value?.reload()
        }
      },
      formProps: {
        labelWidth: 100,
        layout: 'vertical',
        schemas: formSchemas
      }
    })

    if (record.id) {
      const { data } = await action.getById(record.id)

      formRef?.setFieldsValue({
        ...data
      })
    }
  }

  /**
   * 删除行数据
   */
  const delRowConfirm = async (id: number | number[]) => {
    if (Array.isArray(id)) {
      Modal.confirm({
        title: '确定要删除所选的数据吗?',
        icon: <ExclamationCircleOutlined />,
        centered: true,
        onOk: async () => {
          await action.delete(id)
          rowSelection.value.selectedRowKeys = []
          dynamicTableRef.value?.reload()
        }
      })
    } else {
      await action.delete([id])
      rowSelection.value.selectedRowKeys = []
      dynamicTableRef.value?.reload()
    }
  }

  /**
   * 表格列
   */
  const columns: TableColumn<any>[] = [
    {
      title: 'id',
      dataIndex: 'id',
      width: 55,
      align: 'center',
      hideInTable: true,
      hideInSearch: true
    },
    {
      title: '是否管理员',
      dataIndex: 'isSuper',
      align: 'center',
      bodyCell: ({ record }) => {
        return <Tag color={record.isSuper ? 'success' : 'red'}>{record.isSuper ? '是' : '否'}</Tag>
      },
      formItemProps: {
        component: 'Select',
        componentProps: {
          options: [
            {
              label: '是',
              value: 'true'
            },
            {
              label: '否',
              value: 'false'
            }
          ]
          // 动态赋值如下:
          // request: async () => {
          //   const { data } = await action.getWithPage({})
          //   return data.list.map(x => ({ label: x.id, value: x.addr }))
          // }
        }
      }
    },
    {
      title: '备注',
      dataIndex: 'remark',
      align: 'center',
      hideInSearch: true
    },
    {
      title: '创建人',
      dataIndex: 'createUser',
      align: 'center'
    },
    {
      title: '创建时间',
      align: 'center',
      dataIndex: 'createTime',
      formItemProps: {
        component: 'RangePicker',
        componentProps: {
          class: 'w-full'
        }
      }
    },
    {
      title: '更新时间',
      align: 'center',
      dataIndex: 'updateTime',
      hideInSearch: true
    },
    {
      title: '操作',
      width: 200,
      dataIndex: '$action',
      hideInSearch: true,
      align: 'center',
      fixed: 'right',
      actions: ({ record }) => [
        {
          label: '编辑',
          auth: {
            perm: '/api/api" + tblName + @"/Update',
            effect: 'disable'
          },
          onClick: () => openModal(record)
        },
        {
          label: '详情',
          onClick: () => router.push({ name: `${route.path}/detail`, params: { id: record.id } })
        },
        {
          label: '删除',
          danger: true,
          auth: {
            perm: '/api/api" + tblName + @"/Delete',
            effect: 'disable'
          },
          popConfirm: {
            title: '你确定要删除吗?',
            onConfirm: () => delRowConfirm(record.id)
          }
        }
      ]
    }
  ]

  const options = {
    options: [
      {
        label: '是',
        value: 'true'
      },
      {
        label: '否',
        value: 'false'
      }
    ]
  }

  /**
   * 表单信息
   */
  const formSchemas: FormSchema[] = [
    {
      field: 'realName',
      component: 'Input',
      label: '真实名',
      rules: [{ required: true, type: 'string' }]
    },
    {
      field: 'isSuper',
      defaultValue: 'false',
      component: 'Select',
      label: '是否管理员',
      componentProps: options
    },
    {
      field: 'gender',
      component: 'Select',
      rules: [{ required: true, type: 'string' }],
      label: '性别',
      componentProps: {
        options: [
          {
            label: '男',
            value: 0
          },
          {
            label: '女',
            value: 1
          }
        ]
      }
    },
    {
      field: 'remark',
      component: 'InputTextArea',
      label: '备注',
      colProps: {
        span: 24
      }
    }
  ]
</script>
";

                #endregion index.vue

                ls.Add(tblName, fileContent);
            }

            RenderTempKey(ls, fileFolderName, lstTableNames, out Dictionary<string, string> newdic);

            CreateVueFilesByClassStringList(newdic, vuePath, fileFolderName, "index.vue");

            ls = new Dictionary<string, string>();
            foreach (var tblName in lstTableNames)
            {
                #region 生成detail.vue

                var fileContent = @"<template>
  <a-card :bordered=""false"">
    <detail-list title=""用户信息"">
      <detail-item label=""用户姓名"">{{ model.realName }}</detail-item>
      <detail-item label=""联系电话"">18100000001</detail-item>
      <detail-item label=""常用快递"">菜鸟仓储</detail-item>
      <detail-item label=""取货地址"">浙江省杭州市西湖区万塘路19号</detail-item>
      <detail-item label=""备注"">无</detail-item>
    </detail-list>
    <a-divider style=""margin-bottom: 32px"" />
    <div class=""title"">退货商品</div>
    <dynamic-table
      row-key=""id""
      style=""margin-bottom: 24px""
      :columns=""goodsColumns""
      :dataSource=""goodsData""
      :pagination=""false""
      :search=""false""
    />
    <a-card
      style=""margin-top: 24px""
      :bordered=""false""
      :tabList=""tabList""
      :activeTabKey=""activeTabKey""
      @tab-change=""key => (activeTabKey = key)""
    >
      <dynamic-table
        v-if=""activeTabKey === '1'""
        row-key=""id""
        style=""margin-bottom: 24px""
        :columns=""goodsColumns""
        :dataSource=""goodsData""
        :pagination=""false""
        :search=""false""
      />
      <dynamic-table
        v-if=""activeTabKey === '2'""
        row-key=""id""
        style=""margin-bottom: 24px""
        :columns=""goodsColumns""
        :data-source=""dataSource""
        :pagination=""false""
        :search=""false""
      />
    </a-card>
  </a-card>
</template>

<script lang=""ts"">
  import { ref, defineComponent, watch } from 'vue'
  import { useRoute } from 'vue-router'
  import { DynamicTable } from '@/components/core/dynamic-table'
  import type { TableColumn } from '@/components/core/dynamic-table'
  import { useTabsViewStore } from '@/store/modules/tabsView'
  import DetailList from '@/components/basic/tool/DetailList.vue'
  import DetailItem from '@/components/basic/detail/DetailItem.vue'
  import action from '@/api/" + fileFolderName.FirstToLower() + @"/action" + tblName + @"'

  export default defineComponent({
    name: 'SysUserDetail',
    components: { DetailList, DynamicTable, DetailItem },
    setup() {
      const route = useRoute()
      const tabsViewStore = useTabsViewStore()
      let id: number = +route.params.id
      let dataSource = ref([])

      // TODO: 修改你的接口字段
      interface IModel {
        id: number
        realName: string
      }
      let model = ref<IModel>({
        id: 0,
        realName: ''
      })

      /**
       * 根据id获取单条数据
       */
      const getDetail = async (id: number) => {
        const { data } = await action.getById(id)
        model.value = { ...data }
        tabsViewStore.updateTabTitle(`${route.meta.title}(${data.realName})`)
      }
      getDetail(id)

      /**
       * 加载表格数据
       * @param params
       */
      const loadTabData = async params => {
        params.id = id
        const {
          data: { list }
        } = await action.getWithPage(params)
        dataSource.value = list
      }
      loadTabData({})

      let activeTabKey = ref('1')

      const tabList = [
        {
          key: '1',
          tab: '操作日志一'
        },
        {
          key: '2',
          tab: '操作日志二'
        }
      ]

      const goodsColumns: TableColumn<any>[] = [
        {
          title: '商品编号',
          dataIndex: 'id',
          align: 'center'
        },
        {
          title: '商品名称',
          dataIndex: 'realName',
          align: 'center'
        },
        {
          title: '商品条码',
          dataIndex: 'barcode',
          align: 'center'
        },
        {
          title: '单价',
          dataIndex: 'price',
          align: 'center'
        },
        {
          title: '数量（件）',
          dataIndex: 'num',
          align: 'center'
        },
        {
          title: '金额',
          dataIndex: 'amount',
          align: 'center'
        }
      ]

      const goodsData = [
        {
          id: '1234561',
          name: '矿泉水 550ml',
          barcode: '12421432143214321',
          price: '2.00',
          num: '1',
          amount: '2.00'
        },
        {
          id: '1234562',
          name: '凉茶 300ml',
          barcode: '12421432143214322',
          price: '3.00',
          num: '2',
          amount: '6.00'
        }
      ]

      return {
        dataSource,
        model,
        activeTabKey,
        tabList,
        goodsColumns,
        goodsData
      }
    }
  })
</script>

<style lang=""less"" scoped>
  .title {
    font-size: 16px;
    font-weight: 700;
    margin-bottom: 16px;
  }
</style>
";

                #endregion 生成detail.vue

                ls.Add(tblName, fileContent);
            }

            RenderTempKey(ls, fileFolderName, lstTableNames, out newdic);
            CreateVueFilesByClassStringList(newdic, vuePath, fileFolderName, "detail.vue");

            // 生成ts文件
            CreateTsFilesByClassStringList(IDbFirst, vuePath, fileFolderName, lstTableNames);
        }

        #endregion 查询表格(有详情页)

        #region 树状表格

        public static void Create_Vue_TreeTable_FileByDBTalbe(SqlSugarScope sqlSugarClient, string vuePath, string fileFolderName, string[] lstTableNames, string menuName)
        {
            var IDbFirst = sqlSugarClient.DbFirst;
            var ls = new Dictionary<string, string>();
            foreach (var tblName in lstTableNames)
            {
                #region 生成index.vue

                var fileContent = @"<template>
  <div>
    <DynamicTable
      ref=""dynamicTableRef""
      row-key=""id""
      header-title=""" + menuName + @"""
      :data-request=""loadData""
      :columns=""columns""
      bordered
      size=""small""
      :pagination=""false""
      :show-index=""false""
      :search=""false""
    >
      <template #toolbar>
        <a-button type=""primary"" v-if=""$auth('/api/api" + tblName + @"/Add')"" @click=""openModal({})"">
          新增
        </a-button>
      </template>
    </DynamicTable>
  </div>
</template>

<script lang=""tsx"">
  export default {
    name: 'Org'
  }
</script>

<script lang=""tsx"" setup>
  import { ref } from 'vue'
  import { TreeSelectProps, Tag } from 'ant-design-vue'
  import { formatTree } from '@/core/permission/utils'
  import { cloneDeep } from 'lodash-es'
  import { DynamicTable } from '@/components/core/dynamic-table'
  import { useFormModal } from '@/hooks/useModal/useFormModal'
  import type { FormSchema } from '@/components/core/schema-form/src/types/form'
  import type { TableColumn } from '@/components/core/dynamic-table'
  import action from '@/api/" + fileFolderName.FirstToLower() + @"/action" + tblName + @"'

  const tree = ref<TreeSelectProps['treeData']>([])
  const dynamicTableRef = ref<InstanceType<typeof DynamicTable>>()

  const [showModal] = useFormModal()

  /**
   * 加载数据
   */
  const loadData = async params => {
    params.pageSize = 999999
    const {
      data: { list }
    } = await action.getWithPage(params)
    tree.value = formatTree(cloneDeep(list), 'orgName', -1) // TODO: 替换orgName
    return { data: tree.value }
  }

  /**
   * 打开新增/编辑弹窗
   */
  const openModal = async record => {
    const [formRef] = await showModal({
      modalProps: {
        title: `${record.id ? '编辑' : '新增'}组织`,
        width: '40%',
        onFinish: async values => {
          values.id = record.id
          const params = { ...values }
          await (record.id ? action.update : action.add)(params)
          dynamicTableRef.value?.reload()
        }
      },
      formSchema: {
        labelWidth: 100,
        layout: 'vertical',
        schemas: formSchemas
      }
    })

    formRef.value?.updateSchema([
      {
        field: 'parentId',
        componentProps: {
          treeDefaultExpandedKeys: [-1].concat(record?.keyPath || []),
          treeData: [{ key: -1, name: '#', children: tree.value }]
        }
      }
    ])

    formRef?.setFieldsValue({
      ...record,
      parentId: record.parentId ?? -1
    })
  }

  /**
   * 删除行数据
   */
  const delRowConfirm = async (id: number) => {
    await action.delete([id])
    dynamicTableRef.value?.reload()
  }

  /**
   * 表格列
   */
  const columns: TableColumn<any>[] = [
    {
      title: 'id',
      dataIndex: 'id',
      width: 55,
      align: 'center',
      hideInTable: true,
      hideInSearch: true
    },
    {
      title: '组织编码',
      dataIndex: 'orgCode',
      align: 'center'
    },
    {
      title: '是否管理员',
      dataIndex: 'isSuper',
      align: 'center',
      bodyCell: ({ record }) => {
        return <Tag color={record.isSuper ? 'success' : 'red'}>{record.isSuper ? '是' : '否'}</Tag>
      },
      formItemProps: {
        component: 'Select',
        componentProps: {
          options: [
            {
              label: '是',
              value: 'true'
            },
            {
              label: '否',
              value: 'false'
            }
          ]
        }
      }
    },
    {
      title: '创建人',
      dataIndex: 'createUser',
      align: 'center'
    },
    {
      title: '创建时间',
      align: 'center',
      dataIndex: 'createTime',
      hideInSearch: true,
      formItemProps: {
        component: 'RangePicker',
        componentProps: {
          class: 'w-full'
        }
      }
    },
    {
      title: '操作',
      width: 200,
      dataIndex: '$action',
      hideInSearch: true,
      align: 'center',
      fixed: 'right',
      actions: ({ record }) => [
        {
          label: '编辑',
          auth: {
            perm: '/api/api" + tblName + @"/Update',
            effect: 'disable'
          },
          onClick: () => openModal(record)
        },
        {
          label: '删除',
          danger: true,
          auth: {
            perm: '/api/api" + tblName + @"/Delete',
            effect: 'disable'
          },
          popConfirm: {
            title: '你确定要删除吗?',
            onConfirm: () => delRowConfirm(record.id)
          }
        }
      ]
    }
  ]

  /**
   * 表单信息
   */
  const formSchemas: FormSchema[] = [
    {
      field: 'orgCode',
      component: 'Input',
      label: '组织编码',
      required: true
    },
    {
      field: 'orgName',
      component: 'Input',
      label: '组织名称',
      required: true
    },
    {
      field: 'parentId',
      component: 'TreeSelect',
      label: '上级组织',
      componentProps: {
        fieldNames: {
          label: 'name',
          value: 'key'
        },
        getPopupContainer: () => document.body
      },
      rules: [{ required: true, type: 'number' }]
    }
  ]
</script>
";

                #endregion 生成index.vue

                ls.Add(tblName, fileContent);
            }

            RenderTempKey(ls, fileFolderName, lstTableNames, out Dictionary<string, string> newdic);

            CreateVueFilesByClassStringList(newdic, vuePath, fileFolderName, "index.vue");
            CreateTsFilesByClassStringList(IDbFirst, vuePath, fileFolderName, lstTableNames);
        }

        #endregion 树状表格

        #region 左右分隔

        /// <summary>
        /// 生成左右分隔模板
        /// </summary>
        /// <param name="sqlSugarClient"></param>
        /// <param name="vuePath">vue配置的路径: xxx/views/sys</param>
        /// <param name="fileFolderName">存放的文件夹: Sys</param>
        /// <param name="lstTableNames">实体类名称: SysUser</param>
        public static void Create_Vue_LeftAndRightSplit_FileByDBTalbe(SqlSugarScope sqlSugarClient, string vuePath, string fileFolderName, string[] lstTableNames)
        {
            var IDbFirst = sqlSugarClient.DbFirst;
            var ls = new Dictionary<string, string>();
            foreach (var tblName in lstTableNames)
            {
                #region 生成index.vue

                var fileContent = @"<template>
  <SplitPanel>
    <template #left-content>
      <Spin :spinning=""listLoading"">
        <Input.Search v-model:value=""key"" placeholder=""请输入分类名称"" @search=""getCateList(key)"" />
        <list :data-source=""categoryList"">
          <template #renderItem=""{ item }"">
            <List.Item @click=""selectItemData(item)"" class=""listItem"">
              <a>{{ item?.description }}</a>
            </List.Item>
          </template>
        </list>
      </Spin>
    </template>
    <template #right-content>
      <DynamicTable
        ref=""dynamicTableRef""
        row-key=""id""
        :data-request=""loadData""
        :columns=""columns""
        :search=""false""
        bordered
        size=""small""
      >
        <template #toolbar>
          <a-button type=""primary"" v-if=""$auth('/api/api" + tblName + @"/Add')"" @click=""openModal({})"">
            新增
          </a-button>
        </template>
      </DynamicTable>
    </template>
  </SplitPanel>
</template>

<script lang=""tsx"" setup>
  import { reactive, ref } from 'vue'
  import { Input, List, Spin, Tag } from 'ant-design-vue'
  import { SplitPanel } from '@/components/basic/split-panel'
  import { DynamicTable } from '@/components/core/dynamic-table'
  import { useFormModal } from '@/hooks/useModal/useFormModal'
  import type { FormSchema } from '@/components/core/schema-form/src/types/form'
  import type { TableColumn } from '@/components/core/dynamic-table'
  import action from '@/api/" + fileFolderName.FirstToLower() + @"/action" + tblName + @"'

  defineOptions({
    name: 'name" + tblName + @"'
  })

  const dynamicTableRef = ref<InstanceType<typeof DynamicTable>>()

  const [showModal] = useFormModal()
  const key = ref('')
  const listLoading = ref(false)
  const categoryList = ref<Array<State>>([])

  interface State {
    id: number
    code: string
    description: string
    categoryCode: string
    categoryName: string
  }
  let state = reactive<State>({
    id: 0,
    code: '',
    description: '',
    categoryCode: '',
    categoryName: ''
  })

  /**
   * 加载数据
   */
  const loadData = async params => {
    if (!state.code) {
      return { data: [] }
    }
    params.categoryCode = state.code
    const { data } = await action.getWithPage(params)
    return { data }
  }

  /**
   * 点击左侧列表
   * @param item
   */
  const selectItemData = async (item: State) => {
    state = { ...item }
    dynamicTableRef.value?.reload()
  }

  /**
   * 获取所有分类
   * @param key 分类名称
   */
  const getCateList = async (key?: string) => {
    listLoading.value = true
    const { data } = await action.getCateoryList(key).finally(() => (listLoading.value = false))
    categoryList.value = data
  }
  getCateList()

  /**
   * 打开新增/编辑弹窗
   */
  const openModal = async record => {
    const [formRef] = await showModal({
      modalProps: {
        title: `${record.id ? '编辑' : '新增'}数据`,
        width: '30%',
        onFinish: async values => {
          values.id = record.id
          const params = { ...values }
          params.categoryCode = state.code
          params.categoryName = state.description
          console.log('新增/编辑参数', params)
          await (record.id ? action.update : action.add)(params)
          dynamicTableRef.value?.reload()
          getCateList(key.value)
        }
      },
      formProps: {
        labelWidth: 100,
        layout: 'vertical',
        schemas: formSchemas
      }
    })

    if (record.id) {
      const { data } = await action.getById(record.id)

      formRef?.setFieldsValue({
        ...data
      })
    }
  }

  /**
   * 删除行数据
   */
  const delRowConfirm = async record => {
    await action.delete([record.id])
    dynamicTableRef.value?.reload()
    getCateList(key.value)
  }

  /**
   * 表格列
   */
  const columns: TableColumn<any>[] = [
    {
      title: 'id',
      dataIndex: 'id',
      width: 55,
      align: 'center',
      hideInTable: true,
      hideInSearch: true
    },
    {
      title: '编码',
      dataIndex: 'code',
      width: 80,
      align: 'center'
    },
    {
      title: '描述',
      dataIndex: 'description',
      width: 80,
      align: 'center'
    },
    {
      title: '分类编码',
      dataIndex: 'categoryCode',
      width: 80,
      align: 'center'
    },
    {
      title: '分类名称',
      dataIndex: 'categoryName',
      width: 80,
      align: 'center'
    },
    {
      title: '排序',
      dataIndex: 'sortNo',
      width: 55,
      align: 'center'
    },
    {
      title: '创建人',
      dataIndex: 'createUser',
      align: 'center'
    },
    {
      title: '操作',
      width: 200,
      dataIndex: '$action',
      hideInSearch: true,
      align: 'center',
      fixed: 'right',
      actions: ({ record }) => [
        {
          label: '编辑',
          auth: {
            perm: '/api/api" + tblName + @"/Update',
            effect: 'disable'
          },
          onClick: () => openModal(record)
        },
        {
          label: '删除',
          danger: true,
          auth: {
            perm: '/api/api" + tblName + @"/Delete',
            effect: 'disable'
          },
          popConfirm: {
            title: '你确定要删除吗?',
            onConfirm: () => delRowConfirm(record)
          }
        }
      ]
    }
  ]

  /**
   * 表单信息
   */
  const formSchemas: FormSchema[] = [
    {
      field: 'code',
      component: 'Input',
      label: '编码',
      rules: [{ required: true, type: 'string' }]
    },
    {
      field: 'description',
      component: 'Input',
      label: '描述',
      rules: [{ required: true, type: 'string' }]
    },
    {
      field: 'sortNo',
      defaultValue: 0,
      component: 'InputNumber',
      label: '排序',
      rules: [{ required: true }]
    }
  ]
</script>
<style lang=""less"" scoped>
  .listItem {
    display: flex;
    justify-content: center;
  }
</style>
";

                #endregion 生成index.vue

                ls.Add(tblName, fileContent);
            }

            RenderTempKey(ls, fileFolderName, lstTableNames, out Dictionary<string, string> newdic);

            CreateVueFilesByClassStringList(newdic, vuePath, fileFolderName, "index.vue");
            CreateTsFilesByClassStringList(IDbFirst, vuePath, fileFolderName, lstTableNames);
        }

        #endregion 左右分隔

        #region 统一处理模板的Key

        /// <summary>
        /// 统一处理模板的Key
        /// </summary>
        /// <param name="ls"></param>
        /// <param name="fileFolderName"></param>
        /// <param name="lstTableNames"></param>
        /// <param name="newdic"></param>
        private static void RenderTempKey(Dictionary<string, string> ls, string fileFolderName, string[] lstTableNames, out Dictionary<string, string> newdic)
        {
            newdic = new Dictionary<string, string>();
            //循环处理 SysUser --> @/api/sys/user 并插入新的 Dictionary
            foreach (KeyValuePair<string, string> item in ls)
            {
                // key优先从lstTableNames中获取, 否则在重复生成时候，生成的vue文件时不是想要的效果
                string? key = lstTableNames?.Where(tabName => tabName.Equals(item.Key, StringComparison.OrdinalIgnoreCase))
                                            .Select(x => x).FirstOrDefault();
                if (string.IsNullOrEmpty(key))
                {
                    key = item.Key;
                }
                string newkey = key.Replace($"{fileFolderName}_", "").Replace(fileFolderName, "").FirstToLower();
                string newvalue = item.Value.Replace(item.Key, newkey)
                                            .Replace("action" + newkey, newkey)// --> @/api/sys/user
                                            .Replace("api" + newkey, key)// --> @/api/SysUser/xxx
                                            .Replace("name" + newkey, newkey.FirstToUpper());// 解决vue导出的name警告
                newdic.Add(key, newvalue);
            }
        }

        #endregion 统一处理模板的Key

        #region 生成api请求 index.ts 文件

        /// <summary>
        /// 生成api请求 index.ts 文件
        /// </summary>
        /// <param name="IDbFirst"></param>
        /// <param name="vuePath"></param>
        /// <param name="fileFolderName"></param>
        private static void CreateTsFilesByClassStringList(IDbFirst IDbFirst, string vuePath, string fileFolderName, string[] lstTableNames)
        {
            var tsLst = new Dictionary<string, string>();
            foreach (var tblName in lstTableNames)
            {
                #region index.ts

                var ts = @"import { http } from '@/api/http'

export default {
  /**
   * 获取分页列表
   * @param query
   * @returns
   */
  getWithPage: (query: API.PageParams) =>
    http.get<API.TableListResult>('/" + tblName + @"/GetWithPage', query),

  /**
   * 根据Id获取单条
   * @param id
   * @returns
   */
  getById: (id: number) => http.get(`/" + tblName + @"/Get/${id}`),

  /**
   * 新增一条数据
   * @param data
   * @returns
   */
  add: (data: any) => http.post(`/" + tblName + @"/Add`, data),

  /**
   * 删除数据
   * @param ids 主键Ids
   * @returns
   */
  delete: (ids: number[]) => http.delete(`/" + tblName + @"/Delete`, { ids: ids.join(',') }),

  /**
   * 更新数据
   * @param data
   * @returns
   */
  update: (data: any) => http.put(`/" + tblName + @"/Update`, data),
}
";

                #endregion index.ts

                tsLst.Add(tblName, ts);
            }

            Dictionary<string, string> newdic = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> item in tsLst)
            {
                // key优先从lstTableNames中获取, 否则在重复生成时候，生成的vue文件时不是想要的效果
                string? key = lstTableNames.Where(tabName => tabName.Equals(item.Key, StringComparison.OrdinalIgnoreCase))
                                           .Select(x => x).FirstOrDefault();
                if (string.IsNullOrEmpty(key))
                {
                    key = item.Key;
                }
                string newValue = item.Value.Replace(item.Key, key);
                newdic.Add(key, newValue);
            }
            var tsPath = vuePath.Replace("\\views", "\\api");
            CreateVueFilesByClassStringList(newdic, tsPath, fileFolderName, "index.ts");
        }

        #endregion 生成api请求 index.ts 文件

        #endregion 根据数据库表生成 Vue 文件

        #region 根据模板内容批量生成文件

        /// <summary>
        /// 根据模板内容批量生成文件
        /// </summary>
        /// <param name="ls">类文件字符串list</param>
        /// <param name="strPath">生成路径</param>
        /// <param name="fileNameTp">文件名格式模板</param>
        private static void CreateFilesByClassStringList(Dictionary<string, string> ls, string strPath, string fileNameTp)
        {
            foreach (var item in ls)
            {
                var fileName = $"{string.Format(fileNameTp, item.Key)}.cs";
                var fileFullPath = Path.Combine(strPath, fileName);
                if (!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                }
                if (!File.Exists(fileFullPath))
                {
                    File.WriteAllText(fileFullPath, item.Value, Encoding.UTF8);
                }
            }
        }

        #endregion 根据模板内容批量生成文件

        #region 根据模板内容生成Vue文件

        /// <summary>
        /// 根据模板内容生成Vue文件
        /// </summary>
        /// <param name="ls">类文件字符串list</param>
        /// <param name="strPath">生成路径: xxx/views/sys</param>
        /// <param name="fileFolderName">文件夹名称: Sys</param>
        /// <param name="fileName">文件名(全称，包含后缀): index.vue</param>
        private static void CreateVueFilesByClassStringList(Dictionary<string, string> ls, string strPath, string fileFolderName, string fileName)
        {
            foreach (var item in ls)
            {
                // xxx/views/sys  --> xxx/views/sys/user
                strPath = Path.Combine(strPath, item.Key.Replace($"{fileFolderName}_", "").Replace(fileFolderName, "").FirstToLower());
                var fileFullPath = Path.Combine(strPath, fileName);
                if (!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                }
                if (!File.Exists(fileFullPath))
                {
                    File.WriteAllText(fileFullPath, item.Value, Encoding.UTF8);
                }
            }
        }

        #endregion 根据模板内容生成Vue文件
    }
}