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
    /// 车间管理
    /// </summary>
	[Route("api/[controller]/[action]")]
    [ApiController]
    public class WorkshopController : BaseApiController<Workshop, int>
    {
        private readonly IWorkshopService _workshopService;
        private readonly IMapper _mapper;

        public WorkshopController(IWorkshopService workshopService, IMapper mapper)
        {
            _workshopService = workshopService;
            _mapper = mapper;
        }

        #region 模板生成 CRUD

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<PageModel<Workshop>>> GetWithPage(int pageIndex = 1, int pageSize = 10)
        {
            PageModel<Workshop> data = await _workshopService.GetWithPage(DynamicFilterExpress(), pageIndex, pageSize);
            return SuccessPage(data);
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<MessageModel<Workshop>> Get(int id)
        {
            Workshop entity = await _workshopService.GetById(id);
            return Success(entity);
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Add([FromBody] Workshop model)
        {
            var id = await _workshopService.AddData(model);
            return id > 0 ? Success(id.ObjToString(), "添加成功!") : Failed();
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>修改的主键Id</returns>
        [HttpPut]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Update([FromBody] Workshop model)
        {
            bool res = await _workshopService.UpdateData(model);
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
            bool res = await _workshopService.DeleteData(ids);
            return res ? Success("删除成功!") : Failed();
        }

        #endregion 模板生成 CRUD
    }
}