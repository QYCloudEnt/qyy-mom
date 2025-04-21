using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using TMom.Domain.Model.Entity;
using TMom.Application.Service.IService;
using static TMom.Domain.Model.GlobalVars;
using TMom.Application;
using TMom.Application.Dto;

namespace TMom.Api.Controllers
{
    /// <summary>
    /// 应用菜单
    /// </summary>
	[Route("api/[controller]/[action]")]
    [ApiController]
    public class AppMenuController : BaseApiController<AppMenu, int>
    {
        private readonly IAppMenuService _appMenuService;
        private readonly IMapper _mapper;

        public AppMenuController(IAppMenuService appMenuService, IMapper mapper)
        {
            _appMenuService = appMenuService;
            _mapper = mapper;
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Add([FromBody] AppMenuAddParam model)
        {
            var id = await _appMenuService.AddData(model);
            return id > 0 ? Success(id.ObjToString(), "添加成功!") : Failed();
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
            bool res = await _appMenuService.DeleteData(ids);
            return res ? Success("删除成功!") : Failed();
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> Save([FromBody] List<AppMenuDto> para)
        {
            bool res = await _appMenuService.Save(para);
            return res ? Success() : Failed();
        }

        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<AppMenuDto>>> GetList()
        {
            var list = await _appMenuService.GetList();
            return Success(list);
        }
    }
}