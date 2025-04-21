import type { TableColumn } from '@/components/core/dynamic-table'

export const baseColumns: TableColumn[] = [
  {
    title: 'id',
    dataIndex: 'id',
    sorter: true,
    width: 60,
    hideInTable: true,
    hideInSearch: true,
  },
  {
    title: '编码',
    width: 150,
    dataIndex: 'code',
  },
  {
    title: '名称',
    width: 150,
    dataIndex: 'name',
  },
  {
    title: '所属车间',
    dataIndex: ['workshop', 'name'],
    hideInSearch: true,
  },
  {
    title: '描述',
    dataIndex: 'description',
    hideInSearch: true,
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
    width: 160,
    hideInSearch: true,
  },
  {
    title: '更新时间',
    dataIndex: 'updateTime',
    width: 160,
    hideInSearch: true,
  },
]
