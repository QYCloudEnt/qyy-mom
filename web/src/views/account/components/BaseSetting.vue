<template>
  <Spin :spinning="loading">
    <div style="min-width: 500px">
      <Row :gutter="24">
        <Col :span="9">
          <SchemaForm
            ref="dynamicForm"
            :schemas="schemas"
            :label-width="120"
            :show-action-button-group="false"
          />
          <div style="text-align: center">
            <Button type="primary" @click="onSubmit()">{{ $t('column.confirmUpdate') }}</Button>
          </div>
        </Col>
        <Col :span="15" class="flex items-center flex-col justify-center" style="display: flex">
          <CropperAvatar
            :btn-text="$t('column.changeAvatar')"
            width="200"
            :value="avatar"
            :upload-api="action.uploadAvatar"
            @change="updateAvatar"
          />
        </Col>
      </Row>
    </div>
  </Spin>
</template>
<script lang="ts" setup>
  import { ref, onMounted, computed } from 'vue'
  import { Row, Col, Spin, Button } from 'ant-design-vue'
  import { CropperAvatar } from '@/components/basic/cropper'
  import { SchemaForm } from '@/components/core/schema-form'
  import type { FormSchema } from '@/components/core/schema-form/src/types/form'
  import { useUserStore } from '@/store/modules/user'
  import { isEmail, isPhone } from '@/utils/validate'
  import action from '@/api/sys/user'

  const userStore = useUserStore()
  const dynamicForm = ref<InstanceType<typeof SchemaForm>>()
  const userInfo = computed(() => userStore.userInfo)
  const loading = ref(false)

  onMounted(() => {
    dynamicForm.value?.setFieldsValue(userInfo.value)
  })

  const avatar = computed(() => {
    return userInfo.value.avatar
      ? `${import.meta.env.VITE_BASE_STATIC_URL}${userInfo.value.avatar}`
      : ''
  })

  /**
   * 上传成功后事件
   * @param src: base64 img格式
   * @param data: 接口返回的data
   */
  const updateAvatar = (_: string, data: any) => {
    userInfo.value.avatar = data
  }

  const onSubmit = async () => {
    loading.value = true
    await dynamicForm.value?.validate()
    const values = dynamicForm.value?.formModel!
    values.id = userInfo.value.id
    await action.updateBaseInfo(values).finally(() => {
      loading.value = false
      userStore.setUserInfo(values)
    })
  }

  /**
   * 表单
   */
  const schemas: FormSchema[] = [
    {
      field: 'realName',
      component: 'Input',
      label: '昵称',
    },
    {
      field: 'phoneNo',
      component: 'Input',
      label: '手机号',
      rules: [
        {
          required: false,
          validator: async (_, value) => {
            if (value && !isPhone(value)) {
              return Promise.reject('请输入正确的手机号!')
            }
            return Promise.resolve()
          },
          trigger: 'change',
        },
      ],
    },
    {
      field: 'email',
      component: 'Input',
      label: '邮箱',
      rules: [
        {
          required: false,
          validator: async (_, value) => {
            if (value && !isEmail(value)) {
              return Promise.reject('请输入正确的邮箱!')
            }
            return Promise.resolve()
          },
          trigger: 'change',
        },
      ],
    },
    {
      field: 'addr',
      component: 'InputTextArea',
      label: '地址',
    },
    {
      field: 'remark',
      component: 'InputTextArea',
      label: '个人简介',
    },
  ]
</script>
