using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMom.Application;
using TMom.Application.Dto;
using TMom.Application.Dto.Sys;
using TMom.Application.Service.IService;
using TMom.Domain.Model;
using TMom.Domain.Model.Entity;
using TMom.Infrastructure.Common;
using TMom.Infrastructure.Helper;
using SqlSugar;
using static TMom.Domain.Model.GlobalVars;

namespace TMom.Api.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
	[Route("api/[controller]/[action]")]
    [ApiController]
    public class SysUserController : BaseApiController<SysUser, int>
    {
        /// <summary>
        /// 模板生成
        /// </summary>
        private readonly ISysUserService _sysUserService;

        private readonly IUser _user;
        private readonly IMapper _mapper;
        private ISysMenuService _sysMenuService;
        private readonly ISysOrgService _sysOrgService;
        private IWebHostEnvironment _webHostEnvironment;
        private readonly ISysUserRoleService _sysUserRoleService;

        public SysUserController(ISysUserService SysUserService, IUser user, IMapper mapper
            , ISysMenuService sysMenuService, ISysOrgService sysOrgService
            , IWebHostEnvironment webHostEnvironment, ISysUserRoleService sysUserRoleService)
        {
            _sysUserService = SysUserService;
            _user = user;
            _mapper = mapper;
            _sysMenuService = sysMenuService;
            _sysOrgService = sysOrgService;
            _webHostEnvironment = webHostEnvironment;
            _sysUserRoleService = sysUserRoleService;
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="orgId">组织架构Id</param>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<PageModel<SysUser>>> GetWithPage(int? orgId, int pageIndex = 1, int pageSize = 10)
        {
            PageModel<SysUser> data = await _sysUserService.GetWithPage(DynamicFilterExpress(), orgId, pageIndex, pageSize);
            return Success(data);
        }

        /// <summary>
        /// 缓存中获取用户基本信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<SysUserCacheDto>>> GetAllUserWithCache()
        {
            var dataList = await CommonCache.GetAllUserWithCache();
            return Success(dataList);
        }

        /// <summary>
        /// 登录后根据token获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<MessageModel<userInfoDto>> GetUserInfo()
        {
            var uId = _user.Id;
            if (uId == 0)
            {
                return Failed<userInfoDto>($"token解析失败，请确保已登录或检查请求头格式：'Bearer ' + token", 401);
            }
            var user = await _sysUserService.QueryById(uId);
            var userDto = _mapper.Map<userInfoDto>(user) ?? new userInfoDto();
            userDto.loginIp = IpHelper.GetCurrentIp("");

            return Success(userDto);
        }

        /// <summary>
        /// 获取用户权限菜单(tree)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<MessageModel<PermMenuDto>> GetPermMenu()
        {
            PermMenuDto permMenu = await _sysMenuService.GetMenusByUserId(_user.Id);
            return Success(permMenu);
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<MessageModel<SysUser>> Get(string id)
        {
            var entity = await _sysUserService.QueryById(id);
            if (entity == null || entity.Id <= 0)
            {
                return Failed<SysUser>($"主键:{id}不存在或已被删除!");
            }
            entity.Password = null;
            var sysUserRole = await _sysUserRoleService.Query(x => x.SysUserId == entity.Id);
            entity.SysRoleIds = sysUserRole.Select(x => x.SysRoleId).ToList();
            return new MessageModel<SysUser>()
            {
                msg = "获取成功",
                success = true,
                data = entity
            };
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Add([FromBody] SysUser request)
        {
            var res = new MessageModel<string>();
            request.Password = MD5Helper.MD5Encrypt32(SystemInfo.defPwd);
            request.UpdateCommonFields(_user.Id);
            var Id = await _sysUserService.Add(request);

            // 角色
            var sysUserRoleList = new List<SysUserRole>();
            foreach (var roleId in request.SysRoleIds)
            {
                var sysUserRole = new SysUserRole()
                {
                    SysUserId = Id,
                    SysRoleId = roleId
                };
                sysUserRole.UpdateCommonFields(_user.Id);
                sysUserRoleList.Add(sysUserRole);
            }
            await _sysUserRoleService.Add(sysUserRoleList);

            if (Id > 0)
            {
                await _sysUserService.RefreshAllUserCache();
                res.success = true;
                res.data = Id.ObjToString();
                res.msg = "添加成功";
            }

            return res;
        }

        /// <summary>
        /// 修改/重置密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pwd">新密码</param>
        /// <param name="oldPwd">旧密码</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<string>> EditPwd(int id, string? pwd = "", string? oldPwd = "")
        {
            var res = new MessageModel<string>();
            var user = await _sysUserService.QueryById(id);
            if (!string.IsNullOrEmpty(oldPwd) && MD5Helper.MD5Encrypt32(oldPwd) != user.Password)
            {
                return Failed("旧密码输入有误!");
            }
            user.Password = MD5Helper.MD5Encrypt32(pwd ?? SystemInfo.defPwd);
            user.UpdateCommonFields(_user.Id, false);
            res.success = await _sysUserService.Update(user);
            if (res.success)
            {
                res.success = true;
                res.data = id.ToString();
                res.msg = "更新密码成功!";
            }

            return res;
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> ResetPwd(int id)
        {
            var res = await EditPwd(id);
            return res;
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="request"></param>
        /// <returns>修改的主键Id</returns>
        [HttpPut]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Update([FromBody] SysUser request)
        {
            var entity = await _sysUserService.QueryById(request.Id);
            if (entity == null) return Failed($"用户Id: {request.Id}不存在或已被删除!");
            bool isSuccess = await _sysUserService.UpdateData(request, _user.Id);
            if (isSuccess && (request.LoginAccount != entity.LoginAccount || request.RealName != entity.RealName || request.Email != entity.Email || request.IsSuper != entity.IsSuper))
            {
                await _sysUserService.RefreshAllUserCache();
            }
            return isSuccess ? Success() : Failed();
        }

        /// <summary>
        /// 修改个人基本信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<MessageModel<string>> UpdateBaseInfo([FromBody] userInfoDto request)
        {
            var user = await _sysUserService.QueryById(request.id);
            if (user == null)
            {
                return Failed($"用户Id：【{request.id}】不存在!");
            }
            user.RealName = request.realName;
            user.PhoneNo = request.phoneNo;
            user.Email = request.email;
            user.Addr = request.addr;
            user.Remark = request.remark;
            user.UpdateCommonFields(_user.Id, false);
            return await _sysUserService.Update(user) ? Success() : Failed();
        }

        /// <summary>
        /// 根据主键Id删除数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Delete(string ids)
        {
            var res = new MessageModel<string>();
            string[] _ids = ids.Split(',');
            var entityList = await _sysUserService.Query(x => _ids.Contains(x.Id.ToString()));
            if (entityList == null || !entityList.Any())
            {
                return Failed($"主键: {ids}均不存在或已被删除!");
            }
            entityList.ForEach(entity => entity.MarkedAsDeleted(_user.Id));
            res.success = await _sysUserService.Update(entityList);
            if (res.success)
            {
                res.msg = "删除成功";
                res.data = ids;
            }

            return res;
        }

        /// <summary>
        /// 获取导入模板
        /// </summary>
        /// <param name="fileName">模板名称</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetImportTemplate(string? fileName = "导入模板.xlsx")
        {
            var result = ExcelHelper.GetTemplate<ImportSysUserDto>(fileName);
            return result;
        }

        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<string>> Import([FromForm] UploadFileDto dto)
        {
            var file = dto.file.FirstOrDefault();
            var result = ExcelHelper.GetImportResult<ImportSysUserDto>(file);
            var dataList = result.Data;
            // TODO
            await _sysUserService.QueryById(1);
            return Success("导入成功!");
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="fileName">导出文件名称</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Export(string? fileName = "用户数据.xlsx")
        {
            var data = await _sysUserService.Query();
            var result = ExcelHelper.Export(fileName, data);
            return result;
        }
    }
}