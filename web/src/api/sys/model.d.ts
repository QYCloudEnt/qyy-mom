declare namespace API {
  // type Menu = {
  //   createTime: Date
  //   updateTime: Date
  //   id: number
  //   parentId: number
  //   name: string
  //   router: string
  //   perms: string
  //   type: 0 | 1 | 2
  //   icon: string
  //   orderNum: number
  //   viewPath: string
  //   keepalive: boolean
  //   isShow: boolean
  //   isExternal: boolean
  //   isEmbed: boolean
  // }

  /** 用户菜单 */
  type UserMenus = {
    meta: MenuMeta
    id: number
    parentId?: number
    path: string
    name: string
    component: string
    redirect?: string
    children?: UserMenus[]
  }

  type MenuMeta = {
    title: string
    permission?: string
    type?: number
    icon?: string
    orderNo?: number
    component?: string
    isExt?: boolean
    extOpenMode?: number
    /** 内嵌的iframe显示的路由 */
    frameRoute?: string
    keepAlive?: number
    show?: number
    activeMenu?: string
    status?: number
  }

  type PermMenu = {
    menus: UserMenus[]
    perms: string[]
  }

  type AdminUserInfo = {
    id: number
    loginAccount: string
    realName: string
    avatar: string
    orgId?: number
    isSuper: boolean
    phoneNo: string
    email: string
    loginIp: string
    addr: string
    remark: string
  }

  /** 缓存的用户基本信息 */
  type UserInfoCache = {
    /** 用户id */
    id: number
    /** 用户编码 */
    code: string
    /** 用户名称 */
    name: string
    /** 用户邮箱 */
    email: string
    /** 是否超级管理员 */
    isSuper: boolean
  }

  /** 获取系统部门返回结果 */
  type SysDeptListResult = {
    createTime: string
    updateTime: string
    id: number
    parentId: number
    name: string
    orderNum: number
    keyPath?: number[]
  }

  type MenuListResultItem = {
    createTime: string
    updatedAt: string
    id: number
    parentId: number
    name: string
    router: string
    perms: string
    type: number
    icon: string
    orderNum: number
    viewPath: string
    keepalive: boolean
    isShow: boolean
    keyPath?: number[]
  }

  /** 获取菜单列表参数 */
  type MenuListResult = MenuListResultItem[]

  /**
   * 系统日志
   */
  type SysLogResult = {
    Id: number
    IP?: string
    ApiUrl: string
    OPTime: string
    HttpType: string
    RequestParams: string
    ResponseData: string
    Import: number
    LogType: string
    Content: string
    Datetime: string
    Success: boolean
  }
}
