<template>
  <Card :border="false">
    <div>
      <Alert
        :closable="true"
        message="数据库表结构修改, 请谨慎操作!"
        style="width: 600px; margin: 0 auto 24px; text-align: center"
        type="success"
        show-icon
      />
      <SchemaForm
        ref="dynamicForm"
        :show-action-button-group="false"
        :schemas="schemas"
        label-width="120px"
        style="max-width: 500px; margin: 40px auto 0"
      />
      <div style="text-align: center">
        <Button
          type="primary"
          :disabled="!$auth('/api/CodeFirst/DbMigration') || !isSuperAdmin"
          @click="handleOk"
        >
          {{ $t('common.okText') }}
        </Button>
      </div>
    </div>
  </Card>
</template>

<script lang="ts" setup>
  import { ref, computed } from 'vue'
  import { Card, Button, Alert } from 'ant-design-vue'
  import { SchemaForm } from '@/components/core/schema-form'
  import type { FormSchema } from '@/components/core/schema-form/src/types/form'
  import { useModal } from '@/hooks/useModal'
  import { useUserStore } from '@/store/modules/user'
  import action from '@/api/codeFirst/index'

  defineOptions({
    name: 'DbMigration',
  })

  const dynamicForm = ref<InstanceType<typeof SchemaForm>>()
  const [conFirmModal] = useModal()
  const userStore = useUserStore()
  const loading = ref(false)

  const isSuperAdmin = computed(() => userStore.userInfo.isSuper)

  const handleOk = async () => {
    loading.value = true
    try {
      await dynamicForm.value?.validate()
      const tableNames: string = dynamicForm.value?.formModel?.tableNames
      const data = {
        tblNames: tableNames.split(','),
      }
      conFirmModal.show({
        title: '提示',
        content: `确定修改以下表结构吗？${tableNames}`,
        onOk: async () => {
          await action.dbMigration(data)
          await dynamicForm.value?.resetFields()
          loading.value = false
        },
      })
    } catch {
      loading.value = false
    }
  }

  const schemas: FormSchema[] = [
    {
      field: 'tableNames',
      component: 'InputTextArea',
      label: '表实体类名',
      i18n: `t('column.tableEntityNames')`,
      helpMessage: '多个请以逗号隔开',
      required: true,
    },
  ]
</script>
