import { randomColor } from '@/utils/common'

/** 发布状态枚举 */
export enum PublishStatusEnum {
  UnPublish = '未发布',
  Published = '已发布',
}

/** 测试模式 */
export enum TestModeEnum {
  A = 'A',
  AA = 'AA',
  AAA = 'AAA',
  AB = 'AB',
  AAB = 'AAB',
  ABC = 'ABC',
}

/** 报表内置数据源 */
export enum ReportSysDbEnum {
  '系统业务库(内置)' = -1,
}

/**
 * 获取枚举key
 * @param enumObj 枚举对象
 * @param value 枚举值
 * @returns Key
 */
export function getEnumKey<T extends object>(enumObj: T, value: T[keyof T]): keyof T {
  const key = Object.keys(enumObj).find(_key => enumObj[_key] === value) || ''
  return key as keyof T
}

/**
 * 获取key对应的枚举下标
 * @param enumObj 枚举
 * @param key key
 * @returns 下标
 */
export const getEmunIndex = (enumObj: Object, key: string): number => {
  return Object.keys(enumObj).findIndex(_key => _key === key)
}

/** 枚举转换成下拉框options */
export const transformEnumToOptions = (
  enumObj: Object,
): Array<{ label: string; value: string }> => {
  return Object.keys(enumObj).map(key => ({
    label: enumObj[key] as string,
    value: key,
  }))
}

const tagKeyColorMap = new Map<string, string>()

/**
 * 根据不同文本key获取Tag组件颜色
 * @param key 文本key
 * @returns
 */
export const getTagColor = (key: string): string => {
  if (tagKeyColorMap.has(key)) return tagKeyColorMap.get(key) as string
  const size = tagKeyColorMap.size
  let color = TagColorEnum[size]
  if (size >= 14) color = randomColor('rgb')
  tagKeyColorMap.set(key, color)
  return color
}

/** 初始化Tag组件颜色Map */
export const initTagKeyColorMap = () => {
  tagKeyColorMap.clear()
}

/** Tag组件颜色枚举 */
export enum TagColorEnum {
  'processing',
  'success',
  'error',
  'blue',
  'pink',
  'orange',
  'purple',
  'lime',
  'volcano',
  'geekblue',
  'magenta',
  'gold',
  'cyan',
  'default',
}

/** 属性类型枚举 */
export enum AttributeTypeEnum {
  'Global' = '全局',
  'Workshop' = '车间',
  'Line' = '产线',
  'Workstation' = '工位',
  'ProcessOperation' = '工序',
  'Part' = '产品料号',
  'WorkOrder' = '工单',
  'Product' = '产品',
  'Equipment' = '设备',
}

/** 工单状态枚举 */
export enum WorkOrderStatusEnum {
  'Initial' = '初始化',
  'PrepMaterial' = '备料中',
  'PrepMaterialComplete' = '备料完成',
  'Open' = '已开工',
  'Pending' = '暂停',
  'Complete' = '完工',
  'Close' = '结案',
}
