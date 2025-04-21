using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TMom.Domain.Model.Entity;
using TMom.Domain.Model;

namespace TMom.Application.Service.IService
{
    public interface IHolidaysService : IBaseService<Holidays, int>
    {
        /// <summary>
        /// 获取假期集合
        /// </summary>
        /// <param name="yearMonth">格式 eg: 2024-05</param>
        /// <returns></returns>
        Task<List<string>> GetHolidays(string? yearMonth = "");

        /// <summary>
        /// 获取某个日期(包含)之后的假期集合
        /// </summary>
        /// <param name="date">默认今日</param>
        /// <returns></returns>
        Task<List<string>> GetMoreDateHolidays(DateTime? date);

        /// <summary>
        /// 更改某个日期
        /// </summary>
        /// <param name="date">格式eg: 2024-05-04</param>
        /// <param name="isHoliday">是否为假期, 默认true</param>
        /// <returns></returns>
        Task<bool> UpdateDate(string date, bool isHoliday = true);
    }
}