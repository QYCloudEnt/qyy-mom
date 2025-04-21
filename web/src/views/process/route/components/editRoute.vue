<template>
  <div class="relative">
    <DraggableModal
      v-model:open="show"
      :keyboard="false"
      :top="50"
      width="90%"
      :title="`流程设计-${name}`"
      @ok="handleDesignSave"
      @cancel="handleDesignCancel"
    >
      <AntdX6>
        <template #left>
          <Spin :spinning="listLoading">
            <Input.Search
              v-model:value="key"
              placeholder="请输入工序名称"
              @search="getCateList(key)"
            />
            <list :data-source="categoryList" class="overflow-y-scroll h-73vh operation_list">
              <template #renderItem="{ item }">
                <BadgeRibbon
                  :text="item.extendCol"
                  :color="getTagColor(item.extendCol)"
                  class="mr-2"
                >
                  <List.Item class="flex !justify-center">
                    <TypographyText
                      class="text-center cursor-move"
                      :draggable="true"
                      :style="ellipsis ? { width: `150px` } : {}"
                      :ellipsis="ellipsis ? { tooltip: `(${item.code})${item.name}` } : false"
                      :content="`(${item.code})${item.name}`"
                      @mousedown="e => onDragstart(e, item)"
                    />
                  </List.Item>
                </BadgeRibbon>
              </template>
            </list>
          </Spin>
        </template>
        <template #center>
          <div ref="x6Ref" />
        </template>
        <template #right>
          <Spin :spinning="listLoading">
            <Tabs
              v-if="+currentClickCell.id > 0 && currentClickCell.type === 'Node'"
              v-model:activeKey="activeKey"
              :tab-bar-gutter="50"
              centered
            >
              <TabPane key="base" tab="基础信息">
                <BaseConfig
                  :route-id="id"
                  :routes
                  :operations="selectedOperations"
                  :option-data="formList?.base!"
                />
              </TabPane>
              <TabPane key="test" tab="测试相关">
                <TestConfig :option-data="formList?.test!" />
              </TabPane>
              <TabPane key="quality" tab="质量相关" />
            </Tabs>
            <Empty v-else :image="Empty.PRESENTED_IMAGE_SIMPLE" />
          </Spin>
        </template>
        <template #bottom-left>
          <div class="absolute left-6 bottom-6 text-red-500 font-bold">
            提示: [Ctrl + 鼠标滚轮] 放大/缩放
          </div>
        </template>
      </AntdX6>
    </DraggableModal>
  </div>
