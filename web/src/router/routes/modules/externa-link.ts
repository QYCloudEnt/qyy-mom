import { RouterView, type RouteRecordRaw } from 'vue-router'

const routes: Array<RouteRecordRaw> = [
  {
    path: 'https://gitee.com/thgao/tmom',
    name: 'https://gitee.com/thgao/tmom',
    component: RouterView,
    meta: {
      title: '代码仓库',
      icon: 'ant-design:link-outlined',
      isExt: true,
      extOpenMode: 1,
    },
  },
]

export default routes
