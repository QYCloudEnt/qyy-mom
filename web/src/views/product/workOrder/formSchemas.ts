import type { FormSchema } from '@/components/core/schema-form'
import { transformInt } from '@/utils/common'
import routeAction from '@/api/process/route'
import partAction from '@/api/base/partMaterial'
import dayjs, { type Dayjs } from 'dayjs'
import holidayAction from '@/api/base/calendar/holiday'

/**
 * 表单信息
 */
export const formSchemas: FormSchema[] = [
  {
    field: 'code',
    component: 'Input',
    label: '编码',
    colProps: {
      span: 24,
    },
  },
  {
    field: 'type',
    component: 'Select',
    label: '类型',
    helpMessage: '来源: 数据字典-`工单类型`',
    required: true,
    componentProps: {
      options: [
        {
          label: '生产',
          value: '生产',
        },
        {
          label: '维修',
          value: '维修',
        },
      ],
    },
  },
  {
    field: 'processRouteId',
    component: 'Select',
    label: '工艺路线',
    helpMessage: '若工单没有分配, 则使用产品料号的工艺路线',
    componentProps: {
      request: async () => {
        const { list } = await routeAction.getWithPage({ pageSize: 10000 })
        return (list as Array<any>).map(item => ({
          label: item.name,
          value: item.id,
        }))
      },
    },
  },
  {
    field: 'partId',
    component: 'Select',
    label: '产品料号',
    required: true,
    componentProps: {
      request: async () => {
        const { list } = await partAction.getWithPage({ pageSize: 10000 })
        return (list as Array<any>).map(item => ({
          label: item.code,
          value: item.id,
        }))
      },
    },
  },
  {
    field: 'lineId',
    component: 'Select',
    label: '产线',
    required: true,
    componentProps: {
      options: [],
    },
  },
  {
    field: 'planDate',
    component: 'RangePicker',
    label: '计划起止日期',
    required: true,
    helpMessage: '历史日期及配置的休假日期无法选择',
    componentProps: ({ formModel }) => ({
      request: async () => {
        const data = await holidayAction.getMoreDateHolidays()
        formModel['holidays'] = data
      },
      disabledDate: (current: Dayjs) => {
        const holidays = formModel['holidays'] || []
        return current < dayjs().endOf('day') || holidays.includes(current.format('YYYY-MM-DD'))
      },
    }),
  },
  {
    field: 'qty',
    component: 'InputNumber',
    label: '数量',
    required: true,
    componentProps: {
      formatter: transformInt,
      parser: transformInt,
    },
  },
  {
    field: 'remark',
    component: 'InputTextArea',
    label: '备注',
  },
]

/** 拆分的表单项 */
export const splitFormSchemas: FormSchema[] = [
  {
    field: 'code',
    component: 'Input',
    label: '编码',
    colProps: {
      span: 24,
    },
  },
  {
    field: 'canSplitQty',
    component: 'InputNumber',
    label: '剩余可拆分数量',
    dynamicDisabled: true,
  },
  {
    field: 'splitQty',
    component: 'InputNumber',
    label: '拆分数量',
    required: true,
    componentProps: ({ formModel }) => ({
      min: 1,
      max: +formModel['canSplitQty'] - 1,
      formatter: transformInt,
      parser: transformInt,
    }),
  },
  {
    field: 'lineId',
    component: 'Select',
    label: '产线',
    required: true,
    componentProps: {
      options: [],
    },
  },
  {
    field: 'planDate',
    component: 'RangePicker',
    label: '计划起止日期',
    required: true,
  },
  {
    field: 'remark',
    component: 'InputTextArea',
    label: '备注',
  },
]

/** 释放条码表单 */
export const snFormSchemas: FormSchema[] = [
  {
    field: 'snRule',
    component: 'Input',
    label: '条码规则',
    helpMessage: `来源: 属性-SnRule`,
    dynamicDisabled: true,
  },
  {
    field: 'canReleaseQty',
    component: 'InputNumber',
    label: '可释放数量',
    dynamicDisabled: true,
  },
  {
    field: 'releaseQty',
    component: 'InputNumber',
    label: '释放数量',
    required: true,
    componentProps: {
      formatter: transformInt,
      parser: transformInt,
      min: 1,
    },
  },
]