</template>
<script setup lang="ts">
  import { ref, reactive, watch, watchEffect } from 'vue'
  import {
    Spin,
    Input,
    List,
    Tabs,
    TabPane,
    TypographyText,
    Empty,
    BadgeRibbon,
  } from 'ant-design-vue'
  import { DraggableModal } from '@/components/core/draggable-modal'
  import { AntdX6 } from '@/components/basic/antd-x6'
  import { Graph } from '@antv/x6'
  import type { Dnd } from '@antv/x6-plugin-dnd'
  import type { ConfigParamType, ProcessItemType } from './type.d'
  import { registerCustomNode, useX6 } from '@/hooks/useX6'
  import BaseConfig from './baseConfig.vue'
  import TestConfig from './testConfig.vue'
  import action from '@/api/process/route'
  import { getTagColor } from '@/enums/commonEnum'

  defineOptions({
    name: 'EditRoute',
  })
  const props = defineProps({
    showDesign: {
      type: Boolean,
      default: false,
    },
    /** 工艺路线id */
    id: {
      type: Number,
      default: 0,
    },
    name: {
      type: String,
      default: '',
    },
  })
  const emit = defineEmits(['update:showDesign'])
  registerCustomNode()

  const key = ref('')
  const activeKey = ref('base')
  const ellipsis = ref(true)
  const listLoading = ref(false)
  const show = ref(props.showDesign)
  const routes = ref<Array<any>>([])
  const selectedOperations = ref<Array<API.SelectResult>>([])
  const categoryList = ref<Array<cacheCommonModel>>([])
  const x6Ref = ref<HTMLElement>()
  const graph = ref<Graph>()
  const currentClickCell = reactive({
    type: '' as 'Node' | 'Edge',
    id: '',
    stroke: '#A2B1C3',
    strokeWidth: 2,
    text: '',
    strokeDasharray: 0,
  })
  const x6Dnd = ref<Dnd>()
  /** 表单配置项集合 */
  const formList = ref<ConfigParamType>()

  watch(
    () => props.showDesign,
    async val => {
      show.value = val
      val && (await init())
    },
  )

  watch(
    () => currentClickCell,
    newVal => {
      if (newVal.id) {
        const { id, type, stroke, strokeWidth, strokeDasharray, text } = newVal
        if (type === 'Node') {
          const node = graph.value?.getNodes().find(item => item.id == id)
          node?.attr('body/stroke', stroke)
          node?.attr('body/strokeWidth', strokeWidth)
        } else {
          const edge = graph.value?.getEdges().find(item => item.id == id)
          edge?.attr('line/stroke', stroke)
          edge?.attr('line/strokeWidth', strokeWidth)
          edge?.attr('line/strokeDasharray', strokeDasharray)
          strokeDasharray && edge?.attr('line/style/animation', `ant-line 30s infinite linear`)
          edge?.setLabels(text.split(';'))
        }
      }
    },
    {
      deep: true,
    },
  )

  watchEffect(() => {
    if (+currentClickCell.id > 0 && currentClickCell.type === 'Node') {
      const node = graph.value?.getNodes().find(item => item.id == currentClickCell.id)
      formList.value = node?.getData<ConfigParamType>()
    }
  })

  /** 点击其他区域(非node和edge) */
  const handleBlank = () => {
    currentClickCell.id = ''
    graph.value?.cleanSelection()
    graph.value?.clearTransformWidgets()
  }

  /** 保存流程设计 */
  const handleDesignSave = async () => {
    const processSequence: ProcessItemType[] = []
    calcNodeSort('-1', processSequence)
    handleBlank()
    graph.value?.toPNG(
      async dataUri => {
        const graphJson = graph.value?.toJSON()
        const configForm = graph.value
          ?.getNodes()
          .map(item => item.getData<ConfigParamType>())
          .filter(item => item)
        const params = {
          id: props.id,
          base64: dataUri.split(',')[1],
          graph: JSON.stringify(graphJson),
          processData: processSequence,
          configForm,
        }
        await action.updateDesign(params)
        emit('update:showDesign', false, true)
      },
      { width: 1100, height: 800 },
    )
  }

  /** 计算流程节点的顺序 */
  const calcNodeSort = (nodeId: string, result: ProcessItemType[] = []) => {
    const edges = graph.value?.getEdges()
    const edgesByNodeSource = edges?.filter(edge => edge.getSourceNode()?.id === nodeId)
    if (!edgesByNodeSource?.length) return
    for (const edge of edgesByNodeSource!) {
      const targetNode = edge.getTargetNode()
      if (!targetNode) continue
      result.push({
        id: nodeId,
        nextId: targetNode.id,
        label: edge.prop('labels')?.join(',') || '',
      })
      calcNodeSort(targetNode.id, result)
    }
  }

  const handleDesignCancel = () => {
    handleBlank()
    emit('update:showDesign', false)
  }

  const onDragstart = (e: MouseEvent, item: cacheCommonModel) => {
    const options: ConfigParamType = {
      id: item.id,
      base: {
        isStart: false,
        isOutput: false,
        isLackMaterialWarn: false,
      },
      test: {
        testMode: undefined,
        maxTestCount: undefined,
      },
    }
    const node = graph.value!.createNode({
      id: item.id.toString(),
      shape: 'custom-rect',
      width: 140,
      height: 40,
      label: `(${item.code})${item.name}`,
      data: options,
    })
    x6Dnd.value?.start(node, e)
  }

  /**
   * 获取所有分类
   * @param key 分类名称
   */
  const getCateList = async (_key?: string) => {
    let data = [] // TODO: 这里改成你需要的左边数据
    categoryList.value = data
  }

  const init = async () => {
    listLoading.value = true
    try {
      const [_, routeData] = await Promise.all([
        getCateList(),
        action.getWithPage({ pageSize: 100 }),
      ])
      routes.value = routeData.list
      const { dnd, graphX6 } = useX6(graph.value, x6Ref.value!)
      graph.value = graphX6
      x6Dnd.value = dnd
      await loadX6()
      initSelectedOperations()
    } finally {
      listLoading.value = false
    }
  }

  const initSelectedOperations = () => {
    selectedOperations.value = []
    const nodes = graph.value?.getNodes()
    nodes?.forEach(node => {
      if (+node.id > 0) {
        selectedOperations.value.push({ value: +node.id, label: node['label'] })
      }
    })
  }

  const loadX6 = async () => {
    if (!graph.value) return
    const data = await action.getById(props.id)
    if (data?.content) {
      graph.value.fromJSON(JSON.parse(data.content))
    } else {
      graph.value.addNodes([
        {
          id: '-1',
          shape: 'custom-rect',
          label: '开始',
          x: 300,
          y: 20,
          attrs: {
            body: {
              rx: 20,
              ry: 26,
            },
          },
        },
        {
          id: '-999',
          shape: 'custom-rect',
          label: '结束',
          x: 300,
          y: 600,
          attrs: {
            body: {
              rx: 20,
              ry: 26,
            },
          },
        },
      ])
    }

    graph.value.centerContent()

    // 点击事件
    graph.value.on('cell:click', ({ cell }) => {
      if (cell.isNode()) {
        currentClickCell.type = 'Node'
        currentClickCell.id = cell.id
        currentClickCell.stroke = cell.attr('body/stroke')
        currentClickCell.strokeWidth = cell.attr('body/strokeWidth')
        currentClickCell.text = cell.attr('text/text')
      } else {
        currentClickCell.type = 'Edge'
        currentClickCell.id = cell.id
        currentClickCell.stroke = cell.attr('line/stroke')
        currentClickCell.strokeWidth = cell.attr('line/strokeWidth')
        currentClickCell.strokeDasharray = cell.attr('line/strokeDasharray') || 0
        currentClickCell.text = cell.prop('labels')?.join(';') || ''
        graph.value?.clearTransformWidgets()
      }
    })

    graph.value.on('blank:click', handleBlank)

    /** 添加node到画布时触发 */
    graph.value.on('node:added', ({ node }) => {
      // 触发node单击事件
      graph.value?.trigger('cell:click', { cell: node })
      graph.value?.resetSelection(node)
      graph.value?.clearTransformWidgets()
      graph.value?.createTransformWidget(node)
      selectedOperations.value.push({ value: +node.id, label: node['label'] })
    })

    /** 删除node事件 */
    graph.value.on('node:removed', ({ node }) => {
      handleBlank()
      selectedOperations.value = selectedOperations.value.filter(item => item.value !== +node.id)
    })
  }
</script>

<style lang="less">
  @keyframes ant-line {
    to {
      stroke-dashoffset: -1000;
    }
  }

  .x6-widget-selection-box {
    border: 2px dashed var(--color);
  }

  .x6-widget-selection-inner {
    border: 1px solid var(--color);
  }
</style>
<style lang="less" scoped>
  .operation_list {
    padding-right: 10px;
  }
</style>
