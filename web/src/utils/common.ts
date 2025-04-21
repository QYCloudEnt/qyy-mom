import dayjs from 'dayjs'
import type { DataNode } from 'ant-design-vue/es/vc-tree-select/interface'
import { uniqueSlash } from './urlUtils'

/**
 * @description 处理首字母大写 abc => Abc
 * @param str
 */
export const changeStr = (str: string) => {
  return str.charAt(0).toUpperCase() + str.slice(1)
}

/**
 * @description 随机生成颜色
 * @param {string} type
 * @return {string}
 */
export const randomColor = (type: 'rgb' | 'hex' | 'hsl'): string => {
  switch (type) {
    case 'rgb':
      return window.crypto.getRandomValues(new Uint8Array(3)).toString()
    case 'hex':
      return `#${Math.floor(Math.random() * 0xffffff)
        .toString(16)
        .padStart(6, `${Math.random() * 10}`)}`
    case 'hsl':
      // 在25-95%范围内具有饱和度，在85-95%范围内具有亮度
      return [360 * Math.random(), `${100 * Math.random()}%`, `${100 * Math.random()}%`].toString()
  }
}

/**
 * 复制文本
 * @param text
 */
export const copyText = (text: string) => {
  const copyInput = document.createElement('input') //创建一个input框获取需要复制的文本内容
  copyInput.value = text
  document.body.appendChild(copyInput)
  copyInput.select()
  document.execCommand('copy')
  copyInput.remove()
}

/**
 * @description 判断字符串是否是base64
 * @param {string} str
 */
export const isBase64 = (str: string): boolean => {
  if (str === '' || str.trim() === '') {
    return false
  }
  try {
    return btoa(atob(str)) == str
  } catch (err) {
    return false
  }
}
// 对象转JSON
export const toJSON = obj => {
  return JSON.stringify(obj, (_, value) => {
    switch (true) {
      case typeof value === 'undefined':
        return 'undefined'
      case typeof value === 'symbol':
        return value.toString()
      case typeof value === 'function':
        return value.toString()
      default:
        break
    }
    return value
  })
}

/**
 * * JSON序列化，支持函数和 undefined
 * @param data
 */
export const JSONStringify = <T>(data: T) => {
  return JSON.stringify(
    data,
    (_key, val) => {
      // 处理函数丢失问题
      if (typeof val === 'function') {
        return `${val}`
      }
      // 处理 undefined 丢失问题
      if (typeof val === 'undefined') {
        return null
      }
      return val
    },
    2,
  )
}

export const evalFn = (fn: string) => {
  var Fun = Function // 一个变量指向Function，防止前端编译工具报错
  return new Fun('return ' + fn)()
}

/**
 * * JSON反序列化，支持函数和 undefined
 * @param data
 */
export const JSONParse = (data: string) => {
  return JSON.parse(data, (_k, v) => {
    // 还原函数值
    if (
      typeof v === 'string' &&
      v.indexOf &&
      (v.indexOf('function') > -1 || v.indexOf('=>') > -1)
    ) {
      return evalFn(`(function(){return ${v}})()`)
    } else if (typeof v === 'string' && v.indexOf && v.indexOf('return ') > -1) {
      const baseLeftIndex = v.indexOf('(')
      if (baseLeftIndex > -1) {
        const newFn = `function ${v.substring(baseLeftIndex)}`
        return evalFn(`(function(){return ${newFn}})()`)
      }
    }
    return v
  })
}

/***
 * @description 是否是生产环境
 */
export const IS_PROD = import.meta.env.PROD
export const IS_DEV = import.meta.env.DEV

/***
 * @description 格式化日期
 * @param time
 */
export const formatDate = time => dayjs(time).format('YYYY-MM-DD HH:mm:ss')

/**
 *  @description 将一维数组转成树形结构数据
 * @param items
 * @param id
 * @param link
 */
export const generateTree = (items, id = 0, link = 'parent') => {
  return items
    .filter(item => item[link] == id)
    .map(item => ({
      ...item,
      slots: { title: 'name' },
      children: generateTree(items, item.departmentid),
    }))
}

/***
 * @description 原生加密明文
 * @param {string} plaintext
 */
