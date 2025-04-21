import type { TableColumn } from '@/components/core/dynamic-table'
import { Tag, Progress } from 'ant-design-vue'
import { WorkOrderStatusEnum, getTagColor, transformEnumToOptions } from '@/enums/commonEnum'

export const baseColumns: TableColumn[] = [
  {
    title: 'id',
    dataIndex: 'id',
    width: 60,
    sorter: true,
    hideInTable: true,
    hideInSearch: true,
  },
  {
    title: '编码',
    width: 150,
    dataIndex: 'code',
    ellipsis: true,
    resizable: true,
  },
  {
    title: '类型',
    dataIndex: 'type',
    width: 100,
    formItemProps: {
      component: 'Select',
      componentProps: {
        options: [],
      },
    },
    customRender: ({ text, record }) => <Tag color={getTagColor(text)}>{record.typeName}</Tag>,
  },
  {
    title: '工艺路线',
    dataIndex: ['processRoute', 'name'],
    width: 200,
    hideInSearch: true,
    ellipsis: true,
    resizable: true,
  },
  {
    title: '主数据',
    dataIndex: ['part', 'code'],
    width: 150,
    hideInSearch: true,
    ellipsis: true,
    resizable: true,
  },
  {
    title: '产线',
    dataIndex: ['line', 'code'],
    width: 150,
    hideInSearch: true,
    ellipsis: true,
    resizable: true,
  },
  {
    title: '状态',
    dataIndex: 'status',
    width: 100,
    formItemProps: {
      component: 'Select',
      componentProps: {
        options: transformEnumToOptions(WorkOrderStatusEnum),
      },
    },
    customRender: ({ text }) => <Tag color={getTagColor(text)}>{WorkOrderStatusEnum[text]}</Tag>,
  },
  {
    title: '数量',
    dataIndex: 'qty',
    width: 150,
    hideInSearch: true,
  },
  {
    title: '已完成数量',
    dataIndex: 'completedQty',
    width: 150,
    hideInSearch: true,
  },
  {
    title: '进度',
    dataIndex: 'progress',
    width: 150,
    hideInSearch: true,
    customRender: ({ record }) => {
      const val = +(+record.completedQty / +record.qty).toFixed(2) * 100
      return <Progress status={val >= 100 ? 'success' : 'active'} percent={val} />
    },
  },
  {
    title: '计划开始时间',
    dataIndex: 'planDateS',
    width: 160,
    hideInSearch: true,
    customRender: ({ text }) => {
      return text ? text.split(' ')[0] : ''
    },
  },
  {
    title: '计划结束时间',
    dataIndex: 'planDateE',
    width: 160,
    hideInSearch: true,
    customRender: ({ text }) => {
      return text ? text.split(' ')[0] : ''
    },
  },
  {
    title: '实际开始时间',
    dataIndex: 'actualDateS',
    width: 160,
    hideInSearch: true,
    customRender: ({ text }) => {
      return text ? text.split(' ')[0] : ''
    },
  },
  {
    title: '实际结束时间',
    dataIndex: 'actualDateE',
    width: 160,
    hideInSearch: true,
    customRender: ({ text }) => {
      return text ? text.split(' ')[0] : ''
    },
  },
  {
    title: '投入数量',
    dataIndex: 'inputQty',
    width: 150,
    hideInSearch: true,
  },
  {
    title: '良品数量',
    dataIndex: 'okQty',
    width: 150,
    hideInSearch: true,
  },
  {
    title: '报废数量',
    dataIndex: 'scrapedQty',
    width: 150,
    hideInSearch: true,
  },
  {
    title: '来源',
    dataIndex: 'from',
    width: 100,
    formItemProps: {
      component: 'Select',
      componentProps: {
        options: [
          { label: 'ERP', value: 'ERP' },
          { label: 'MES', value: 'MES' },
        ],
      },
    },
    customRender: ({ text }) => <Tag color={getTagColor(text)}>{text}</Tag>,
  },
  {
    title: '源工单号',
    dataIndex: 'sourceCode',
    width: 150,
    ellipsis: true,
    resizable: true,
    hideInSearch: true,
  },
  {
    title: '备注',
    dataIndex: 'remark',
    hideInSearch: true,
    width: 200,
    ellipsis: true,
    resizable: true,
  },
  {
    title: '创建人',
    dataIndex: 'createUser',
    width: 160,
    hideInSearch: true,
  },
  {
    title: '创建时间',
    dataIndex: 'createTime',
    width: 170,
    sorter: true,
    hideInSearch: true,
  },
  {
    title: '更新人',
    dataIndex: 'updateUser',
    width: 160,
    hideInSearch: true,
    hideInTable: true,
  },
  {
    title: '更新时间',
    dataIndex: 'updateTime',
    width: 170,
    hideInSearch: true,
  },
]
