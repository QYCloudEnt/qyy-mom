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
    /// 假期设置
    /// </summary>
	[Route("api/[controller]/[action]")]
    [ApiController]
    public class HolidaysController : BaseApiController<Holidays, int>
    {
        private readonly IHolidaysService _holidaysService;

        public HolidaysController(IHolidaysService holidaysService)
        {
            _holidaysService = holidaysService;
        }

        /// <summary>
        /// 获取假期集合
        /// </summary>
        /// <param name="yearMonth">格式 eg: 2024-05</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<string>>> GetHolidays(string? yearMonth = "")
        {
            var list = await _holidaysService.GetHolidays(yearMonth);
            return Success(list);
        }

        /// <summary>
        /// 获取某个日期(包含)之后的假期集合
        /// </summary>
        /// <param name="date">默认今日</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<string>>> GetMoreDateHolidays(DateTime? date)
        {
            var list = await _holidaysService.GetMoreDateHolidays(date);
            return Success(list);
        }

        /// <summary>
        /// 更改某个日期
        /// </summary>
        /// <param name="date">格式eg: 2024-05-04</param>
        /// <param name="isHoliday">是否为假期, 默认true</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<bool>> UpdateDate(string date, bool isHoliday = true)
        {
            bool res = await _holidaysService.UpdateDate(date, isHoliday);
            return Success(res);
        }
    }
}