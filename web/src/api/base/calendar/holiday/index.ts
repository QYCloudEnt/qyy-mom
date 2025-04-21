import { http } from '@/api/http'

/** 假期设置接口 */
export default {
  /**
   * 获取假期集合
   * @param yearMonth 年月 eg: 2024-05
   * @returns eg: ['2024-05-04', '2024-05-05']
   */
  getHolidays: (yearMonth?: string) => http.get<string[]>(`/Holidays/GetHolidays`, { yearMonth }),

  /**
   * 获取某个日期(包含)之后的假期集合
   * @param date 日期, 为空则默认今日 格式eg: 2024-05-04
   * @returns eg: ['2024-05-04', '2024-05-05']
   */
  getMoreDateHolidays: (dateStr?: string) =>
    http.get<string[]>(`/Holidays/GetMoreDateHolidays?date=${dateStr || ''}`),

  /**
   * 更改某个日期
   * @param date 日期: 2024-05-04
   * @param isHoliday 是否假期
   * @returns
   */
  updateDate: (date: string, isHoliday: boolean = false) =>
    http.postStr(`/Holidays/UpdateDate`, { date, isHoliday }),
}
