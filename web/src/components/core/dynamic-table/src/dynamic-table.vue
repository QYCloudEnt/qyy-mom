<template>
  <div>
    <Teleport to="body" :disabled="!isFullscreen">
      <div ref="containerElRef" :style="getStyle">
        <SchemaForm
          v-if="getProps.search"
          ref="searchFormRef"
          class="bg-white dark:bg-black mb-16px !pt-24px pr-24px"
          :class="{ 'mom-ml5': isVerticalScreen() }"
          submit-on-reset
          v-bind="getFormProps"
          :table-instance="dynamicTableContext"
          @toggle-advanced="e => $emit('toggle-advanced', e)"
          @submit="handleSubmit"
        >
          <template v-for="item of getFormSlotKeys" #[replaceFormSlotKey(item)]="data">
            <slot :name="item" v-bind="data || {}" />
          </template>
        </SchemaForm>
        <!-- form和table中间内容 start -->
        <div v-if="$slots.headerContent" class="bg-white dark:bg-black">
          <Spin :spinning="getBindValues.loading" class="w-full">
            <slot name="headerContent" />
          </Spin>
        </div>
        <!-- form和table中间内容 end -->
        <div class="bg-white dark:bg-black">
          <ToolBar
            v-if="showToolBar"
            id="mom-dynamic-toolbar"
            :export-file-name="exportFileName"
            :title="headerTitle"
            :title-tooltip="titleTooltip"
            :show-table-setting="showTableSetting"
          >
            <template v-for="name of Object.keys($slots)" #[name]="data">
              <slot :name="name" v-bind="data || {}" />
            </template>
          </ToolBar>
          <SchemaForm
            ref="editTableFormRef"
            no-style
            :initial-values="editFormModel"
            :show-action-button-group="false"
            :show-advanced-button="false"
            @validate="handleEditFormValidate"
          >
            <Table
              v-if="showTable"
              ref="tableRef"
              v-bind="tableProps"
              :columns="innerColumns"
              :data-source="tableData"
              @change="handleTableChange"
              @resize-column="handleResizeColumn"
            >
              <template v-for="(_, slotName) of $slots" #[slotName]="slotData" :key="slotName">
                <slot :name="slotName" v-bind="slotData" />
              </template>
              <template #bodyCell="slotData">
                <slot name="bodyCell" v-bind="slotData" />
              </template>
            </Table>
          </SchemaForm>
        </div>
      </div>
    </Teleport>
  </div>
</template>

<script lang="tsx" setup>
  import { useSlots, computed, onBeforeMount } from 'vue'
  import { Table, Spin } from 'ant-design-vue'
  import {
    useTableMethods,
    createTableContext,
    useExportData2Excel,
    useTableForm,
    useTableState,
    useColumns,
    useEditable,
  } from './hooks'
  import { ToolBar } from './components'
  import { dynamicTableProps, dynamicTableEmits } from './dynamic-table'
  import type { DynamicTableType } from './types'
  import { SchemaForm } from '@/components/core/schema-form'
  import { isVerticalScreen } from '@/utils/validate'

  defineOptions({
    name: 'DynamicTable',
    inheritAttrs: false,
  })

  const props = defineProps(dynamicTableProps)
  const emit = defineEmits(dynamicTableEmits)
  const slots = useSlots()

  // 表格内部状态
  const tableState = useTableState({ props, slots })
  const {
    tableRef,
    tableData,
    isFullscreen,
    containerElRef,
    searchFormRef,
    editTableFormRef,
    getProps,
    getBindValues,
    editFormModel,
  } = tableState

  const getStyle = computed(() => getProps.value.style || {})

  // 创建表格上下文
  const dynamicTableContext = { props, emit, slots, ...tableState } as DynamicTableType
  createTableContext(dynamicTableContext)

  // 表格内部方法
  const tableMethods = useTableMethods()
  Object.assign(dynamicTableContext, tableMethods)
  const { fetchData, handleSubmit, handleTableChange, handleEditFormValidate, handleResizeColumn } =
    tableMethods
  // 控制编辑行
  const editableHooks = useEditable()
  Object.assign(dynamicTableContext, editableHooks)

  // 表格列的配置描述
  const { innerColumns } = useColumns()

  // 搜索表单
  const tableForm = useTableForm()
  const { getFormProps, replaceFormSlotKey, getFormSlotKeys } = tableForm

  // 表单导出
  const exportData2ExcelHooks = useExportData2Excel()

  // 当前组件所有的状态和方法
  Object.assign(dynamicTableContext, {
    ...props,
    ...tableState,
    ...tableForm,
    ...tableMethods,
    ...editableHooks,
    ...exportData2ExcelHooks,
    emit,
  })

  defineExpose(dynamicTableContext)

  onBeforeMount(() => props.initFetch && fetchData())

  const tableProps = computed<Recordable>(() => {
    const { getExpandOption } = tableMethods
    return {
      ...getBindValues.value,
      ...getExpandOption.value,
    }
  })
</script>

<style lang="less" scoped>
  :deep(.ant-table-wrapper) {
    padding: 0 6px 6px;

    .ant-table {
      .ant-table-title {
        display: flex;
      }

      .ant-image:hover {
        cursor: zoom-in;
      }
    }
  }

  .actions > * {
    margin-right: 10px;
  }

  .mom-ml5 {
    margin-left: 5rem;
  }
</style>
