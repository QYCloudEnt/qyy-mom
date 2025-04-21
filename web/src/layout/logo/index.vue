<template>
  <div class="logo">
    <img src="~@/assets/images/logo.png" alt="" />
    <h2 v-show="!collapsed" class="title">TMom</h2>
  </div>
</template>

<script setup>
  defineProps({
    collapsed: {
      type: Boolean,
    },
  })
</script>

<style lang="less" scoped>
  .logo {
    @apply flex overflow-hidden whitespace-nowrap items-center;

    height: 64px;
    padding-left: 15px;
    line-height: 64px;
    filter: drop-shadow(2px 2px 6px var(--color));

    img {
      height: 45px;
      margin-right: 8px;
    }

    .title {
      @apply mb-0 text-xl;

      background: url('/src/assets/images/logo-bj.gif') 50% 50%;
      /* stylelint-disable-next-line property-no-vendor-prefix */
      -webkit-background-clip: text; /* 将背景图像剪切到文本形状 */
      background-clip: text; /* 将背景图像剪切到文本形状 */
      background-size: cover; /* 背景的尺寸 */
      color: #ddd; //@success-color;
      font-family: fantasy;
      font-weight: bold;
      -webkit-text-fill-color: transparent;
    }
  }
</style>
