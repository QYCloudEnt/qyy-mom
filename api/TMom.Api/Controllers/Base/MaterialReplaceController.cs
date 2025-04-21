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
    /// 替代料管理
    /// </summary>
	[Route("api/[controller]/[action]")]
    [ApiController]
    public class MaterialReplaceController : BaseApiController<MaterialReplace, int>
    {
        private readonly IMaterialReplaceService _materialReplaceService;
        private readonly IMapper _mapper;

        public MaterialReplaceController(IMaterialReplaceService materialReplaceService, IMapper mapper)
        {
            _materialReplaceService = materialReplaceService;
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
        public async Task<MessageModel<PageModel<MaterialReplace>>> GetWithPage(int pageIndex = 1, int pageSize = 10, string field = "", string order = "")
        {
            PageModel<MaterialReplace> data = await _materialReplaceService.GetWithPage(DynamicFilterExpress(), pageIndex, pageSize, FormatOrderField(field, order));
            return SuccessPage(data);
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<MessageModel<MaterialReplace>> Get(int id)
        {
            MaterialReplace entity = await _materialReplaceService.GetById(id);
            return Success(entity);
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Add([FromBody] MaterialReplace model)
        {
            var id = await _materialReplaceService.AddData(model);
            return id > 0 ? Success(id.ObjToString(), "添加成功!") : Failed();
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>修改的主键Id</returns>
        [HttpPut]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Update([FromBody] MaterialReplace model)
        {
            bool res = await _materialReplaceService.UpdateData(model);
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
            bool res = await _materialReplaceService.DeleteData(ids);
            return res ? Success("删除成功!") : Failed();
        }

        #endregion 模板生成 CRUD
    }
}