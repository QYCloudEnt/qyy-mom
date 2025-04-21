using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMom.Application;
using TMom.Application.Dto;
using TMom.Application.Service.IService;
using TMom.Domain.Model;
using TMom.Domain.Model.Entity;
using TMom.Infrastructure.Repository;
using SqlSugar;
using System.Linq.Expressions;
using static TMom.Domain.Model.GlobalVars;

namespace TMom.Api.Controllers
{
    /// <summary>
    /// 角色
    /// </summary>
	[Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Permissions.Name)]
    public class SysRoleController : BaseApiController<SysRole, int>
    {
        /// <summary>
        /// 模板生成
        /// </summary>
        private readonly ISysRoleService _sysRoleService;

        private readonly IUser _user;
        private readonly ISysRoleMenuService _sysRoleMenuService;
        private readonly ISysMenuService _sysMenuService;
        private readonly IUnitOfWork _unitOfWork;

        public SysRoleController(ISysRoleService SysRoleService, IUser user
            , ISysRoleMenuService sysRoleMenuService, ISysMenuService sysMenuService
            , IUnitOfWork unitOfWork)
        {
            _sysRoleService = SysRoleService;
            _user = user;
            _sysMenuService = sysMenuService;
            _sysRoleMenuService = sysRoleMenuService;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<PageModel<SysRole>>> GetWithPage(int pageIndex = 1, int pageSize = 10)
        {
            Expression<Func<SysRole, bool>> whereExpression = DynamicFilterExpress().Item1;

            return new MessageModel<PageModel<SysRole>>()
            {
                msg = "获取成功",
                success = true,
                data = await _sysRoleService.QueryPage(whereExpression, pageIndex, pageSize)
            };
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<MessageModel<SysRole>> Get(string id)
        {
            var role = await _sysRoleService.QueryById(id);
            return new MessageModel<SysRole>()
            {
                msg = "获取成功!",
                success = true,
                data = role
            };
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<string>> Add([FromBody] SysRole request)
        {
            var res = new MessageModel<string>();

            request.UpdateCommonFields(_user.Id);
            var Id = await _sysRoleService.Add(request);
            if (Id > 0)
            {
                res.success = true;
                res.data = Id.ObjToString();
                res.msg = "添加成功";
            }

            return res;
        }

        /// <summary>
        /// 获取角色名提供给下拉框
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<MessageModel<List<SelectDto>>> GetRolesForSelect()
        {
            var dataList = await _sysRoleService.Query();
            var list = dataList.Select(x => new SelectDto()
            {
                label = x.RoleName,
                value = x.Id.ToString()
            }).ToList();
            return Success(list);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] roleMenuParam request)
        {
            var res = new MessageModel<string>();
            var role = await _sysRoleService.QuerySingle(x => x.Id == request.Id);
            role.RoleName = request.RoleName;
            role.Description = request.Description;
            role.UpdateCommonFields(_user.Id, false);
            _unitOfWork.BeginTran();

            try
            {
                // 更新角色表信息
                res.success = await _sysRoleService.Update(role);
                var roleMenus = await _sysRoleMenuService.Query(x => x.SysRoleId == request.Id);

                // 需要删除的菜单: request.menus 中没有，表中有的
                var delMenus = (from roleMenu in roleMenus
                                where !request.menus.Contains(roleMenu.SysMenuId) && roleMenu.IsDeleted == false
                                select roleMenu).ToList();
                delMenus.ForEach(delMenu => delMenu.MarkedAsDeleted(_user.Id));
                await _sysRoleMenuService.Update(delMenus);

                // 新增的菜单: request.menus 中有，表中没有的
                var menus = request.menus;
                var addMenuIds = (from menu in menus
                                  where !roleMenus.Select(x => x.SysMenuId).Contains(menu)
                                  select menu).ToList();
                var addRoleMenuList = new List<SysRoleMenu>();
                addMenuIds.ForEach(menuId =>
                {
                    var roleMenu = new SysRoleMenu();
                    roleMenu.SysRoleId = request.Id;
                    roleMenu.SysMenuId = menuId;
                    roleMenu.UpdateCommonFields(_user.Id);
                    addRoleMenuList.Add(roleMenu);
                });
                await _sysRoleMenuService.Add(addRoleMenuList);

                _unitOfWork.CommitTran();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTran();
                return Failed(ex.Message);
            }

            if (res.success)
            {
                res.msg = "更新成功";
                res.data = request.Id.ObjToString();
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

            var entity = await _sysRoleService.QuerySingle(x => x.Id.ToString() == id);
            if (entity == null || entity.Id <= 0)
            {
                return Failed($"主键:{id}不存在或已被删除!");
            }
            entity.MarkedAsDeleted(_user.Id);
            var roleMenus = await _sysRoleMenuService.Query(x => x.SysRoleId.ToString() == id);
            roleMenus.ForEach(roleMenu =>
            {
                roleMenu.MarkedAsDeleted(_user.Id);
            });
            await _sysRoleMenuService.Update(roleMenus);
            res.success = await _sysRoleService.Update(entity);
            if (res.success)
            {
                res.msg = "删除成功";
                res.data = id;
            }

            return res;
        }
    }
}