// const encryption = (plaintext: string) =>
//   isBase64(plaintext) ? plaintext : window.btoa(window.encodeURIComponent(plaintext));

/**
 * @description 原生解密
 * @param {string} ciphertext
 */
// const decryption = (ciphertext: string) =>
//   isBase64(ciphertext) ? window.decodeURIComponent(window.atob(ciphertext)) : ciphertext;

// const viewsModules = import.meta.glob('../views/**/*.vue');

/**
 * / _ - 转换成驼峰并将view替换成空字符串
 * @param {*} name name
 */
export const toHump = name => {
  return name
    .replace(/[-/_](\w)/g, (_, letter) => {
      return letter.toUpperCase()
    })
    .replace('views', '')
}

/** 模拟异步请求，实用性不高，主要用于demo模拟请求 */
export const waitTime = <T>(time = 100, data: any = true): Promise<T> => {
  const { promise, resolve } = Promise.withResolvers<T>()
  setTimeout(() => {
    resolve(data)
  }, time)
  return promise
}

export function findPath<T extends Key>(
  tree: Recordable[],
  targetId: T,
  field = 'id',
  currentPath: T[] = [],
): T[] | null {
  // 遍历树中的每个节点
  for (const node of tree) {
    // 将当前节点的 ID 添加到路径中
    const path = [...currentPath, node[field]]

    // 如果找到目标节点，返回路径
    if (node.id === targetId) {
      return path
    }

    // 如果当前节点有子节点，则递归查找子节点
    if (node.children && node.children.length > 0) {
      const childPath = findPath(node.children, targetId, field, path)
      if (childPath) {
        return childPath
      }
    }
  }

  // 没有找到目标节点，返回 null
  return null
}

export const str2tree = (str: string, treeData: DataNode[] = [], separator = ':') => {
  return str.split(separator).reduce((prev, curr, currentIndex, arr) => {
    const path = arr.slice(0, currentIndex + 1).join(':')
    const index = prev.findIndex(item => item?.path === path)
    if (index !== -1) {
      return prev[index].children
    } else {
      const item: DataNode = {
        // key: curr,
        path,
        value: curr,
        label: curr,
        children: [],
      }
      prev.push(item)
      return item.children!
    }
  }, treeData)
}

/**
 * 获取url中参数对象
 * @param url url地址
 * @returns json对象
 */
export const getQueryParams = (url: string) => {
  const ind = url.indexOf('?')
  if (ind == -1) return null
  url = url.substring(ind)
  const query = url.substring(1)
  const arr = query.split('&')
  const params = {}
  for (let i = 0; i < arr.length; i++) {
    const pair = arr[i].split('=')
    params[pair[0]] = pair[1]
  }
  return params
}

/**
 * 去除字符串中的HTML元素标记、脚本代码等
 * @param str 字符
 * @returns
 */
export const replaceScript = (str: string) => {
  let res = new DOMParser().parseFromString(str, 'text/html').body.textContent || ''
  res = res
    .replaceAll(/javascript\s*:/gi, '')
    .replaceAll(/alert\s*\(/gi, '')
    .replaceAll(/eval\s*\(/gi, '')
    .replaceAll(/document.write/gi, '')
  return res
}

/**
 * 查找二维数组中是否包含某个子数组
 * @param arr 源数组
 * @param subArr 子数组
 * @returns true or false
 */
export const hasSubArray = (arr, subArr) => {
  if (!arr || !subArr) return false
  return arr.some(a => a.every((item, i) => item === subArr[i]))
}

/**
 * 渲染图片
 * @param imgUrl 图片地址
 */
export const renderImg = (imgUrl: string) => {
  if (!imgUrl) return ''
  return imgUrl.startsWith('http')
    ? imgUrl
    : uniqueSlash(`${import.meta.env.VITE_BASE_STATIC_URL}${imgUrl}`).trim()
}

/**
 * InputNumber组件 只允许输入整数
 * @param value 值
 * @returns
 */
export const transformInt = (value: number | string) => {
  let v: number | string = ''
  switch (typeof value) {
    case 'string':
      v = isNaN(+value) ? 0 : value.replace(/\./g, '')
      break
    case 'number':
      v = isNaN(value) ? 0 : String(value).replace(/\./g, '')
      break
    default:
      v = 0
  }
  return `${v}`
}
