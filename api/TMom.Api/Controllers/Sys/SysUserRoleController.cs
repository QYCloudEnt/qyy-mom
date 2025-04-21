using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMom.Application;
using TMom.Application.Service.IService;
using TMom.Domain.Model;
using TMom.Domain.Model.Entity;
using System.Linq.Expressions;

namespace TMom.Api.Controllers
{
    /// <summary>
    /// 用户角色关系
    /// </summary>
	[Route("api/[controller]/[action]")]
    [ApiController]
    public class SysUserRoleController : BaseApiController<SysUserRole, int>
    {
        /// <summary>
        /// 模板生成
        /// </summary>
        private readonly ISysUserRoleService _sysUserRoleService;

        private readonly IUser _user;

        public SysUserRoleController(ISysUserRoleService SysUserRoleService, IUser user)
        {
            _sysUserRoleService = SysUserRoleService;
            _user = user;
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<PageModel<SysUserRole>>> GetWithPage(int pageIndex = 1, int pageSize = 10)
        {
            Expression<Func<SysUserRole, bool>> whereExpression = DynamicFilterExpress().Item1;

            return new MessageModel<PageModel<SysUserRole>>()
            {
                msg = "获取成功",
                success = true,
                data = await _sysUserRoleService.QueryPage(whereExpression, pageIndex, pageSize)
            };
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<MessageModel<SysUserRole>> Get(string id)
        {
            var entity = await _sysUserRoleService.QueryById(id);
            if (entity == null || entity.Id <= 0)
            {
                return Failed<SysUserRole>($"主键:{id}不存在或已被删除!");
            }
            return new MessageModel<SysUserRole>()
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
        public async Task<MessageModel<string>> Add([FromBody] SysUserRole request)
        {
            var res = new MessageModel<string>();

            request.UpdateCommonFields(_user.Id);
            var Id = await _sysUserRoleService.Add(request);
            if (Id > 0)
            {
                res.success = true;
                res.data = Id.ObjToString();
                res.msg = "添加成功";
            }

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
            res.success = await _sysUserRoleService.Update(a => a.Id.ToString() == id, a => new SysUserRole { UpdateTime = DateTime.Now });
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
        public async Task<MessageModel<string>> Update([FromBody] SysUserRole request)
        {
            var res = new MessageModel<string>();
            res.success = await _sysUserRoleService.Update(request);
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
            var entity = await _sysUserRoleService.QuerySingle(x => x.Id.ToString() == id && !x.IsDeleted);
            if (entity == null || entity.Id <= 0)
            {
                return Failed($"主键:{id}不存在或已被删除!");
            }
            entity.MarkedAsDeleted(_user.Id);
            return await _sysUserRoleService.Update(entity) ? Success<string>(id) : Failed();
        }
    }
}