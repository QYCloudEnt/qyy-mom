import { resolve } from 'node:path'
import { loadEnv } from 'vite'
import vueJsx from '@vitejs/plugin-vue-jsx'
import vue from '@vitejs/plugin-vue'
import checker from 'vite-plugin-checker'
import Components from 'unplugin-vue-components/vite'
import { AntDesignVueResolver } from 'unplugin-vue-components/resolvers'
import Unocss from 'unocss/vite'
import { createSvgIconsPlugin } from 'vite-plugin-svg-icons'
import dayjs from 'dayjs'
import pkg from './package.json'
import type { UserConfig, ConfigEnv } from 'vite'

const CWD = process.cwd()

const __APP_INFO__ = {
  pkg,
  lastBuildTime: dayjs().format('YYYY-MM-DD HH:mm:ss'),
}

export default ({ command, mode }: ConfigEnv): UserConfig => {
  // 环境变量
  const { VITE_BASE_URL, VITE_DROP_CONSOLE } = loadEnv(mode, CWD)

  const isDev = command === 'serve'

  return {
    base: VITE_BASE_URL,
    define: {
      __APP_INFO__: JSON.stringify(__APP_INFO__),
    },
    resolve: {
      alias: [
        {
          find: '@',
          replacement: resolve(__dirname, './src'),
        },
      ],
    },
    plugins: [
      vue(),
      Unocss(),
      vueJsx({
        // options are passed on to @vue/babel-plugin-jsx
      }),
      createSvgIconsPlugin({
        iconDirs: [resolve(CWD, 'src/assets/icons')],
        symbolId: 'svg-icon-[dir]-[name]',
      }),
      Components({
        dts: 'types/components.d.ts',
        types: [
          {
            from: './src/components/basic/button/',
            names: ['AButton'],
          },
          {
            from: 'vue-router',
            names: ['RouterLink', 'RouterView'],
          },
        ],
        resolvers: [
          AntDesignVueResolver({
            importStyle: false,
            exclude: ['Button'],
          }),
        ],
      }),
      isDev &&
        checker({
          typescript: true,
          eslint: {
            useFlatConfig: true,
            lintCommand: 'eslint "./src/**/*.{.vue,ts,tsx}"',
          },
          overlay: {
            initialIsOpen: false,
          },
        }),
    ],
    css: {
      preprocessorOptions: {
        less: {
          javascriptEnabled: true,
          modifyVars: {},
        },
      },
    },
    server: {
      host: '0.0.0.0',
      port: 7002,
      open: false,
      warmup: {
        clientFiles: ['./index.html', './src/{components,api}/*'],
      },
    },
    optimizeDeps: {
      include: [
        'lodash-es',
        'echarts',
        'ant-design-vue/es/locale/zh_CN',
        'ant-design-vue/es/locale/en_US',
      ],
    },
    esbuild: {
      pure: VITE_DROP_CONSOLE === 'true' ? ['console.log', 'debugger'] : [],
      supported: {
        'top-level-await': true,
      },
    },
    build: {
      minify: 'esbuild',
      cssTarget: 'chrome89',
      chunkSizeWarningLimit: 2000,
      rollupOptions: {
        output: {
          manualChunks(id) {
            if (id.includes('/src/locales/helper.ts')) {
              return 'antdv'
            } else if (id.includes('node_modules/ant-design-vue/')) {
              return 'antdv'
            } else if (/node_modules\/(vue|vue-router|pinia)\//.test(id)) {
              return 'vue'
            }
          },
        },
        onwarn(warning, rollupWarn) {
          if (
            warning.code === 'CYCLIC_CROSS_CHUNK_REEXPORT' &&
            warning.exporter?.includes('src/api/')
          ) {
            return
          }
          rollupWarn(warning)
        },
      },
    },
  }
}
