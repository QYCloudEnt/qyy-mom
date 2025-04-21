/**
 * Independent time operation tool to facilitate subsequent switch to dayjs
 */
import dayjs from 'dayjs'
import advancedFormat from 'dayjs/plugin/advancedFormat'
import weekOfYear from 'dayjs/plugin/weekOfYear'
import weekday from 'dayjs/plugin/weekday'
import localeData from 'dayjs/plugin/localeData'
dayjs.extend(advancedFormat)
dayjs.extend(weekOfYear)
dayjs.extend(weekday)
dayjs.extend(localeData)

const DATE_TIME_FORMAT = 'YYYY-MM-DD HH:mm:ss'
const DATE_FORMAT = 'YYYY-MM-DD'
/** eg: 2023-1st、2023-2nd */
const WEEK_SUF_FROMAT = 'YYYY-wo'
/** eg: 2023-01、2023-02 */
const WEEK_FROMAT = 'YYYY-ww'
/** eg: 2023-1、2023-12 */
const WEEK_SINGLE_FROMAT = 'YYYY-w'

export function formatToDateTime(date?: dayjs.ConfigType, format = DATE_TIME_FORMAT): string {
  return dayjs(date).format(format)
}

export function formatToDate(date?: dayjs.ConfigType, format = DATE_FORMAT): string {
  return dayjs(date).format(format)
}

/**
 * 格式化周
 * @param date 日期
 * @param format 'YYYY-ww' | 'YYYY-w'
 * @returns eg: 2023-01 | 2023-1
 */
export function formatToWeek(
  date: dayjs.Dayjs | undefined = undefined,
  format: typeof WEEK_FROMAT | typeof WEEK_SINGLE_FROMAT = WEEK_FROMAT,
): string {
  let week = dayjs(date).week().toString()
  if (format === WEEK_FROMAT) {
    week = dayjs(date).week().toString().padStart(2, '0')
  }
  return `${dayjs(date).format('YYYY')}-${week}`
}

/**
 * 格式化自定义周, 使用方式: format: formatToCustomWeek
 * @param value dayjs
 * @returns eg：2023-19周(05-07 ~ 05-13)
 */
export const formatToCustomWeek = (value: dayjs.Dayjs) =>
  `${dayjs(value).format('YYYY')}-${dayjs(value).week().toString().padStart(2, '0')}周(${dayjs(
    value,
  )
    .startOf('week')
    .format('MM-DD')} ~ ${dayjs(value).endOf('week').format('MM-DD')})`

/**
 * 自定义周渲染成dayjs格式
 * @param value 自定义周格式字符串
 * @returns dayjs
 */
export const renderCustomWeekToDayjs = (value: string): dayjs.Dayjs | null => {
  try {
    const dateStr = value.slice(0, 7)
    // const dateStr = formatToCustomWeek(dayjs(value))
    const year = parseInt(dateStr)
    const weekNum = +dateStr.slice(5, 7)
    return dayjs(`${year}-07-01`).week(weekNum) // 固定给个月, 防止BUG
  } catch {
    return null
  }
}

export const dateUtil = dayjs
