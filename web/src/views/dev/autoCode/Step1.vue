<template>
  <div>
    <Alert
      v-if="!isProdMode"
      :closable="true"
      :message="msg"
      style="width: 600px; margin: 0 auto 24px; text-align: center"
      type="success"
      show-icon
    />
    <Alert
      v-else
      :closable="true"
      message="当前非开发环境, 不允许代码生成!"
      style="width: 600px; margin: 0 auto 24px; text-align: center"
      type="error"
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
      <Button type="primary" :disabled="isProdMode" @click="nextStep">
        {{ $t('routes.dev.nextStep') }}
      </Button>
    </div>
  </div>
</template>

<script lang="ts" setup>
  import { Alert, type TreeSelectProps, Button } from 'ant-design-vue'
  import { ref, defineEmits, defineProps, onMounted } from 'vue'
  import { SchemaForm } from '@/components/core/schema-form'
  import type { FormSchema } from '@/components/core/schema-form/src/types/form'
  import { formatMenu2Tree } from '@/utils/tree'
  import { IconPicker } from '@/components/basic/icon'
  import { cloneDeep } from 'lodash-es'
  import action from '@/api/codeFirst'
  import menuAction from '@/api/sys/menu'
  import { isProdMode } from '@/constants/env'

  defineOptions({
    name: 'Step1',
  })

  const props = defineProps({
    formData: Object as any,
    menuParentName: String || undefined,
  })
  const emit = defineEmits(['nextStep'])
  const menuTree = ref<TreeSelectProps['treeData']>([])
  const dynamicForm = ref<InstanceType<typeof SchemaForm>>()
  const vueTempArr = ref<any[]>([
    {
      label: '查询表格',
      value: 'searchTable',
    },
  ])
  const menuList = ref<any>([])

  const loadMenuData = async () => {
    const data = await menuAction.getMenuList()
    menuList.value = data
    menuTree.value = formatMenu2Tree(
      cloneDeep(data).filter(n => n.type !== 2 && n.isShow),
      null,
    )
    return [{ key: -1, name: '一级菜单', children: menuTree.value }]
  }

  const msg = ref('')
  const parentName = ref('')
  const getPath = async () => {
    const data = await action.getVuePath()
    msg.value = `生成前请先创建表的实体类! 当前vue生成路径: ${data}, 请检查是否正确!`
  }
  getPath()

  onMounted(() => {
    if (props.formData && dynamicForm.value) {
      parentName.value = props.menuParentName || ''
      dynamicForm.value?.setFieldsValue({ ...props.formData })
    }
  })

  const saveParentName = e => {
    parentName.value = menuList.value?.filter(x => x.id === e)[0]?.name
  }
  const nextStep = async () => {
    await dynamicForm.value?.validate()
    emit('nextStep', dynamicForm.value?.formModel, vueTempArr.value, parentName.value)
  }

  /**
   * 表单
   */
  const schemas: FormSchema[] = [
    {
      field: 'fileName',
      component: 'Input',
      label: '文件夹名称',
      required: true,
    },
    {
      field: 'createVue',
      component: 'Select',
      label: '生成Vue页面',
      componentProps: {
        options: [
          {
            label: '是',
            value: 1,
          },
          {
            label: '否',
            value: 0,
          },
        ],
      },
      required: true,
    },
    {
      field: 'vueTemplate',
      component: 'Select',
      label: '页面模板',
      componentProps: {
        options: vueTempArr.value,
      },
      vIf: ({ formModel }) => formModel['createVue'] === 1,
      required: true,
    },
    {
      field: 'menuName',
      component: 'Input',
      label: '菜单名称',
      vIf: ({ formModel }) => formModel['createVue'] === 1,
      required: true,
    },
    {
      field: 'parentId',
      component: 'TreeSelect',
      label: '上级菜单',
      i18n: `t('column.parentMenu')`,
      vIf: ({ formModel }) => formModel['createVue'] === 1,
      componentProps: {
        fieldNames: {
          label: 'name',
          value: 'key',
        },
        treeDefaultExpandedKeys: [-1],
        onChange: e => saveParentName(e),
        request: async () => await loadMenuData(),
      },
      rules: [
        {
          required: true,
          type: 'number',
          trigger: 'change',
          validator: async (_, value) => {
            if (!value) {
              return Promise.reject('请选择上级菜单')
            }
            if (value === -1) {
              return Promise.reject('不能选择一级菜单')
            }
            return Promise.resolve()
          },
        },
      ],
    },
    {
      field: 'icon',
      component: () => IconPicker,
      label: '菜单图标',
      componentProps: {
        placeholder: '请选择菜单图标',
      },
      rules: [{ required: true, type: 'string', message: '请选择菜单图标', trigger: 'change' }],
      vIf: ({ formModel }) => formModel['createVue'] === 1,
    },
    {
      field: 'tableNames',
      component: 'InputTextArea',
      label: '表实体类名称',
      i18n: `t('column.tableEntityNames')`,
      componentProps: {
        placeholder: '多个以 , 分隔',
      },
      required: true,
    },
  ]
  // const formProps: SchemaFormProps = { schemas, labelWidth: 120 }
</script>

<style scoped lang="less">
  .btn-rows {
    text-align: center;
  }
</style>
