<template>
  <div
    ref="box"
    :style="{ ...styles.box, ...boxStyle, overflow: autoScale ? 'hidden' : 'auto' }"
    class="v-screen-box"
  >
    <div ref="screenWrapper" :style="{ ...styles.wrapper, ...wrapperStyle }" class="screen-wrapper">
      <slot />
    </div>
  </div>
</template>
<script lang="ts" setup>
  import { nextTick, onMounted, onUnmounted, reactive, ref, watch } from 'vue'
  import type { CSSProperties, PropType } from 'vue'
  import { debounce } from 'lodash-es'

  defineOptions({
    name: 'ScaleScreen',
  })

  interface IState {
    originalWidth: string | number
    originalHeight: string | number
    width?: string | number
    height?: string | number
    observer: null | MutationObserver
  }
  type IAutoScale =
    | boolean
    | {
        x?: boolean
        y?: boolean
      }

  const props = defineProps({
    width: {
      type: [String, Number] as PropType<string | number>,
      default: 1920,
    },
    height: {
      type: [String, Number] as PropType<string | number>,
      default: 1080,
    },
    fullScreen: {
      type: Boolean as PropType<boolean>,
      default: false,
    },
    autoScale: {
      type: [Object, Boolean] as PropType<IAutoScale>,
      default: true,
    },
    delay: {
      type: Number as PropType<number>,
      default: 500,
    },
    boxStyle: {
      type: Object as PropType<CSSProperties>,
      default: () => ({}),
    },
    wrapperStyle: {
      type: Object as PropType<CSSProperties>,
      default: () => ({}),
    },
  })

  const state = reactive<IState>({
    width: 0,
    height: 0,
    originalWidth: 0,
    originalHeight: 0,
    observer: null,
  })

  const styles: Record<string, CSSProperties> = {
    box: {
      overflow: 'hidden',
      backgroundSize: `100% 100%`,
      // background: `#000`,
      width: `100vw`,
      height: `100vh`,
    },
    wrapper: {
      transitionProperty: `all`,
      transitionTimingFunction: `cubic-bezier(0.4, 0, 0.2, 1)`,
      transitionDuration: `500ms`,
      position: `relative`,
      overflow: `hidden`,
      zIndex: 100,
      transformOrigin: `left top`,
    },
  }

  const screenWrapper = ref<HTMLElement>()
  const box = ref<HTMLElement>()

  watch(
    () => props.autoScale,
    async (newVal: any) => {
      if (newVal) {
        await onResize()
        addListener()
      } else {
        clearListener()
        clearScreenWrapperStyle()
      }
    },
  )
  /**
   * 初始化大屏容器宽高
   */
  const initSize = () => {
    return new Promise<void>(resolve => {
      box.value!.scrollLeft = 0
      box.value!.scrollTop = 0
      nextTick(() => {
        // region 获取大屏真实尺寸
        if (props.width && props.height) {
          state.width = props.width
          state.height = props.height
        } else {
          state.width = screenWrapper.value?.clientWidth
          state.height = screenWrapper.value?.clientHeight
        }
        // endregion

        // region 获取画布尺寸
        if (!state.originalHeight || !state.originalWidth) {
          state.originalWidth = window.screen.width
          state.originalHeight = window.screen.height
        }
        // endregion
        resolve()
      })
    })
  }

  /**
   * 更新大屏容器宽高
   */
  const updateSize = () => {
    if (state.width && state.height) {
      screenWrapper.value!.style.width = `${state.width}px`
      screenWrapper.value!.style.height = `${state.height}px`
    } else {
      screenWrapper.value!.style.width = `${state.originalWidth}px`
      screenWrapper.value!.style.height = `${state.originalHeight}px`
    }
  }
  const clearScreenWrapperStyle = () => {
    screenWrapper.value!.style.transform = ''
    screenWrapper.value!.style.margin = ''
  }
  const calcScale = (scale: number) => {
    if (!props.autoScale) {
      return
    }
    const domWidth = screenWrapper.value!.clientWidth
    const domHeight = screenWrapper.value!.clientHeight
    const currentWidth = document.body.clientWidth
    const currentHeight = document.body.clientHeight
    screenWrapper.value!.style.transform = `scale(${scale},${scale})`
    let mx = Math.max((currentWidth - domWidth * scale) / 2, 0)
    let my = Math.max((currentHeight - domHeight * scale) / 2, 0)
    if (typeof props.autoScale === 'object') {
      !props.autoScale.x && (mx = 0)
      !props.autoScale.y && (my = 0)
    }
    screenWrapper.value!.style.margin = `${my}px ${mx}px`
  }
  const updateScale = () => {
    // 获取真实视口尺寸
    const currentWidth = document.body.clientWidth
    const currentHeight = document.body.clientHeight
    // 获取大屏最终的宽高
    const realWidth = state.width || state.originalWidth
    const realHeight = state.height || state.originalHeight
    // 计算缩放比例
    const widthScale = currentWidth / +realWidth
    const heightScale = currentHeight / +realHeight
    // 若要铺满全屏，则按照各自比例缩放
    if (props.fullScreen) {
      screenWrapper.value!.style.transform = `scale(${widthScale},${heightScale})`
      return false
    }
    // 按照宽高最小比例进行缩放
    const scale = Math.min(widthScale, heightScale)
    calcScale(scale)
  }

  const onResize = debounce(async () => {
    await initSize()
    updateSize()
    updateScale()
  }, props.delay)
  const initMutationObserver = () => {
    const observer = (state.observer = new MutationObserver(() => {
      onResize()
    }))
    observer.observe(screenWrapper.value!, {
      attributes: true,
      attributeFilter: ['style'],
      attributeOldValue: true,
    })
  }

  const clearListener = () => {
    window.removeEventListener('resize', onResize)
    // state.observer?.disconnect();
  }

  const addListener = () => {
    window.addEventListener('resize', onResize)
    // initMutationObserver();
  }
  onMounted(() => {
    nextTick(async () => {
      await initSize()
      updateSize()
      updateScale()
      addListener()
      // initMutationObserver();
    })
  })
  onUnmounted(() => {
    clearListener()
    // state.observer?.disconnect();
  })
</script>
