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
    /// 工位管理
    /// </summary>
	[Route("api/[controller]/[action]")]
    [ApiController]
    public class WorkstationController : BaseApiController<Workstation, int>
    {
        private readonly IWorkstationService _workstationService;
        private readonly IMapper _mapper;

        public WorkstationController(IWorkstationService workstationService, IMapper mapper)
        {
            _workstationService = workstationService;
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
        public async Task<MessageModel<PageModel<Workstation>>> GetWithPage(int pageIndex = 1, int pageSize = 10)
        {
            PageModel<Workstation> data = await _workstationService.GetWithPage(DynamicFilterExpress(), pageIndex, pageSize);
            return SuccessPage(data);
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<MessageModel<Workstation>> Get(int id)
        {
            Workstation entity = await _workstationService.GetById(id);
            return Success(entity);
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Add([FromBody] Workstation model)
        {
            var id = await _workstationService.AddData(model);
            return id > 0 ? Success(id.ObjToString(), "添加成功!") : Failed();
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>修改的主键Id</returns>
        [HttpPut]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Update([FromBody] Workstation model)
        {
            bool res = await _workstationService.UpdateData(model);
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
            bool res = await _workstationService.DeleteData(ids);
            return res ? Success("删除成功!") : Failed();
        }

        #endregion 模板生成 CRUD

        /// <summary>
        /// 根据产线id获取集合
        /// </summary>
        /// <param name="lineId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<Workstation>>> GetListByLineId(int lineId)
        {
            List<Workstation> list = await _workstationService.GetListByLineId(lineId);
            return Success(list);
        }

        /// <summary>
        /// 根据产线id获取有权限的工位集合
        /// </summary>
        /// <param name="lineId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<Workstation>>> GetHasAuthListByLineId(int lineId)
        {
            List<Workstation> list = await _workstationService.GetHasAuthListByLineId(lineId);
            return Success(list);
        }

        /// <summary>
        /// 根据工位id获取工序
        /// </summary>
        /// <param name="workStationId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<ProcessOperation>> GetProcessOperationByWorkStationId(int workStationId)
        {
            var data = await _workstationService.GetProcessOperationByWorkStationId(workStationId);
            return Success(data);
        }
    }
}