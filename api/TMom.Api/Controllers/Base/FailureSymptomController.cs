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
    /// 不良现象
    /// </summary>
	[Route("api/[controller]/[action]")]
    [ApiController]
    public class FailureSymptomController : BaseApiController<FailureSymptom, int>
    {
        private readonly IFailureSymptomService _failureSymptomService;
        private readonly IMapper _mapper;

        public FailureSymptomController(IFailureSymptomService failureSymptomService, IMapper mapper)
        {
            _failureSymptomService = failureSymptomService;
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
        public async Task<MessageModel<PageModel<FailureSymptom>>> GetWithPage(int pageIndex = 1, int pageSize = 10, string field = "", string order = "")
        {
            PageModel<FailureSymptom> data = await _failureSymptomService.GetWithPage(DynamicFilterExpress(), pageIndex, pageSize, FormatOrderField(field, order));
            return SuccessPage(data);
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<MessageModel<FailureSymptom>> Get(int id)
        {
            FailureSymptom entity = await _failureSymptomService.GetById(id);
            return Success(entity);
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Add([FromBody] FailureSymptom model)
        {
            var id = await _failureSymptomService.AddData(model);
            return id > 0 ? Success(id.ObjToString(), "添加成功!") : Failed();
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>修改的主键Id</returns>
        [HttpPut]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Update([FromBody] FailureSymptom model)
        {
            bool res = await _failureSymptomService.UpdateData(model);
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
            bool res = await _failureSymptomService.DeleteData(ids);
            return res ? Success("删除成功!") : Failed();
        }

        #endregion 模板生成 CRUD

        /// <summary>
        /// 获取不良现象Options
        /// </summary>
        /// <param name="typeId">不良类型Id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<SelectDto>>> GetFailureSymptomOptions(int? typeId)
        {
            List<SelectDto> dataList = await _failureSymptomService.GetFailureSymptomOptions(typeId);
            return Success(dataList);
        }
    }
}