import type { TableColumn } from '@/components/core/dynamic-table'
import { getTagColor, transformEnumToOptions } from '@/enums/commonEnum'
import { Tag } from 'ant-design-vue'

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
    title: '类型',
    dataIndex: 'type',
    width: 150,
    formItemProps: {
      component: 'Select',
      componentProps: {
        options: [],
      },
    },
  },
  {
    title: '编码',
    dataIndex: 'code',
    width: 260,
  },
  {
    title: '工序',
    dataIndex: ['operation', 'code'],
    hideInSearch: true,
  },
  {
    title: '锁定起止日期',
    dataIndex: 'time',
    width: 300,
    customRender: ({ record }) => {
      if (record.dateS) {
        return `${record.dateS} ~ ${record.dateE}`
      }
    },
    hideInSearch: true,
  },
  {
    title: '锁定原因',
    dataIndex: 'lockReason',
    width: 200,
    ellipsis: true,
    resizable: true,
  },
  {
    title: '锁定人',
    dataIndex: 'lockUser',
    hideInSearch: true,
    width: 160,
  },
  {
    title: '锁定时间',
    dataIndex: 'lockTime',
    hideInSearch: true,
    width: 170,
  },
]
