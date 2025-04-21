// @ts-ignore
/* eslint-disable */

declare namespace API {
  /** 全局通过表格查询返回结果 */
  type TableListResult<T = any> = {
    /** 表格数据列表(Array) */
    list: T;
    pagination?: PaginationResult;
  };

  /** 全局通用表格分页返回数据结构 */
  type PaginationResult = {
    pageIndex: number;
    pageSize: number;
    pageCount: number;
    total: number;
  };

  /** 全局通用表格分页请求参数 */
  type PageParams<T = any> = {
    pageIndex?: number;
    pageSize?: number;
  } & {
    [P in keyof T]?: T[P];
  };

  type ErrorResponse = {
    /** 业务约定的错误码 */
    errorCode: string;
    /** 业务上的错误信息 */
    errorMessage?: string;
    /** 业务上的请求是否成功 */
    success?: boolean;
  };

  /**
   * 选择下拉框数据
   */
  type SelectResult = {
    label: string
    value: string | number
    remark?: string
  }

  /** 接口返回基类 */
  type ResOp = {
    status: number
    success: boolean
    msg: string
    msgDev: string
    data: Record<string, any>
  }
}
