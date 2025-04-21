import type { TableColumn } from '@/components/core/dynamic-table'
import { Tag } from 'ant-design-vue'
import { TagColorEnum } from '@/enums/commonEnum'

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
    dataIndex: 'code',
    width: 200,
    ellipsis: true,
    resizable: true,
  },
  {
    title: '名称',
    dataIndex: 'name',
    width: 200,
    ellipsis: true,
    resizable: true,
  },
  {
    title: '版本',
    dataIndex: 'version',
    width: 100,
    hideInSearch: true,
  },
  {
    title: '阶别',
    dataIndex: 'level',
    width: 100,
    hideInSearch: true,
    customRender: ({ text }) => {
      return <Tag color={TagColorEnum[text]}>{text}</Tag>
    },
  },
  {
    title: '工序编码',
    dataIndex: ['processOperation', 'code'],
    align: 'center',
    width: 200,
    hideInSearch: true,
    ellipsis: true,
    resizable: true,
  },
  {
    title: '工序名称',
    dataIndex: ['processOperation', 'name'],
    align: 'center',
    width: 200,
    hideInSearch: true,
    ellipsis: true,
    resizable: true,
  },
  {
    title: '用量',
    dataIndex: 'useQty',
    align: 'center',
    width: 150,
    hideInSearch: true,
    ellipsis: true,
    resizable: true,
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
    hideInTable: true,
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

/** 明细列 */
export const detailColumns: TableColumn[] = [
  {
    title: '序号',
    dataIndex: 'index',
    align: 'center',
    customRender: ({ index }) => <span>{index + 1}</span>,
  },
  {
    title: '物料编码',
    dataIndex: 'materialCode',
    align: 'center',
  },
  {
    title: '物料名称',
    dataIndex: 'materialName',
    align: 'center',
  },
  {
    title: '工序编码',
    dataIndex: 'processCode',
    align: 'center',
  },
  {
    title: '工序名称',
    dataIndex: 'processName',
    align: 'center',
  },
  {
    title: '用量',
    dataIndex: 'useQty',
    align: 'center',
  },
]
