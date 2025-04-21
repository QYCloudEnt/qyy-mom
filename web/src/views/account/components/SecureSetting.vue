<template>
  <Spin :spinning="loading">
    <div style="max-width: 500px">
      <SchemaForm
        ref="dynamicForm"
        :schemas="schemas"
        :label-width="120"
        :show-action-button-group="false"
      />
      <div style="text-align: center">
        <Button type="primary" @click="onSubmit()">{{ $t('column.confirmUpdate') }}</Button>
      </div>
    </div>
  </Spin>
</template>
<script lang="ts" setup>
  import { ref, computed } from 'vue'
  import { message, Spin, Button } from 'ant-design-vue'
  import { SchemaForm } from '@/components/core/schema-form'
  import type { FormSchema } from '@/components/core/schema-form/src/types/form'
  import { useUserStore } from '@/store/modules/user'
  import { useRouter, useRoute } from 'vue-router'
  import { LOGIN_NAME } from '@/router/constant'
  import action from '@/api/sys/user'

  const dynamicForm = ref<InstanceType<typeof SchemaForm>>()
  const userStore = useUserStore()
  const userInfo = computed(() => userStore.userInfo)
  const router = useRouter()
  const route = useRoute()
  const loading = ref(false)

  const onSubmit = async () => {
    await dynamicForm.value?.validate()
    loading.value = true
    const value = dynamicForm.value?.formModel as Array<string>
    await action
      .editPwd(userInfo.value.id!, value['newPwd'], value['oldPwd'])
      .then(res => {
        if (res.success) {
          message.success('即将跳转到登录页, 请重新登录!', 3)
          setTimeout(async () => {
            await userStore.logout()
            router.replace({
              name: LOGIN_NAME,
              query: {
                redirect: route.fullPath,
              },
            })
          }, 3000)
        }
      })
      .finally(() => (loading.value = false))
  }

  /**
   * 表单
   */
  const schemas: FormSchema[] = [
    {
      field: 'oldPwd',
      component: 'InputPassword',
      label: '旧密码',
      defaultValue: '',
      required: true,
    },
    {
      field: 'newPwd',
      component: 'InputPassword',
      label: '新密码',
      defaultValue: '',
      rules: [
        {
          required: true,
          validator: async (_, value) => {
            if (!value) {
              return Promise.reject('请输入新密码!')
            }
            if (value == dynamicForm.value?.formModel['oldPwd']) {
              return Promise.reject('新密码不能和旧密码相同!')
            }
            return Promise.resolve()
          },
          trigger: 'change',
        },
      ],
    },
    {
      field: 'confirmPwd',
      component: 'InputPassword',
      label: '确认密码',
      rules: [
        {
          required: true,
          validator: async (_, value) => {
            if (!value) {
              return Promise.reject('请输入确认密码!')
            }
            if (value != dynamicForm.value?.formModel['newPwd']) {
              return Promise.reject('两次输入的密码不一致!')
            }
            return Promise.resolve()
          },
          trigger: 'change',
        },
      ],
    },
  ]
  // const formSchema = { schemas, labelWidth: 120 }
</script>
