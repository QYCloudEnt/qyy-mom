using System.Linq.Expressions;
using TMom.Application.Service.IService;
using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;
using TMom.Domain.Model;
using TMom.Infrastructure;

namespace TMom.Application.Service.Service
{
    public class HolidaysService : BaseService<Holidays, int>, IHolidaysService
    {
        private readonly IBaseRepository<Holidays, int> _dal;
        private readonly IUser _user;

        public HolidaysService(IBaseRepository<Holidays, int> dal, IUser user)
        {
            _dal = dal;
            _user = user;
        }

        /// <summary>
        /// 获取假期集合
        /// </summary>
        /// <param name="yearMonth">格式 eg: 2024-05</param>
        /// <returns></returns>
        public async Task<List<string>> GetHolidays(string? yearMonth = "")
        {
            List<string> list = new List<string>();
            if (string.IsNullOrWhiteSpace(yearMonth))
            {
                list = await _dal.Query(x => x.Date.ToString("yyyy-MM-dd"));
                return list;
            }
            list = await _dal.Query(x => x.Date.ToString("yyyy-MM-dd"), x => x.Date.ToString("yyyy-MM") == yearMonth, "date asc");
            return list;
        }

        /// <summary>
        /// 获取某个日期(包含)之后的假期集合
        /// </summary>
        /// <param name="date">默认今日</param>
        /// <returns></returns>
        public async Task<List<string>> GetMoreDateHolidays(DateTime? date)
        {
            date ??= DateTime.Now;
            List<string> list = await _dal.Query(x => x.Date.ToString("yyyy-MM-dd"), x => x.Date >= date.Value.AddDays(-1), "date asc");
            return list;
        }

        /// <summary>
        /// 更改某个日期
        /// </summary>
        /// <param name="date">格式eg: 2024-05-04</param>
        /// <param name="isHoliday">是否为假期, 默认true</param>
        /// <returns></returns>
        public async Task<bool> UpdateDate(string date, bool isHoliday = true)
        {
            var model = await _dal.QuerySingle(x => x.Date.ToString("yyyy-MM-dd") == date);
            if (!isHoliday)
            {
                await _dal.Delete(model);
                return true;
            }
            if (model == null)
            {
                Holidays entity = new Holidays()
                {
                    Date = DateTime.Parse(date),
                };
                entity.UpdateCommonFields(_user.Id);
                var count = await _dal.Add(entity);
                return count > 0;
            }
            return true;
        }
    }
}