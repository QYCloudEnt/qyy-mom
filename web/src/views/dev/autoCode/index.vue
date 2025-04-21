<template>
  <Spin :spinning="loading">
    <Card :bordered="false">
      <Steps class="steps" :current="current">
        <Step :title="$t('routes.dev.inputAutoCode')" />
        <Step :title="$t('routes.dev.confirm')" />
        <Step :title="$t('routes.dev.complete')" />
      </Steps>
      <div class="content">
        <step1
          v-if="current === 0"
          :form-data="formData"
          :menu-parent-name="parentName"
          @next-step="nextStep"
        />
        <step2
          v-if="current === 1"
          :form="formData"
          :vue-temp-arr="vueTempArr"
          :parent-name="parentName"
          @next-step="nextStep"
          @prev-step="prevStep"
        />
        <step3 v-if="current === 2" :result="res" @prev-step="prevStep" @finish="finish" />
      </div>
    </Card>
  </Spin>
</template>

<script lang="ts">
  import { ref, defineComponent } from 'vue'
  import { Card, Steps, Spin } from 'ant-design-vue'
  import Step1 from './Step1.vue'
  import Step2 from './Step2.vue'
  import Step3 from './Step3.vue'
  import action from '@/api/codeFirst'

  export default defineComponent({
    name: 'AutoCode',
    components: {
      Card,
      Spin,
      Steps,
      Step: Steps.Step,
      Step1,
      Step2,
      Step3,
    },
    setup() {
      const loading = ref<boolean>(false)
      const current = ref(0)
      const formData = ref({})
      const vueTempArr = ref([])
      const parentName = ref('')
      const res = ref({})

      const nextStep = async (data, arr, menuParentName) => {
        loading.value = true
        vueTempArr.value = arr
        formData.value = data
        parentName.value = menuParentName
        if (current.value === 1) {
          await action
            .createFiles(formData.value)
            .then(r => {
              res.value = r
              current.value += 1
            })
            .finally(() => (loading.value = false))
        }
        if (current.value < 2) {
          current.value += 1
        }
        loading.value = false
      }
      const prevStep = (form, menuParentName) => {
        formData.value = form
        parentName.value = menuParentName
        if (current.value > 0) {
          current.value -= 1
        }
      }
      const finish = () => {
        current.value = 0
      }

      return {
        loading,
        current,
        formData,
        vueTempArr,
        parentName,
        res,
        nextStep,
        prevStep,
        finish,
      }
    },
  })
</script>

<style lang="less" scoped>
  .steps {
    max-width: 950px;
    margin: 16px auto;
  }
</style>
