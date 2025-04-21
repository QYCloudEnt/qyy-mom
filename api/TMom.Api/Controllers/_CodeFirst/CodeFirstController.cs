using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMom.Application;
using TMom.Application.Dto;
using TMom.Application.Service;
using TMom.Application.Service.IService;
using TMom.Domain.Model;
using TMom.Domain.Model.Params;
using TMom.Domain.Model.Seed;
using TMom.Infrastructure.Common;
using TMom.Infrastructure.Helper;
using SqlSugar;
using System.Reflection;
using static TMom.Domain.Model.GlobalVars;

namespace TMom.Api.Controllers._CodeFirst
{
    /// <summary>
    /// CodeFirst创建各层代码文件
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CodeFirstController : ControllerBase
    {
        private readonly SqlSugarScope _sqlSugarClient;
        private readonly IWebHostEnvironment Env;
        private readonly MyContext _context;
        private readonly ISysMenuService _sysMenuService;
        private readonly ISysRoleMenuService _sysRoleMenuService;
        private readonly PermissionRequirement _requirement;
        private readonly IUser _user;

        /// <summary>
        /// 构造函数
        /// </summary>
        public CodeFirstController(ISqlSugarClient sqlSugarClient, IWebHostEnvironment env, MyContext context
            , ISysMenuService sysMenuService, ISysRoleMenuService sysRoleMenuService, PermissionRequirement permissionRequirement
            , IUser user)
        {
            _sqlSugarClient = sqlSugarClient as SqlSugarScope;
            Env = env;
            _context = context;
            _sysMenuService = sysMenuService;
            _sysRoleMenuService = sysRoleMenuService;
            _requirement = permissionRequirement;
            _user = user;
        }

        #region 表迁移

        /// <summary>
        /// DBMigration
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> DbMigration(MigrationDto dto)
        {
            if (_user.Id != 1) return new MessageModel<string>() { success = false, msg = $"你没有操作权限, 操作用户必须是系统管理员!" };
            var list = DBSeed.GetTableEntityType();
            var modelTypes = list.Where(x => dto.tblNames.Contains(x.Name));
            if (!modelTypes.Any())
            {
                return new MessageModel<string>() { success = false, msg = $"没有找到表对应的实体类!" };
            }
            var mainDBTypes = modelTypes.ToList();
            mainDBTypes.ForEach(t =>
            {
                if (t.GetCustomAttributes().Any(x => x is SplitTableAttribute))
                {
                    _context.Db.CodeFirst.SplitTables().InitTables(t);
                }
                else
                {
                    _context.Db.CodeFirst.InitTables(t);
                }
            });
            return new MessageModel<string>() { status = 200, success = true, msg = "成功!" };
        }

        #endregion 表迁移

        #region 生成代码文件

        /// <summary>
        /// CodeFirst 根据实体类 生成数据库表和各层文件
        /// </summary>
        /// <param name="param">参数</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<string>> GetAllFrameFilesByEntities(CodeFirstParams param)
        {
            #region 校验

            if (param.createVue && !Appsettings.app(new string[] { "VueConfig", "Enabled" }).ObjToBool())
            {
                return new MessageModel<string>() { success = false, msg = $"没有开启Vue配置项，请在appsetting.json中开启!" };
            }
            var modelTypes = DBSeed.GetTableEntityType().Where(x => param.tableNames.Contains(x.Name)).ToList();
            if (!modelTypes.Any())
            {
                return new MessageModel<string>() { success = false, msg = $"没有找到表对应的实体类!" };
            }
            bool isSplitTable = modelTypes.Any(x => x.GetCustomAttributes().Any(t => t is SplitTableAttribute));
            if (modelTypes.Count() > 1 && isSplitTable && modelTypes.Any(x => !x.GetCustomAttributes().Any(t => t is SplitTableAttribute)))
            {
                return new MessageModel<string>() { success = false, msg = $"表属性只能为一种, 都分表或都不分表!" };
            }

            #endregion 校验

            param.connID = param.connID == null ? MainDb.CurrentDbConnId.ToLower() : param.connID;

            var res = new MessageModel<string>() { success = true, msg = "生成成功!" };
            if (Env.IsDevelopment())
            {
                // 1.生成表
                InitTable(modelTypes, param, res);

                // 2.生成Vue
                if (param.createVue && Appsettings.app(new string[] { "VueConfig", "Enabled" }).ObjToBool())
                {
                    await AddVue(param, res);
                }

                // 3.生成接口文件
                string tKey = isSplitTable ? "long" : "int"; // 分表使用long作为主键类型
                res.data += $"库{param.connID}-IService层生成：{FrameSeed.CreateIServices(_sqlSugarClient, param.connID, false, param.tableNames, param.fileName, tKey)} <br /> ";
                res.data += $"库{param.connID}-Service层生成：{FrameSeed.CreateServices(_sqlSugarClient, param.connID, false, param.tableNames, param.fileName, tKey)} <br /> ";
                res.data += $"库{param.connID}-IRepository层生成：{FrameSeed.CreateIRepositorys(_sqlSugarClient, param.connID, false, param.tableNames, param.fileName, tKey)} <br /> ";
                res.data += $"库{param.connID}-Repository层生成：{FrameSeed.CreateRepository(_sqlSugarClient, param.connID, false, param.tableNames, param.fileName, tKey)} <br /> ";
                res.data += $"Controller层生成：{FrameSeed.CreateControllers(_sqlSugarClient, param.connID, false, param.tableNames, $@"{Env.ContentRootPath}\Controllers\{param.fileName}", param.menuName, tKey)} ";
            }
            else
            {
                res.success = false;
                res.msg = "当前不处于开发模式，代码生成不可用!";
            }

            return res;
        }

        #region 私有方法

        /// <summary>
        /// 生成表
        /// </summary>
        /// <param name="modelTypes"></param>
        /// <param name="param"></param>
        /// <param name="res"></param>
        private void InitTable(List<Type> modelTypes, CodeFirstParams param, MessageModel<string> res)
        {
            var mainDBTypes = modelTypes.ToList();
            mainDBTypes.ForEach(t =>
            {
                var tblName = DBSeed.GetRealTableName(t);
                if (!string.IsNullOrEmpty(tblName) && !_context.Db.DbMaintenance.IsAnyTable(tblName))
                {
                    bool isSpiltTable = t.GetCustomAttributes().Any(c => c is SplitTableAttribute);
                    if (isSpiltTable)
                    {
                        _context.Db.CodeFirst.SplitTables().InitTables(t);
                    }
                    else
                    {
                        _context.Db.CodeFirst.InitTables(t);
                    }
                    res.data += $"库{param.connID}-表: {tblName}创建成功 <br /> ";
                }
            });
        }

        /// <summary>
        /// 创建vue页面
        /// </summary>
        /// <param name="param"></param>
        /// <param name="res"></param>
        private async Task AddVue(CodeFirstParams param, MessageModel<string> res)
        {
            string vuePath = $@"{SystemInfo.VuePath}\{param.fileName.FirstToLower()}" ?? $@"C:\my-file\Vue";
            switch (param.vueTemplate)
            {
                case vueTemp.searchTable:
                    FrameSeed.Create_Vue_SearchTable_FileByDBTalbe(_sqlSugarClient, vuePath, param.fileName, param.tableNames);
                    await _sysMenuService.addMenuAndPermForIndex(param);
                    break;

                case vueTemp.searchTableHasDetail:
                    FrameSeed.Create_Vue_SearchTableHasDetail_FileByDBTalbe(_sqlSugarClient, vuePath, param.fileName, param.tableNames);
                    await _sysMenuService.addMenuAndPermForIndexDetail(param);
                    break;

                case vueTemp.treeTable:
                    FrameSeed.Create_Vue_TreeTable_FileByDBTalbe(_sqlSugarClient, vuePath, param.fileName, param.tableNames, param.menuName);
                    await _sysMenuService.addMenuAndPermForIndex(param);
                    break;

                case vueTemp.leftAndRightSplit:
                    FrameSeed.Create_Vue_LeftAndRightSplit_FileByDBTalbe(_sqlSugarClient, vuePath, param.fileName, param.tableNames);
                    await _sysMenuService.addMenuAndPermForIndex(param);
                    break;
            }
            await refreshPerm();
            res.data += $"Vue页面生成路径：{vuePath} <br /> ";
        }

        /// <summary>
        /// 刷新权限列表
        /// </summary>
        private async Task refreshPerm()
        {
            if (!Permissions.IsUseIds4)
            {
                var data = await _sysRoleMenuService.RoleMenuMaps();
                var list = (from item in data
                            where item.IsDeleted == false && item.SysMenu.Type == 2
                            orderby item.Id
                            select new PermissionItem
                            {
                                Url = item.SysMenu?.LinkUrl,
                                Role = item.SysRole?.RoleName,
                            }).ToList();

                _requirement.Permissions = list;
            }
        }

        #endregion 私有方法

        /// <summary>
        /// 获取vue配置路径
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public MessageModel<string> GetVuePath()
        {
            string path = Appsettings.app(new string[] { "VueConfig", "ViewPath" });
            return new MessageModel<string>() { success = true, msg = $"获取成功!", data = path };
        }

        #endregion 生成代码文件
    }
}