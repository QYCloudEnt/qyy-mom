/// <reference types="vite/client" />

interface ImportMetaEnv {
  /** 网站标题 */
  readonly VITE_APP_TITLE: string
  /** 网站部署的目录 */
  readonly VITE_BASE_URL: string
  /** API 接口路径 */
  readonly VITE_BASE_API_URL: string
  /** socket 请求路径前缀 */
  readonly VITE_BASE_SOCKET_PATH: string
  /** socket 命名空间 */
  readonly VITE_BASE_SOCKET_NSP: string
  /** mock API 路径 */
  readonly VITE_MOCK_API: string
  /** 静态文件路径 */
  readonly VITE_BASE_STATIC_URL: string
  /** 大屏路由跳转地址 */
  readonly VITE_BIGSCREEN_URL: string
  /** AOT客户端地址 */
  readonly VITE_BASE_AOT_CLIENT_URL: string
}

interface ImportMeta {
  readonly env: ImportMetaEnv
  readonly globEager: (...args) => {}
}
