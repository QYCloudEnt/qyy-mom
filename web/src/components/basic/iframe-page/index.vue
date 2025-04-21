<template>
  <div :style="getWrapStyle">
    <Spin :spinning="loading" size="large">
      <iframe
        ref="frameRef"
        class="wh-full iframe_main"
        v-bind="$attrs"
        :src="frameSrc"
        @load="onFrameLoad"
      />
    </Spin>
  </div>
</template>
<script lang="ts" setup>
  import { computed, ref, unref } from 'vue'
  import type { CSSProperties } from 'vue'
  import { Spin } from 'ant-design-vue'
  import { useRoute } from 'vue-router'
  import { useWindowSizeFn } from '@/hooks/useWindowSizeFn'
  import { Storage } from '@/utils/Storage'
  import { ACCESS_TOKEN_KEY } from '@/enums/cacheEnum'
  import { useUserStore } from '@/store/modules/user'
  import { isHttpUrl } from '@/utils/is'
  import { setObjToUrlParams, uniqueSlash } from '@/utils/urlUtils'

  defineOptions({
    name: 'IFramePage',
  })

  const props = defineProps({
    src: {
      type: String,
      required: true,
    },
  })

  const loading = ref(true)
  const topRef = ref(50)
  const frameRef = ref<HTMLIFrameElement>()
  const heightRef = ref(window.innerHeight)
  const httpOrigin = ref(window.location.origin)
  // 当前路由
  const currentRoute = useRoute()
  const userStore = useUserStore()

  // 兼容报表路由
  const getUrl = () => {
    const src = props.src.replace(/^\//, '')
    let url = ''
    const defaultParams = `sso=${userStore.getToken}&exp=${Storage.getExpire(ACCESS_TOKEN_KEY)}`
    const isAnyParams = src.indexOf('?') !== -1
    const sufix = isAnyParams ? '&' : '?'
    if (isHttpUrl(src)) {
      url = uniqueSlash(`${src}${sufix}${defaultParams}`)
    } else {
      url = uniqueSlash(`${httpOrigin.value}${currentRoute.meta.frameSrc}`)
    }
    return setObjToUrlParams(url, currentRoute.params)
  }

  const frameSrc = getUrl()

  useWindowSizeFn(calcHeight, 150, { immediate: true })

  // onMounted(() => console.log(frameRef.value))

  const getWrapStyle = computed((): CSSProperties => {
    return {
      height: `${unref(heightRef)}px`,
    }
  })


  function calcHeight() {
    const iframe = unref(frameRef)
    if (!iframe) {
      return
    }
    const top = 70
    topRef.value = top
    heightRef.value = window.innerHeight - top
    const clientHeight = document.documentElement.clientHeight - top
    iframe.style.height = `${clientHeight}px`

  }

  const onFrameLoad = () => {
    loading.value = false
    calcHeight()
  }
</script>
<style lang="less" scoped>
  .iframe-box {
    transform: translate(0);
  }

  .iframe_main {
    box-sizing: border-box;
    width: 100%;
    height: 100%;
    overflow: hidden;
    // background-color: @component-background;
    border: 0;
  }
</style>
