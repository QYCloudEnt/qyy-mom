import { http } from '@/api/http'
import { request, uploadFile } from '@/utils/request'
import type { AxiosProgressEvent } from 'axios'
import type { UploadFileParams } from '@/api/axios'

/**
 * 系统用户接口
 */
export default {
  /**
   * 获取分页列表
   * @param query
   * @returns
   */
  getWithPage: (query: API.PageParams) => http.get('/SysUser/GetWithPage', query),

  /**
   * 根据Id获取单条
   * @param id
   * @returns
   */
  getById: (id: number) => http.get(`/SysUser/Get/${id}`),

  /**
   * 新增一条数据
   * @param data
   * @returns
   */
  add: (data: any) => http.post(`/SysUser/Add`, data),

  /**
   * 删除数据
   * @param ids 主键Ids
   * @returns
   */
  delete: (ids: number[]) => http.delete(`/SysUser/Delete`, { ids: ids.join(',') }),

  /**
   * 更新数据
   * @param data
   * @returns
   */
  update: (data: any) => http.put(`/SysUser/Update`, data),

  /**
   * 修改/重置用户密码
   * @param id 主键Id
   * @param pwd 密码
   * @param oldPwd 旧密码
   * @returns
   */
  editPwd: (id: number, pwd?: string, oldPwd: string = '') =>
    http.postStr(`/SysUser/EditPwd`, { id, pwd: pwd ?? '123456', oldPwd }),

  /**
   * 重置密码
   * @param id 用户id
   * @returns
   */
  resetPwd: (id: number) => http.postStr(`/SysUser/ResetPwd`, { id }),

  /**
   * 获取用户信息
   * @returns
   */
  getInfo: () =>
    request<API.AdminUserInfo>({
      url: '/SysUser/GetUserInfo',
      method: 'get',
    }),

  /**
   * 用户的权限、菜单
   * @returns
   */
  permmenu: () =>
    request<API.PermMenu>({
      url: '/SysUser/GetPermMenu',
      method: 'get',
    }),

  /**
   * 上传头像
   * @param params 文件参数
   * @param onUploadProgress
   * @returns
   */
  uploadAvatar: (
    params: UploadFileParams,
    onUploadProgress: (progressEvent: AxiosProgressEvent) => void,
  ) =>
    uploadFile(
      {
        url: `/SysUser/UploadAvatar`,
        onUploadProgress,
      },
      params,
    ),

  /**
   * 更新个人信息
   * @param data
   * @returns
   */
  updateBaseInfo: (data: any) => http.patch(`/SysUser/UpdateBaseInfo`, data),

  /**
   * 获取缓存的用户信息列表
   * @returns 用户 id、code、name、email、isSuper 基本信息列表
   */
  getUserListWithCache: () => http.get<API.UserInfoCache[]>(`/SysUser/GetAllUserWithCache`),
}
