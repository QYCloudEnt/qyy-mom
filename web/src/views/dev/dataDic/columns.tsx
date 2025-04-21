import type { TableColumn } from '@/components/core/dynamic-table'

export const baseColumns: TableColumn[] = [
  {
    title: 'id',
    dataIndex: 'id',
    width: 55,
    align: 'center',
    hideInTable: true,
    hideInSearch: true,
  },
  {
    title: '编码',
    dataIndex: 'code',
    width: 120,
    align: 'center',
  },
  {
    title: '名称',
    dataIndex: 'name',
    width: 100,
    align: 'center',
  },
  {
    title: '备注',
    dataIndex: 'remark',
    width: 100,
    align: 'center',
    hideInSearch: true,
  },
  {
    title: '分类编码',
    dataIndex: 'categoryCode',
    width: 80,
    align: 'center',
    hideInSearch: true,
  },
  {
    title: '分类名称',
    dataIndex: 'categoryName',
    width: 80,
    align: 'center',
    hideInSearch: true,
  },
  {
    title: '排序',
    dataIndex: 'sortNo',
    width: 55,
    align: 'center',
    hideInSearch: true,
  },
]
