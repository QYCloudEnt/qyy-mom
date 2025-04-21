<template>
  <DynamicTable
    :header-title="$t('routes.menu.sys.menu')"
    :data-request="loadTableData"
    :columns="columns"
  >
    <template #afterHeaderTitle>
      <div class="flex gap-2 ml-2">
        <a-button @click="dynamicTableInstance.expandAll">{{ t('common.expandAll') }}</a-button>
        <a-button @click="dynamicTableInstance.collapseAll">{{ t('common.collapseAll') }}</a-button>
      </div>
    </template>
    <template #toolbar>
      <a-button type="primary" @click="openMenuModal({})"> {{ $t('common.add') }} </a-button>
    </template>
  </DynamicTable>
</template>

<script setup lang="tsx">
  import { ref, getCurrentInstance } from 'vue'
  import { type TreeSelectProps, Tag, Badge } from 'ant-design-vue'
  import { useResizeObserver } from '@vueuse/core'
  import { useFormModal } from '@/hooks/useModal/useFormModal'
  import { formatMenu2Tree } from '@/utils/tree'
  import { cloneDeep } from 'lodash-es'
  import type { TableColumn } from '@/components/core/dynamic-table'
  import type { FormSchema } from '@/components/core/schema-form/src/types/form'
  import { IconPicker, Icon } from '@/components/basic/icon'
  import { useTable } from '@/components/core/dynamic-table'
  import action from '@/api/sys/menu'
  import { useI18n } from '@/hooks/useI18n'
  import { asyncRoutes } from '@/router/asyncModules'

  defineOptions({
    name: 'SysMenu',
  })
  const [DynamicTable, dynamicTableInstance] = useTable({
    pagination: false,
    size: 'small',
    rowKey: 'id',
    bordered: true,
    search: false,
    autoHeight: true,
  })

  const menuTree = ref<TreeSelectProps['treeData']>([])
  const menuData = ref<any[]>([])
  const existPerms = ref<string[]>([])
  const dynamicPerms = ref<string[]>([])
  const { t } = useI18n()

  const [showModal] = useFormModal()
  const currentInstance = getCurrentInstance()

  useResizeObserver(document.documentElement, () => {
    const el = currentInstance?.proxy?.$el as HTMLDivElement
    if (el) {
      dynamicTableInstance.setProps({
        scroll: { x: window.innerWidth > 2000 ? el.offsetWidth - 20 : 2000 },
      })
    }
  })

  const calcPerms = async () => {
    if (dynamicPerms.value.length) return dynamicPerms.value.map(n => ({ label: n, value: n }))
    existPerms.value = menuData.value.filter(x => x.type == 2).map(x => x.perms)
    const permList: any[] = await action.getPermsByReflection()
    dynamicPerms.value = permList.filter((x: string) => !existPerms.value.includes(x))
    return dynamicPerms.value.map(n => ({ label: n, value: n }))
  }

  const loadTableData = async () => {
    const data = await action.getMenuList()
    menuData.value = data
    menuTree.value = formatMenu2Tree(
      cloneDeep(data).filter(n => n.type !== 2 && n.isShow),
      null,
    )
    return formatMenu2Tree(cloneDeep(data), null)
  }

  const openMenuModal = async record => {
    const [formRef] = await showModal({
      modalProps: {
        title: `${record.id ? t('common.edit') : t('common.add')}`,
        width: 700,
        onFinish: async values => {
          values.id = record.id
          await (record.id ? action.update : action.add)(values)
          // 去除已选择的权限
          if (values.perms) {
            dynamicPerms.value = dynamicPerms.value.filter(x => x != values.perms)
          }
          dynamicTableInstance.reload()
        },
      },
      formProps: {
        labelWidth: 100,
        schemas: menuSchemas,
      },
    })

    formRef?.updateSchema([
      {
        field: 'parentId',
        componentProps: {
          treeDefaultExpandedKeys: [-1].concat(record?.keyPath || []),
          treeData: [{ key: -1, name: '一级菜单', children: menuTree.value }],
        },
      },
    ])

    formRef?.setFieldsValue({
      ...record,
      perms: record.perms,
      parentId: record.parentId ?? -1,
    })
  }
  const delRowConfirm = async record => {
    await action.delete(record.id)
    dynamicTableInstance.reload()
  }

  /**
   * 将对应菜单类型转为字符串字意
   */
  const getMenuType = type => {
    switch (type) {
      case 0:
        return '目录'
      case 1:
        return '菜单'
      case 2:
        return '权限'
      default:
        return ''
    }
  }

  // 列信息
  const columns: TableColumn<any>[] = [
    {
      title: 'id',
      dataIndex: 'id',
      align: 'center',
      hideInTable: true,
    },
    {
      title: '节点名称',
      dataIndex: 'name',
      align: 'center',
      width: 60,
    },
    {
      title: '图标',
      width: 40,
      dataIndex: 'icon',
      align: 'center',
      customRender: ({ record }) => record.icon && <Icon icon={record.icon} size="22" />,
    },
    {
      title: '类型',
      width: 40,
      align: 'center',
      dataIndex: 'type',
      customRender: ({ record }) => (
        <Tag color={['red', 'blue', 'cyan'][record.type]}>{getMenuType(record.type)}</Tag>
      ),
    },
    {
      title: '路由/权限(api)',
      dataIndex: 'router',
      align: 'center',
      i18n: `t('column.routerAuth')`,
      width: 80,
    },
    {
      title: '路由缓存',
      dataIndex: 'keepalive',
      align: 'center',
      width: 40,
      customRender: ({ record }) => (
        <Badge
          status={record.keepalive ? 'success' : 'default'}
          text={record.keepalive ? '是' : '否'}
        />
      ),
    },
    {
      title: '文件路径',
      width: 80,
      align: 'center',
      dataIndex: 'viewPath',
    },
    {
      title: '排序',
      width: 30,
      align: 'center',
      dataIndex: 'orderNum',
    },
    {
      title: '是否显示',
      width: 50,
      align: 'center',
      dataIndex: 'isShow',
      customRender: ({ record }) => (
        <Tag color={record.isShow ? 'cyan' : 'red'}>{record.isShow ? '显示' : '隐藏'}</Tag>
      ),
    },
    {
      title: '操作',
      width: 60,
      dataIndex: 'ACTION',
      hideInSearch: true,
      align: 'center',
      fixed: 'right',
      actions: ({ record }) => [
        {
          label: t('common.edit'),
          auth: {
            perm: '/api/SysMenu/Update',
            effect: 'disable',
          },
          onClick: () => openMenuModal(record),
        },
        {
          label: t('common.delete'),
          danger: true,
          auth: '/api/SysMenu/Delete',
          popConfirm: {
            title: t('column.confirmDel'),
            onConfirm: () => delRowConfirm(record),
          },
        },
      ],
    },
  ]

  const valiRouter = (_rule, val) => {
    if (!val) {
      return Promise.reject(`输入内容不能为空`)
    } else if (!/^\//.test(val)) {
      return Promise.reject(`格式应以 / 开头`)
    } else {
      return Promise.resolve()
    }
  }

  // 表单信息
  const menuSchemas: FormSchema[] = [
    {
      field: 'type',
      component: 'RadioGroup',
      label: '菜单类型',
      defaultValue: 0,
      rules: [{ required: true, type: 'number' }],
      componentProps: {
        options: [
          {
            label: '目录',
            value: 0,
          },
          {
            label: '菜单',
            value: 1,
          },
          {
            label: '权限',
            value: 2,
          },
        ],
      },
    },
    {
      field: 'name',
      component: 'Input',
      label: '节点名称',
      rules: [{ required: true, type: 'string' }],
    },
    {
      field: 'parentId',
      component: 'TreeSelect',
      label: '上级节点',
      i18n: `t('column.parentNode')`,
      // vIf: ({ formModel }) => formModel['type'] !== 0,
      componentProps: {
        fieldNames: {
          label: 'name',
          value: 'key',
        },
        getPopupContainer: () => document.body,
      },
      rules: [{ required: true, type: 'number' }],
    },
    {
      field: 'router',
      component: 'Input',
      label: '节点路由',
      vIf: ({ formModel }) => formModel['type'] === 0,
      rules: [
        {
          required: true,
          validator: async (_, value) => {
            if (!value) {
              return Promise.reject('节点路由不能为空')
            }
            if (!/^\/[a-zA-Z]+$/.test(value)) {
              return Promise.reject('路由格式以`/`开头, eg: /sys')
            }
            return Promise.resolve()
          },
          trigger: 'change',
        },
      ],
    },
    {
      field: 'perms',
      component: 'Select',
      // component: shallowRef(MultipleCascader),
      label: 'api权限',
      vIf: ({ formModel }) => formModel['type'] === 2,
      rules: [{ required: true, type: 'string', message: '请选择api权限' }],
      componentProps: {
        showSearch: true,
        request: async () => await calcPerms(),
      },
    },
    {
      field: 'icon',
      component: () => IconPicker,
      label: '节点图标',
      required: ({ formModel }) => formModel['isShow'],
      vIf: ({ formModel }) => formModel['type'] !== 2,
    },
    {
      field: 'viewPath',
      component: 'Select',
      label: '节点路径',
      rules: [{ required: true, type: 'string' }],
      vIf: ({ formModel }) => formModel['type'] === 1 && !formModel['isExternal'],
      componentProps: {
        showSearch: true,
        options: Object.keys(asyncRoutes).map(n => ({ label: n, value: n })),
      },
    },
    {
      field: 'keepalive',
      component: 'Switch',
      label: '是否缓存',
      defaultValue: false,
      vIf: ({ formModel }) => formModel['type'] === 1,
    },
    {
      field: 'isExternal',
      component: 'Switch',
      label: '是否外链',
      defaultValue: false,
      vIf: ({ formModel }) => formModel['type'] === 1,
    },
    {
      field: 'isEmbed',
      component: 'Switch',
      label: '是否内嵌',
      defaultValue: false,
      vIf: ({ formModel }) => formModel['type'] === 1 && formModel['isExternal'],
    },
    {
      field: 'externalRouteName',
      component: 'Input',
      label: '节点路由',
      vIf: ({ formModel }) => formModel['type'] === 1 && formModel['isExternal'],
      rules: [
        {
          required: true,
          validator: async (_, value) => {
            if (!value) {
              return Promise.reject('节点路由不能为空')
            }
            if (!/^\/iframe\/[a-zA-Z0-9/]+$/.test(value)) {
              return Promise.reject('路由格式以`/iframe/`开头, eg: /iframe/doc')
            }
            return Promise.resolve()
          },
          trigger: 'change',
        },
      ],
    },
    {
      field: 'externalUrl',
      component: 'Input',
      label: '外链地址',
      vIf: ({ formModel }) => formModel['type'] === 1 && formModel['isExternal'],
      rules: [{ required: true, type: 'string' }],
    },
    {
      field: 'isShow',
      component: 'Switch',
      label: '是否显示',
      defaultValue: true,
      vIf: ({ formModel }) => formModel['type'] !== 2,
    },
    {
      field: 'orderNum',
      component: 'InputNumber',
      label: '排序号',
      defaultValue: 0,
      vIf: ({ formModel }) => formModel['type'] !== 2,
      componentProps: {
        style: {
          width: '100%',
        },
      },
    },
  ]
</script>
