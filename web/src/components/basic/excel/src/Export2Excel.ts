import { utils, writeFile } from 'xlsx'
import type { WorkBook } from 'xlsx'
import type { JsonToSheet, AoAToSheet } from './typing'
import type { TableColumn } from '@/components/core/dynamic-table'

const DEF_FILE_NAME = 'excel-list.xlsx'

export function jsonToSheetXlsx<T = any>({
  data,
  header,
  filename = DEF_FILE_NAME,
  json2sheetOpts = {},
  write2excelOpts = { bookType: 'xlsx' },
}: JsonToSheet<T>) {
  let arrData = [...data]
  if (header) {
    arrData.unshift(header)
    const filterKeys = Object.keys(header)
    arrData = arrData.map(item => filterKeys.reduce<any>((p, k) => ((p[k] = item[k]), p), {}))
    json2sheetOpts.skipHeader = true
  }

  const worksheet = utils.json_to_sheet(arrData, json2sheetOpts)

  /* add worksheet to workbook */
  const workbook: WorkBook = {
    SheetNames: [filename],
    Sheets: {
      [filename]: worksheet,
    },
  }
  /* output format determined by filename */
  writeFile(workbook, filename, write2excelOpts)
  /* at this point, out.xlsb will have been downloaded */
}

export function aoaToSheetXlsx<T = any>({
  data,
  header,
  filename = DEF_FILE_NAME,
  write2excelOpts = { bookType: 'xlsx' },
}: AoAToSheet<T>) {
  const arrData = [...data]
  if (header) {
    arrData.unshift(header)
  }

  const worksheet = utils.aoa_to_sheet(arrData)

  /* add worksheet to workbook */
  const workbook: WorkBook = {
    SheetNames: [filename],
    Sheets: {
      [filename]: worksheet,
    },
  }
  /* output format determined by filename */
  writeFile(workbook, filename, write2excelOpts)
  /* at this point, out.xlsb will have been downloaded */
}

/**
 * 导出表格数据
 * @param dataSource 数据源
 * @param columns 表格列
 * @param fileName 导出文件名称
 */
export const exportExcelForTable = (
  dataSource: Array<any>,
  columns: TableColumn<any>[],
  fileName: string,
) => {
  // console.log(columns, fileName)
  // 处理标题分组
  const _columns: TableColumn<any>[] = []
  columns.forEach(column => {
    if (column.children && column.children?.length > 0) {
      _columns.push(...column.children.map(n => ({ ...n, title: `${column.title} - ${n.title}` })))
    } else {
      _columns.push(column)
    }
  })
  const colFilters = _columns.filter(n => n.dataIndex !== 'ACTION' && !n.hideInColumnSet)
  const colFilterKeys = colFilters.map(n => n.dataIndex)

  // 保证data顺序与header一致
  aoaToSheetXlsx({
    data: dataSource
      .map(item => {
        return colFilterKeys.reduce((p, k: string) => {
          if (!p || !k) return p
          p[k] = Array.isArray(item[k]) ? item[k].toString() : item[k]
          return p
        }, {})
      })
      .map(item => Object.values(item || {})),
    header: colFilters.map(column => column.title),
    filename: `${
      fileName.length > 31 ? `${fileName.replace('.xlsx', '').slice(0, 26)}.xlsx` : fileName
    }`,
  })
}
