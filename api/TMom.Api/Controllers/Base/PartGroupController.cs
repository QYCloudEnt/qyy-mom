using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMom.Application;
using TMom.Application.Service.IService;
using TMom.Domain.Model;
using TMom.Domain.Model.Entity;
using static TMom.Domain.Model.GlobalVars;

namespace TMom.Api.Controllers
{
    /// <summary>
    /// 主数据群组
    /// </summary>
	[Route("api/[controller]/[action]")]
    [ApiController]
    public class PartGroupController : BaseApiController<PartGroup, int>
    {
        private readonly IPartGroupService _partGroupService;
        private readonly IMapper _mapper;

        public PartGroupController(IPartGroupService partGroupService, IMapper mapper)
        {
            _partGroupService = partGroupService;
            _mapper = mapper;
        }

        #region 模板生成 CRUD

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <param name="field">排序字段</param>
        /// <param name="order">排序类型: ascend|descend</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<PageModel<PartGroup>>> GetWithPage(int pageIndex = 1, int pageSize = 10, string field = "id", string order = "descend")
        {
            PageModel<PartGroup> data = await _partGroupService.GetWithPage(DynamicFilterExpress(), pageIndex, pageSize, FormatOrderField(field, order));
            return SuccessPage(data);
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<MessageModel<PartGroup>> Get(int id)
        {
            PartGroup entity = await _partGroupService.GetById(id);
            return Success(entity);
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Add([FromBody] PartGroup model)
        {
            var id = await _partGroupService.AddData(model);
            return id > 0 ? Success(id.ObjToString(), "添加成功!") : Failed();
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>修改的主键Id</returns>
        [HttpPut]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Update([FromBody] PartGroup model)
        {
            bool res = await _partGroupService.UpdateData(model);
            return res ? Success("更新成功!") : Failed();
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
            bool res = await _partGroupService.DeleteData(ids);
            return res ? Success("删除成功!") : Failed();
        }

        #endregion 模板生成 CRUD

        /// <summary>
        /// 根据分类获取主数据群组
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<PartGroup>>> GetListByType(PartGroupType type)
        {
            var list = await _partGroupService.GetListByType(type);
            return Success(list);
        }
    }
}