import type { TableProps } from 'ant-design-vue'
import type { TablePaginationConfig } from 'ant-design-vue/es/table'
import type { DynamicTableProps, DynamicTableEmitFn } from '../dynamic-table'
import type {
  ExportData2Excel,
  TableForm,
  TableMethods,
  TableState,
  UseEditableType,
} from '../hooks'
import type { Slots } from 'vue'

/**
 * 加载表格数据的参数
 */
export type LoadDataParams = TablePaginationConfig & {
  /** 根据自己业务需求定义页码 */
  pageIndex?: number
  /** 根据自己业务需求定义页数据条数 */
  pageSize?: number
}

/** 表格onChange事件回调参数 */
export type OnChangeCallbackParams = Parameters<NonNullable<TableProps['onChange']>>

/** 表格onChange事件回调函数 */
export type OnChangeCallback = TableProps['onChange']

/** 编辑行类型 */
export type EditableType = 'single' | 'multiple' | 'cell' | 'dynamicCell'

/** 单元格保存回调 */
export type OnSave<T = any> = (
  /** 行 id，一般是唯一id */
  key: Key,
  /** 当前修改的行的值，只有 form 在内的会被设置 */
  record: T,
  /** 原始值，可以用于判断是否修改 */
  originRow: T,
) => Promise<any | void>

/** 单元格取消保存回调 */
export type OnCancel<T = any> = (
  /** 行 id，一般是唯一id */
  key: Key,
  /** 当前修改的行的值，只有 form 在内的会被设置 */
  record: T,
  /** 原始值，可以用于判断是否修改 */
  originRow: T,
) => any | void

export type DynamicTableType = TableState &
  ExportData2Excel &
  UseEditableType &
  TableForm &
  TableMethods & {
    props: DynamicTableProps
    emit: DynamicTableEmitFn
    slots: Slots
  }
