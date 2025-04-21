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
    title: '编码',
    width: 150,
    dataIndex: 'code',
  },
  {
    title: '名称',
    width: 200,
    dataIndex: 'name',
  },
  {
    title: '简称',
    dataIndex: 'shortName',
    hideInSearch: true,
    width: 150,
  },
  {
    title: '联系方式',
    dataIndex: 'phone',
    hideInSearch: true,
    width: 150,
  },
  {
    title: '地址',
    dataIndex: 'addr',
    hideInSearch: true,
    width: 300,
    ellipsis: true,
    resizable: true,
  },
  {
    title: '社会信用代码',
    dataIndex: 'creditCode',
    hideInSearch: true,
    width: 200,
    ellipsis: true,
    resizable: true,
  },
  {
    title: '备注',
    dataIndex: 'remark',
    hideInSearch: true,
    width: 300,
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
