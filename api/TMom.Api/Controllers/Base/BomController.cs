using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMom.Application;
using TMom.Application.Dto;
using TMom.Application.Service.IService;
using TMom.Domain.Model;
using TMom.Domain.Model.Entity;
using static TMom.Domain.Model.GlobalVars;

namespace TMom.Api.Controllers
{
    /// <summary>
    /// BOM
    /// </summary>
	[Route("api/[controller]/[action]")]
    [ApiController]
    public class BomController : BaseApiController<Bom, int>
    {
        private readonly IBomService _bomService;
        private readonly IMapper _mapper;

        public BomController(IBomService bomService, IMapper mapper)
        {
            _bomService = bomService;
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
        public async Task<MessageModel<PageModel<Bom>>> GetWithPage(int pageIndex = 1, int pageSize = 10, string field = "", string order = "")
        {
            PageModel<Bom> data = await _bomService.GetWithPage(DynamicFilterExpress(), pageIndex, pageSize, FormatOrderField(field, order));
            return SuccessPage(data);
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<MessageModel<Bom>> Get(int id)
        {
            Bom entity = await _bomService.GetById(id);
            return Success(entity);
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Add([FromBody] Bom model)
        {
            var id = await _bomService.AddData(model);
            return id > 0 ? Success(id.ObjToString(), "添加成功!") : Failed();
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>修改的主键Id</returns>
        [HttpPut]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Update([FromBody] Bom model)
        {
            bool res = await _bomService.UpdateData(model);
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
            bool res = await _bomService.DeleteData(ids);
            return res ? Success("删除成功!") : Failed();
        }

        #endregion 模板生成 CRUD

        /// <summary>
        /// 获取所有Bom集合
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<Bom>>> GetList()
        {
            List<Bom> data = await _bomService.GetList(DynamicFilterExpress());
            return Success(data);
        }

        /// <summary>
        /// Bom和产品料号绑定(默认情况下两者Code一致关联)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<MessageModel<bool>> BindPart([FromBody] BomBindPartParam model)
        {
            bool res = await _bomService.BindPart(model);
            return Success(res);
        }
    }
}