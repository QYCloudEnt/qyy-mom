<template>
  <span class="thumb">
    <Image v-if="fileUrl" :src="fullUrl" :width="104" />
  </span>
</template>
<script lang="ts" setup>
  import { Image } from 'ant-design-vue'

  const props = defineProps({
    fileUrl: {
      type: String,
      default: '',
    },
    fileName: {
      type: String,
      default: '',
    },
  })
  const fullUrl = props.fileUrl?.startsWith('data:image')
    ? props.fileUrl
    : `${import.meta.env.VITE_BASE_STATIC_URL}${props.fileUrl}`
</script>
<style lang="less" scoped>
  .thumb {
    img {
      display: block;
      position: static;
      border-radius: 4px;
      cursor: zoom-in;
      object-fit: cover;
    }
  }
</style>
