<template>
  <div style="max-width: 500px; margin: 40px auto 0; text-align: center">
    <result :title="result?.msg" :success="result?.success" :description="result?.data" />
    <Button type="primary" @click="doOnceAgin">再来一次</Button>
  </div>
</template>

<script lang="ts">
  import { defineComponent } from 'vue'
  import { Button } from 'ant-design-vue'
  import Result from '@/components/basic/result/Result.vue'
  export default defineComponent({
    name: 'Step3',
    // eslint-disable-next-line vue/no-reserved-component-names
    components: { Result, Button },
    props: {
      result: {
        type: Object,
        default: () => {},
      },
    },
    emits: ['finish'],
    setup(_, { emit }) {
      const doOnceAgin = () => emit('finish')
      return {
        doOnceAgin,
      }
    },
  })
</script>

<style scoped></style>
