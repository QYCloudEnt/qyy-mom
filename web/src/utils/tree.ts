import type { TreeDataItem as ATreeDataItem } from 'ant-design-vue/es/tree/Tree'

export interface TreeDataItem extends ATreeDataItem {
  children: any
}

/**
 * 渲染部门至树形控件
 * @param {Array} depts 所有部门
 * @param {Number | null} parentId 父级部门ID
 * @param {number[]|string[]} keyPath ID路径
 */
export const formatDept2Tree = (
  depts: API.SysDeptListResult[],
  parentId: number | null = null,
  keyPath: (string | number)[] = [],
): TreeDataItem[] => {
  return depts
    .filter(item => item.parentId === parentId)
    .map(item => {
      const _keyPath = keyPath.concat(parentId || [])
      const arr = formatDept2Tree(depts, item.id, _keyPath)
      return Object.assign(item, {
        keyPath: _keyPath,
        title: item.name,
        key: item.id,
        value: item.id,
        formData: item,
        children: arr.length ? arr : null,
      })
    })
}

/**
 * 渲染菜单至树形控件
 * @param {Array} menus 所有菜单
 * @param {Number | null} parentId 父级菜单ID
 * @param {number[]|string[]} keyPath ID路径
 */
export const formatMenu2Tree = (
  menus: API.MenuListResult,
  parentId: number | null = null,
  keyPath: (string | number)[] = [],
): TreeDataItem[] => {
  return menus
    .filter(item => item.parentId === parentId)
    .map(item => {
      const _keyPath = keyPath.concat(parentId || [])
      const arr = formatMenu2Tree(menus, item.id, _keyPath)
      return Object.assign(item, {
        keyPath: _keyPath,
        title: item.name,
        key: item.id,
        value: item.id,
        formData: item,
        children: arr.length ? arr : null,
      })
    })
}

/**
 * 渲染数据至树形控件
 * @param {Array} data 所有数据
 * @param {string} name 显示的字段
 * @param {Number | null} parentId 父级ID
 * @param {number[]|string[]} keyPath ID路径
 * @param {string} id 递归的主键字段, 默认: Id
 * @param {string} pid 父元素的字段, 默认: ParentId
 */
export const formatTree = (
  data: Array<any>,
  name: string,
  parentId: number | null = null,
  keyPath: (string | number)[] = [],
  id: string = 'id',
  pid: string = 'parentId',
): TreeDataItem[] => {
  return data
    .filter(item => (item[pid] as number) === parentId)
    .map(item => {
      if (parentId === -1) parentId = null
      const _keyPath = keyPath.concat(parentId || [])
      const arr = formatTree(data, name, item[id], _keyPath, id, pid)
      return Object.assign(item, {
        keyPath: _keyPath,
        title: item[name],
        name: item[name],
        key: item[id],
        value: item[id],
        formData: item,
        children: arr.length ? arr : null,
      })
    })
}

/**
 * 渲染数据至树形表格
 * @param {Array} data 所有数据
 * @param {number | string | null} parent 最顶级父级元素值
 * @param {number[]|string[]} keyPath ID路径
 * @param {string} id 递归的主键字段, 默认: Id
 * @param {string} pid 父元素的字段, 默认: ParentId
 * @param {boolean} isInit 是否是初始化, 默认: true
 */
export const formatToTreeTable = (
  data: Array<any>,
  parent: number | string | null = null,
  keyPath: (string | number)[] = [],
  id: string = 'id',
  pid: string = 'parentId',
  isInit: boolean = true,
): TreeDataItem[] => {
  if (isInit) {
    const item = data.find(item => item[pid] === parent)
    !item && (parent = data?.[0]?.[pid] || parent) // 防止筛选查询子级时不显示
  }
  return data
    .filter(item => (item[pid] as number | String) === parent)
    .map(item => {
      const _keyPath = keyPath.concat(parent || [])
      const arr = formatToTreeTable(data, item[id], _keyPath, id, pid, false)
      return Object.assign(item, {
        keyPath: _keyPath,
        key: item[id],
        children: arr.length ? arr : null,
      })
    })
}

/**
 * 在树中根据ID找child
 * @param {string|number} id
 * @param {any[]} treeData 树形数据
 * @param {string} keyName 指定ID的属性名，默认是id
 * @param {string} children 指定children的属性名，默认是children
 */
export const findChildById = <T = any>(
  id,
  treeData: T[] = [],
  keyName = 'id',
  children = 'children',
) => {
  return treeData.reduce((prev, curr) => {
    if (curr[keyName] === id) {
      return curr
    }
    if (prev) {
      return prev
    }
    if (curr[children]?.length) {
      return findChildById(id, curr[children], keyName, children)
    }
  }, undefined)
}
