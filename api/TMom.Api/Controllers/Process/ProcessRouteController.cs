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
    /// 工艺路线
    /// </summary>
	[Route("api/[controller]/[action]")]
    [ApiController]
    public class ProcessRouteController : BaseApiController<ProcessRoute, int>
    {
        private readonly IProcessRouteService _processRouteService;
        private readonly IMapper _mapper;
        private readonly IUser _user;

        public ProcessRouteController(IProcessRouteService processRouteService, IMapper mapper, IUser user)
        {
            _processRouteService = processRouteService;
            _mapper = mapper;
            _user = user;
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
        public async Task<MessageModel<PageModel<ProcessRoute>>> GetWithPage(int pageIndex = 1, int pageSize = 10, string field = "id", string order = "descend")
        {
            PageModel<ProcessRoute> data = await _processRouteService.GetWithPage(DynamicFilterExpress(), pageIndex, pageSize, FormatOrderField(field, order));
            return SuccessPage(data);
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<MessageModel<ProcessRoute>> Get(int id)
        {
            ProcessRoute entity = await _processRouteService.GetById(id);
            return Success(entity);
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Add([FromBody] ProcessRoute model)
        {
            var id = await _processRouteService.AddData(model);
            return id > 0 ? Success(id.ObjToString(), "添加成功!") : Failed();
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>修改的主键Id</returns>
        [HttpPut]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Update([FromBody] ProcessRoute model)
        {
            bool res = await _processRouteService.UpdateData(model);
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
            bool res = await _processRouteService.DeleteData(ids);
            return res ? Success("删除成功!") : Failed();
        }

        #endregion 模板生成 CRUD

        /// <summary>
        /// 更新发布状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> UpdatePublishStatus([FromBody] ProcessRouteStatusParams model)
        {
            bool res = await _processRouteService.UpdatePublishStatus(model);
            return res ? Success("更新成功!") : Failed();
        }

        /// <summary>
        /// 更新流程数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> UpdateDesign([FromBody] ProcessRouteDesignParams model)
        {
            bool res = await _processRouteService.UpdateDesign(model);
            return res ? Success("更新成功!") : Failed();
        }

        /// <summary>
        /// 上传作业指导书
        /// </summary>
        /// <param name="uploadFileDto"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageModel<string> UploadSop([FromForm] UploadFileDto uploadFileDto)
        {
            var file = uploadFileDto.file.FirstOrDefault();
            if (file == null) return Failed($"没有获取到文件内容!");
            return Success<string>("");
        }
    }
}