using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMom.Application;
using TMom.Application.Service.IService;
using TMom.Domain.Model;
using TMom.Domain.Model.Entity;
using TMom.Infrastructure.Helper;
using SqlSugar;
using System.Linq.Expressions;
using static TMom.Domain.Model.GlobalVars;

namespace TMom.Api.Controllers
{
    /// <summary>
    /// 组织架构
    /// </summary>
	[Route("api/[controller]/[action]")]
    [ApiController]
    public class SysOrgController : BaseApiController<SysOrg, int>
    {
        /// <summary>
        /// 模板生成
        /// </summary>
        private readonly ISysOrgService _sysOrgService;

        private readonly IUser _user;
        private readonly IMapper _mapper;

        public SysOrgController(ISysOrgService SysOrgService, IUser user, IMapper mapper)
        {
            _sysOrgService = SysOrgService;
            _user = user;
            _mapper = mapper;
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<PageModel<SysOrg>>> GetWithPage(int pageIndex = 1, int pageSize = 10)
        {
            Expression<Func<SysOrg, bool>> whereExpression = DynamicFilterExpress().Item1;
            // 后端递归树形结构
            //var list = await _sysOrgService.Query(whereExpression);
            //SysOrg tree = new SysOrg()
            //{
            //    OrgCode = "",
            //    OrgName = "#",
            //    ParentId = -1
            //};
            //RecursionHelper.LoopToAppendChildrenT(list, tree);
            return new MessageModel<PageModel<SysOrg>>()
            {
                msg = "获取成功",
                success = true,
                data = await _sysOrgService.QueryPage(whereExpression, pageIndex, pageSize)
            };
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<MessageModel<SysOrg>> Get(int id)
        {
            var entity = await _sysOrgService.QueryById(id);
            if (entity == null || entity.Id <= 0)
            {
                return Failed<SysOrg>($"主键:{id}不存在或已被删除!");
            }
            return new MessageModel<SysOrg>()
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
        public async Task<MessageModel<string>> Add([FromBody] SysOrg request)
        {
            request.UpdateCommonFields(_user.Id);
            var id = await _sysOrgService.Add(request);
            return id > 0 ? Success<string>(id.ToString()) : Failed();
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>修改的主键Id</returns>
        [HttpPut]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Update([FromBody] SysOrg model)
        {
            model.UpdateCommonFields(_user.Id, false);
            bool isSuccess = await _sysOrgService.Update(model);
            return isSuccess ? Success() : Failed();
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
            var entityList = await _sysOrgService.Query(x => _ids.Contains(x.Id.ToString()));
            if (entityList == null || !entityList.Any())
            {
                return Failed($"主键: {ids}均不存在或已被删除!");
            }
            entityList.ForEach(entity => entity.MarkedAsDeleted(_user.Id));
            res.success = await _sysOrgService.Update(entityList);
            if (res.success)
            {
                res.msg = "删除成功";
                res.data = ids;
            }

            return res;
        }
    }
}