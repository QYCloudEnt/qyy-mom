<template>
  <ACol class="ant-col-xs-24 ant-col-sm-12 ant-col-md-8">
    <div class="label">{{ label }}</div>
    <div class="content">
      <slot></slot>
    </div>
  </ACol>
</template>
<script lang="ts">
  import { defineComponent } from 'vue'
  import ACol from 'ant-design-vue/es/grid/Col'
  export default defineComponent({
    name: 'DetailItem',
    components: { ACol },
    props: {
      label: {
        type: String,
      },
    },
    setup() {},
  })
</script>

<style lang="less"></style>
