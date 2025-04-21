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
    /// 产品锁定/解锁
    /// </summary>
	[Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductLockController : BaseApiController<ProductLock, int>
    {
        private readonly IProductLockService _productLockService;
        private readonly IMapper _mapper;

        public ProductLockController(IProductLockService productLockService, IMapper mapper)
        {
            _productLockService = productLockService;
            _mapper = mapper;
        }

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
        public async Task<MessageModel<PageModel<ProductLock>>> GetWithPage(int pageIndex = 1, int pageSize = 10, string field = "id", string order = "descend")
        {
            PageModel<ProductLock> data = await _productLockService.GetWithPage(DynamicFilterExpress(), pageIndex, pageSize, FormatOrderField(field, order));
            return SuccessPage(data);
        }

        /// <summary>
        /// 产品锁定
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<string>> Lock(LockDto dto)
        {
            var res = await _productLockService.Lock(dto);
            return res ? Success() : Failed();
        }

        /// <summary>
        /// 解锁
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Permissions.Name)]
        public async Task<MessageModel<string>> UnLock(string ids)
        {
            var idList = ids.Split(',').Select(x => x.ObjToInt()).ToList();
            var res = await _productLockService.UnLock(idList);
            return res ? Success() : Failed();
        }

        /// <summary>
        /// 获取锁定的数据信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<List<ProductLockDto>>> GetLockInfo(ProductLockParam param)
        {
            var list = await _productLockService.GetLockInfo(param);
            return Success(list);
        }
    }
}