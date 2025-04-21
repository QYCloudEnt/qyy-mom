import type { TableColumn } from '../core/dynamic-table'

/** 用户选择列 */
export const userColumns: TableColumn<API.UserInfoCache>[] = [
  {
    title: 'id',
    dataIndex: 'id',
    width: 55,
    align: 'center',
    hideInTable: true,
    hideInSearch: true,
  },
  {
    title: '用户编码',
    dataIndex: 'code',
    align: 'center',
    formItemProps: {
      colProps: {
        span: 6,
      },
    },
  },
  {
    title: '用户名称',
    dataIndex: 'name',
    align: 'center',
    formItemProps: {
      colProps: {
        span: 6,
      },
    },
  },
  {
    title: '邮箱',
    dataIndex: 'email',
    align: 'center',
    hideInSearch: true,
  },
]

/** 物料列信息 */
export const materialColumns: TableColumn[] = [
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
    dataIndex: 'code',
  },
  {
    title: '名称',
    dataIndex: 'name',
  },
  {
    title: '规格型号',
    width: 150,
    dataIndex: 'spec',
    hideInSearch: true,
  },
  {
    title: '单位',
    dataIndex: 'unitName',
    hideInSearch: true,
  },
]
