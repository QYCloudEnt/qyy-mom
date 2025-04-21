using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMom.Application;
using TMom.Application.Dto.Sys;
using TMom.Application.Service;
using TMom.Application.Service.IService;
using TMom.Domain.Model;
using TMom.Domain.Model.Entity;
using TMom.Infrastructure.Helper;
using static TMom.Domain.Model.GlobalVars;

namespace TMom.Api.Controllers
{
    /// <summary>
    /// 菜单
    /// </summary>
	[Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Permissions.Name)]
    public class SysMenuController : BaseApiController<SysMenu, int>
    {
        /// <summary>
        /// 模板生成
        /// </summary>
        private readonly ISysMenuService _sysMenuService;

        private readonly IUser _user;
        private readonly ISysRoleMenuService _roleMenuService;
        private readonly ISysRoleService _sysRoleService;
        private readonly PermissionRequirement _permissionRequirement;
        private readonly ISysUserRoleService _sysUserRoleService;
        private readonly IWebHostEnvironment Env;

        public SysMenuController(ISysMenuService SysMenuService, IUser user
            , ISysRoleMenuService roleMenuService, ISysRoleService sysRoleService
            , PermissionRequirement permissionRequirement, ISysUserRoleService sysUserRoleService, IWebHostEnvironment env)
        {
            _sysMenuService = SysMenuService;
            _user = user;
            _roleMenuService = roleMenuService;
            _sysRoleService = sysRoleService;
            _permissionRequirement = permissionRequirement;
            _sysUserRoleService = sysUserRoleService;
            Env = env;
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<PageModel<SysMenu>>> GetWithPage(int pageIndex = 1, int pageSize = 10)
        {
            return new MessageModel<PageModel<SysMenu>>()
            {
                msg = "获取成功",
                success = true,
                data = await _sysMenuService.QueryPage(DynamicFilterExpress().Item1, pageIndex, pageSize)
            };
        }

        /// <summary>
        /// 获取菜单列表(不是tree)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<MessageModel<List<Menu>>> GetMenuList()
        {
            var menuList = await _sysMenuService.Query(x => !x.IsDeleted);
            // 非开发环境去除 代码生成 页面
            if (!Env.IsDevelopment())
            {
                menuList = menuList.Where(x => x.LinkUrl != "/dev/autocode").ToList();
            }
            var list = (from menu in menuList
                        select new Menu()
                        {
                            id = menu.Id,
                            parentId = menu.ParentId,
                            icon = menu.Icon,
                            name = menu.MenuName,
                            type = menu.Type,
                            isShow = menu.IsShow,
                            keepalive = menu.IsKeepAlive,
                            router = menu.LinkUrl,
                            viewPath = menu.ViewPath,
                            perms = menu.Type == 2 ? menu.LinkUrl : "",
                            orderNum = menu.OrderSort,
                            isExternal = menu.IsExternal,
                            isEmbed = menu.IsEmbed,
                            externalRouteName = menu.IsExternal ? menu.LinkUrl : "",
                            externalUrl = menu.IsExternal ? menu.ViewPath : ""
                        })
                        .OrderBy(x => x.orderNum)
                        .ToList();
            return Success(list);
        }

        /// <summary>
        /// 获取api权限列表(反射获取)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public MessageModel<List<string>> GetPermList()
        {
            var permList = _sysMenuService.GetPermList();
            return Success(permList);
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<MessageModel<SysMenu>> Get(int id)
        {
            var entity = await _sysMenuService.QueryById(id);
            if (entity == null || entity.Id <= 0)
            {
                return Failed<SysMenu>($"主键:{id}不存在或已被删除!");
            }
            return new MessageModel<SysMenu>()
            {
                msg = "获取成功",
                success = true,
                data = entity
            };
        }

        /// <summary>
        /// 根据角色Id获取角色菜单
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<MessageModel<List<SysMenu>>> GetMenuByRoleId(int roleId)
        {
            var roleMenuIds = (await _roleMenuService.Query(x => x.SysRoleId == roleId)).Select(x => x.SysMenuId).Distinct().ToList();
            var menu = await _sysMenuService.Query(x => roleMenuIds.Contains(x.Id));
            return Success(menu);
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<string>> Add([FromBody] Menu request)
        {
            var res = new MessageModel<string>();
            var sameMenu = await _sysMenuService.QuerySingle(x => x.MenuName == request.name && x.Type != 2);
            if (sameMenu != null) return Failed($"已存在相同的菜单名称!");
            var entity = new SysMenu();
            mapEntity(request, entity);
            entity.UpdateCommonFields(_user.Id);
            var Id = await _sysMenuService.Add(entity);
            var adminRole = await _sysRoleService.QuerySingle(x => x.RoleName == "系统管理员");
            if (adminRole != null && adminRole.Id > 0)
            {
                // 新增菜单时，给管理员默认添加此菜单权限
                var roleMenu = new SysRoleMenu()
                {
                    SysRoleId = adminRole.Id,
                    SysMenuId = Id
                };
                roleMenu.UpdateCommonFields(_user.Id);
                await _roleMenuService.Add(roleMenu);
            }
            if (Id > 0)
            {
                if (request.type == 2)
                {
                    await addPermToPermRequirement(request.perms);
                }
                res.success = true;
                res.data = Id.ObjToString();
                res.msg = "添加成功";
            }

            return res;
        }

        /// <summary>
        /// 动态刷新权限
        /// 权限变动时，追加新的权限到当前用户角色权限列表中
        /// </summary>
        /// <param name="apiUrl"></param>
        private async Task addPermToPermRequirement(string apiUrl)
        {
            if (string.IsNullOrEmpty(apiUrl)) return;
            var userRoleIds = (await _sysUserRoleService.Query(x => x.SysUserId == _user.Id)).Select(x => x.SysRoleId);
            var roles = (await _sysRoleService.Query(x => userRoleIds.Contains(x.Id))).Select(x => x.RoleName);
            foreach (var role in roles)
            {
                if (!_permissionRequirement.Permissions.Any(x => x.Role == role && x.Url == apiUrl))
                {
                    _permissionRequirement.Permissions.Add(new PermissionItem() { Role = role, Url = apiUrl });
                }
            }
        }

        /// <summary>
        /// 处理 Add/Update 实体
        /// </summary>
        /// <param name="request"></param>
        /// <param name="entity"></param>
        private void mapEntity(Menu request, SysMenu entity)
        {
            // 也可以使用autoMap映射
            entity.Icon = request.icon;
            entity.MenuName = request.name;
            entity.IsShow = request.isShow;
            entity.OrderSort = request.orderNum;
            entity.ParentId = request.parentId == -1 ? null : request.parentId;
            entity.LinkUrl = request.router;
            entity.Type = request.type;
            entity.IsKeepAlive = request.keepalive;
            entity.ViewPath = request.viewPath;
            entity.IsExternal = request.isExternal;
            entity.IsEmbed = request.isEmbed;
            if (request.type == 1)
            {
                entity.LinkUrl = $"/{request.viewPath?.Replace("/index", "")}".Replace(@"//", "/");
                if (!request.isShow)
                {
                    // 子页面
                    entity.LinkUrl = $"{entity.LinkUrl}/:id";
                }
                if (request.isExternal)
                {
                    entity.LinkUrl = request.externalRouteName;
                    entity.ViewPath = request.externalUrl;
                }
            }
            else if (request.type == 2)
            {
                entity.LinkUrl = request.perms;
            }
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="request"></param>
        /// <returns>修改的主键Id</returns>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] Menu request)
        {
            var res = new MessageModel<string>();
            var entity = await _sysMenuService.QueryById(request.id);
            if (entity == null || entity.Id <= 0)
            {
                return Failed($"主键：{request.id}不存在或已被删除!");
            }
            mapEntity(request, entity);
            entity.UpdateCommonFields(_user.Id, false);
            res.success = await _sysMenuService.Update(entity);
            if (res.success)
            {
                if (request.type == 2)
                {
                    await addPermToPermRequirement(request.perms);
                }
                res.msg = "更新成功";
                res.data = entity.Id.ObjToString();
            }

            return res;
        }

        /// <summary>
        /// 根据主键Id删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<MessageModel<string>> Delete(int id)
        {
            var res = new MessageModel<string>();

            var entity = await _sysMenuService.QueryById(id);
            if (entity == null || entity.Id <= 0)
            {
                return Failed($"主键:{id}不存在或已被删除!");
            }
            entity.MarkedAsDeleted(_user.Id);
            res.success = await _sysMenuService.Update(entity);
            var childMenus = await _sysMenuService.Query(x => x.ParentId == id);
            childMenus.ForEach(x => x.MarkedAsDeleted(_user.Id));
            await _sysMenuService.Update(childMenus);
            if (res.success)
            {
                res.msg = "删除成功";
                res.data = id.ToString();
            }

            return res;
        }
    }
}