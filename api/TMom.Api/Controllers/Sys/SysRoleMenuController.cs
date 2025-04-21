using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMom.Application;
using TMom.Application.Service.IService;
using TMom.Domain.Model;
using TMom.Domain.Model.Entity;
using TMom.Infrastructure.Helper;
using TMom.Infrastructure.Repository;
using SqlSugar;

namespace TMom.Api.Controllers
{
    /// <summary>
    /// 角色菜单关系
    /// </summary>
	[Route("api/[controller]/[action]")]
    [ApiController]
    public class SysRoleMenuController : BaseApiController<SysRoleMenu, int>
    {
        /// <summary>
        /// 模板生成
        /// </summary>
        private readonly ISysRoleMenuService _sysRoleMenuService;

        private readonly IUser _user;
        private readonly ISysUserRoleService _sysUserRoleService;
        private readonly ISysMenuService _sysMenuService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISysRoleService _sysRoleService;

        public SysRoleMenuController(ISysRoleMenuService SysRoleMenuService, IUser user
            , ISysUserRoleService sysUserRoleService, ISysMenuService sysMenuService
            , IUnitOfWork unitOfWork, ISysRoleService sysRoleService)
        {
            _sysRoleMenuService = SysRoleMenuService;
            _user = user;
            _sysUserRoleService = sysUserRoleService;
            _sysMenuService = sysMenuService;
            _unitOfWork = unitOfWork;
            _sysRoleService = sysRoleService;
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<PageModel<SysRoleMenu>>> GetWithPage(int pageIndex = 1, int pageSize = 10)
        {
            return new MessageModel<PageModel<SysRoleMenu>>()
            {
                msg = "获取成功",
                success = true,
                data = await _sysRoleMenuService.QueryPage(DynamicFilterExpress().Item1, pageIndex, pageSize)
            };
        }

        /// <summary>
        /// 获取权限路由菜单(tree)
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<MessageModel<SideBarRouteTree>> GetPermissionMenu(string id)
        {
            List<int> rolesIds = (await _sysUserRoleService.Query(x => x.SysUserId.ToString() == id)).ToList().Select(x => x.SysRoleId).ToList();
            List<int> menuIds = (await _sysRoleMenuService.Query(x => rolesIds.Contains(x.SysRoleId))).ToList().Select(x => x.SysMenuId).Distinct().ToList();
            var menuList = (await _sysMenuService.Query(x => menuIds.Contains(x.Id))).OrderBy(x => x.OrderSort);
            var trees = (from child in menuList
                         select new SideBarRouteTree
                         {
                             id = child.Id,
                             pid = child.ParentId,
                             path = child.LinkUrl?.TrimStart('/'),
                             name = child.LinkUrl,
                             orderSort = child.OrderSort,
                             meta = new MetaInfo()
                             {
                                 icon = child.Icon,
                                 title = child.MenuName,
                                 perms = new List<string>(),
                                 keepAlive = child.IsKeepAlive,
                                 keyPath = new List<string>()
                             }
                         }).ToList();
            SideBarRouteTree routeTree = new SideBarRouteTree()
            {
                id = 0,
                pid = 0,
                name = "",
                orderSort = 0,
                meta = new MetaInfo()
                {
                    icon = "",
                    title = "",
                    perms = new List<string>(),
                    keepAlive = false,
                    keyPath = new List<string>()
                }
            };
            RecursionHelper.LoopRouteMenuAppendChildren(trees, routeTree);
            return Success(routeTree);
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<MessageModel<SysRoleMenu>> Get(string id)
        {
            var entity = await _sysRoleMenuService.QueryById(id);
            if (entity == null || entity.Id <= 0)
            {
                return Failed<SysRoleMenu>($"主键:{id}不存在或已被删除!");
            }
            return new MessageModel<SysRoleMenu>()
            {
                msg = "获取成功",
                success = true,
                data = entity
            };
        }

        /// <summary>
        /// 添加一条角色菜单数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<string>> Add([FromBody] roleMenuParam request)
        {
            var res = new MessageModel<string>();

            var entity = new SysRole()
            {
                RoleName = request.RoleName,
                Description = request.Description
            };
            entity.UpdateCommonFields(_user.Id);

            _unitOfWork.BeginTran();
            try
            {
                var Id = await _sysRoleService.Add(entity);
                var roleMenuEntityList = new List<SysRoleMenu>();
                var menuList = request.menus.OrderBy(x => x).ToList();
                menuList.ForEach(menuId =>
                {
                    var _entity = new SysRoleMenu()
                    {
                        SysRoleId = Id,
                        SysMenuId = menuId
                    };
                    _entity.UpdateCommonFields(_user.Id);
                    roleMenuEntityList.Add(_entity);
                });
                await _sysRoleMenuService.Add(roleMenuEntityList);

                _unitOfWork.CommitTran();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTran();
                return Failed(ex.Message);
            }

            res.success = true;
            res.msg = "新增成功!";
            return res;
        }

        /// <summary>
        /// 按需部分更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpPatch]
        [AllowAnonymous]
        public async Task<MessageModel<string>> UpdatePartial(string id, string key)
        {
            var res = new MessageModel<string>();
            res.success = await _sysRoleMenuService.Update(a => a.Id.ToString() == id, a => new SysRoleMenu { UpdateTime = DateTime.Now });
            if (res.success)
            {
                res.msg = "更新成功";
                res.data = id.ObjToString();
            }

            return res;
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="request"></param>
        /// <returns>修改的主键Id</returns>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] SysRoleMenu request)
        {
            var res = new MessageModel<string>();
            res.success = await _sysRoleMenuService.Update(request);
            if (res.success)
            {
                res.msg = "更新成功";
                res.data = request?.Id.ObjToString();
            }

            return res;
        }

        /// <summary>
        /// 根据主键Id删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<MessageModel<string>> Delete(string id)
        {
            var res = new MessageModel<string>();

            var entity = await _sysRoleMenuService.QuerySingle(x => x.Id.ToString() == id && !x.IsDeleted);
            if (entity == null || entity.Id <= 0)
            {
                return Failed($"主键:{id}不存在或已被删除!");
            }
            entity.MarkedAsDeleted(_user.Id);
            res.success = await _sysRoleMenuService.Update(entity);
            if (res.success)
            {
                res.msg = "删除成功";
                res.data = id;
            }

            return res;
        }
    }
}