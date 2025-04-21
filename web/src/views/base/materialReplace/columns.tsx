import type { TableColumn } from '@/components/core/dynamic-table'

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
    title: '源物料编码',
    dataIndex: ['sourceMaterial', 'code'],
  },
  {
    title: '源物料名称',
    dataIndex: ['sourceMaterial', 'name'],
    hideInSearch: true,
    ellipsis: true,
    resizable: true,
    width: 150,
  },
  {
    title: '替代物料编码',
    dataIndex: ['replaceMaterial', 'code'],
  },
  {
    title: '替代物料名称',
    dataIndex: ['replaceMaterial', 'name'],
    hideInSearch: true,
    ellipsis: true,
    resizable: true,
    width: 150,
  },
  {
    title: '工单',
    dataIndex: ['workOrder', 'code'],
    width: 160,
    hideInSearch: true,
  },
  {
    title: '有效开始日期',
    dataIndex: 'expDateS',
    hideInSearch: true,
    width: 160,
  },
  {
    title: '有效截止日期',
    dataIndex: 'expDateE',
    hideInSearch: true,
    width: 160,
  },
  {
    title: '备注',
    dataIndex: 'remark',
    hideInSearch: true,
    ellipsis: true,
    resizable: true,
    width: 150,
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
    hideInTable: true,
  },
]
