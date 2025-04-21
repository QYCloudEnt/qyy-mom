<template>
  <div class="result">
    <div v-if="props.title" class="title" :class="props.success ? 'success' : 'error'">
      {{ props.title }}
    </div>
    <div v-if="props.description" class="desc" v-html="props.description"></div>
    <div class="content">
      <slot></slot>
    </div>
    <div class="action">
      <slot name="action"></slot>
    </div>
  </div>
</template>

<script lang="ts" setup>
  import { defineProps } from 'vue'
  const props = defineProps({
    success: {
      type: Boolean,
      default: false,
    },
    title: {
      type: String,
      default: '',
    },
    description: {
      type: String,
      default: '',
    },
  })
</script>

<style lang="less" scoped>
  .result {
    width: 72%;
    margin: 0 auto;
    text-align: center;

    .icon {
      margin-bottom: 24px;
      font-size: 72px;
      line-height: 72px;
    }

    .success {
      color: var(--app-primary-color);
    }

    .error {
      color: '#f5222d';
    }

    .title {
      margin-bottom: 16px;
      font-size: 18px;
      font-weight: 500;
      line-height: 32px;
    }

    .desc {
      margin-bottom: 24px;
      font-size: 16px;
      line-height: 30px;
    }
    // .content {
    //   // background-color: @background-color-light;
    //   padding: 24px 40px;
    //   border-radius: 2px;
    //   text-align: left;
    // }
    .action {
      margin-top: 32px;
    }
  }
</style>
