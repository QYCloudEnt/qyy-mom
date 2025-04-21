import { computed } from 'vue'
import { Graph } from '@antv/x6'
import { Transform } from '@antv/x6-plugin-transform'
import { Selection } from '@antv/x6-plugin-selection'
import { Keyboard } from '@antv/x6-plugin-keyboard'
import { Dnd } from '@antv/x6-plugin-dnd'
import { Export } from '@antv/x6-plugin-export'
import { register } from '@antv/x6-vue-shape'
import type { Options } from '@antv/x6/lib/graph/options'
import { useLayoutSettingStore } from '@/store/modules/layoutSetting'

const themeStore = useLayoutSettingStore()
/** 画布背景颜色 */
export const bgColor = computed(() =>
  themeStore.getNavTheme === 'realDark' ? '#0C0B0B' : '#F2F7FA',
)

export const useX6 = (_graph?: Graph, x6Ref?: HTMLElement, options?: Partial<Options.Manual>) => {
  const graph = initAntdX6(_graph, x6Ref, options)
  // 初始化插件
  initPlugins(graph)
  const dnd = new Dnd({
    target: graph,
  })
  // 绑定快捷键
  bindKeyboard(graph)
  // 控制连接桩显示/隐藏
  setPortsShowOrHide(graph, x6Ref)

  // 初始化事件
  initMouseEvent(graph)

  return { dnd, graphX6: graph }
}

/** 连接桩 */
export const ports = {
  groups: {
    top: {
      position: 'top',
      attrs: {
        circle: {
          r: 4,
          magnet: true,
          stroke: '#5F95FF',
          strokeWidth: 1,
          fill: '#fff',
          style: {
            visibility: 'hidden',
          },
        },
      },
    },
    right: {
      position: 'right',
      attrs: {
        circle: {
          r: 4,
          magnet: true,
          stroke: '#5F95FF',
          strokeWidth: 1,
          fill: '#fff',
          style: {
            visibility: 'hidden',
          },
        },
      },
    },
    bottom: {
      position: 'bottom',
      attrs: {
        circle: {
          r: 4,
          magnet: true,
          stroke: '#5F95FF',
          strokeWidth: 1,
          fill: '#fff',
          style: {
            visibility: 'hidden',
          },
        },
      },
    },
    left: {
      position: 'left',
      attrs: {
        circle: {
          r: 4,
          magnet: true,
          stroke: '#5F95FF',
          strokeWidth: 1,
          fill: '#fff',
          style: {
            visibility: 'hidden',
          },
        },
      },
    },
  },
  items: [
    {
      group: 'top',
    },
    {
      group: 'right',
    },
    {
      group: 'bottom',
    },
    {
      group: 'left',
    },
  ],
}

/** 初始化插件 */
const initPlugins = (graph: Graph) => {
  graph
    .use(
      new Transform({
        resizing: true,
        rotating: true,
      }),
    )
    .use(
      new Selection({
        rubberband: true,
        showNodeSelectionBox: true,
        pointerEvents: 'none',
        modifiers: ['alt', 'ctrl'], // alt或ctrl + 鼠标 框选
      }),
    )
    .use(new Keyboard())
    .use(new Export())
}

/** 绑定快捷键 */
const bindKeyboard = (graph: Graph) => {
  // select all
  graph.bindKey(['meta+a', 'ctrl+a'], () => {
    const nodes = graph.getNodes()
    if (nodes) {
      graph.select(nodes)
    }
  })

  // delete
  graph.bindKey('backspace', () => {
    const cells = graph.getSelectedCells()
    if (cells.length) {
      graph.removeCells(cells)
    }
  })

  // zoom
  graph.bindKey(['ctrl+1', 'meta+1'], () => {
    const zoom = graph.zoom()
    if (zoom < 1.5) {
      graph.zoom(0.1)
    }
  })
  graph.bindKey(['ctrl+2', 'meta+2'], () => {
    const zoom = graph.zoom()
    if (zoom > 0.5) {
      graph.zoom(-0.1)
    }
  })
}

/** 控制连接桩显示/隐藏 */
const setPortsShowOrHide = (graph: Graph, x6Ref?: HTMLElement) => {
  graph.on('node:mouseenter', () => {
    const container = x6Ref
    const ports = container?.querySelectorAll('.x6-port-body') as NodeListOf<SVGElement>
    showPorts(ports, true)
  })
  graph.on('node:mouseleave', () => {
    const container = x6Ref
    const ports = container?.querySelectorAll('.x6-port-body') as NodeListOf<SVGElement>
    showPorts(ports, false)
  })
}
const showPorts = (ports: NodeListOf<SVGElement>, show: boolean) => {
  for (let i = 0, len = ports.length; i < len; i += 1) {
    ports[i].style.visibility = show ? 'visible' : 'hidden'
  }
}

// 鼠标进入事件
const initMouseEvent = (graph: Graph) => {
  graph.on('cell:mouseenter', ({ cell }) => {
    if (cell.isNode()) {
      cell.addTools([
        {
          name: 'button-remove',
          args: {
            x: 0,
            y: 0,
            offset: { x: 5, y: 0 },
          },
        },
      ])
    } else {
      cell.addTools(['segments']) // 'vertices'
    }
  })

  graph.on('cell:mouseleave', ({ cell }) => {
    cell.removeTools()
  })
}

/** 初始化x6 */
const initAntdX6 = (graph?: Graph, x6Ref?: HTMLElement, options?: Partial<Options.Manual>) => {
  if (graph) graph.dispose()
  graph = new Graph({
    container: x6Ref,
    width: 1100,
    height: 700,
    background: {
      color: bgColor.value,
    },
    autoResize: true,
    connecting: {
      allowBlank: false,
      allowMulti: false,
      allowNode: false,
      allowEdge: false,
      router: 'manhattan',
      connector: {
        name: 'rounded',
        args: {
          radius: 8,
        },
      },
      anchor: 'center',
      connectionPoint: 'anchor',
      snap: {
        radius: 20,
      },
      createEdge() {
        return graph?.createEdge({
          attrs: {
            line: {
              stroke: '#52c41a',
              strokeWidth: 2,
            },
          },
        })
      },
    },
    highlighting: {
      magnetAdsorbed: {
        name: 'stroke',
        args: {
          attrs: {
            fill: '#fff',
            stroke: '#31d0c6',
            strokeWidth: 4,
          },
        },
      },
    },
    grid: {
      visible: true,
      type: 'dot',
    },
    panning: true,
    mousewheel: {
      enabled: true,
      modifiers: 'ctrl',
      maxScale: 4,
      minScale: 0.2,
    },
    ...options,
  })
  return graph
}

/** 注册自定义节点 */
export const registerCustomNode = () => {
  Graph.registerNode(
    'custom-rect',
    {
      id: '0',
      inherit: 'rect',
      width: 100,
      height: 40,
      attrs: {
        body: {
          strokeWidth: 2,
          stroke: '#5F95FF',
          fill: '#EFF4FF',
        },
        text: {
          fontSize: 12,
          fill: '#262626',
        },
      },
      ports: { ...ports },
    },
    true,
  )
}

// 注册节点缓存
const nodeCacheMap = new Map<string, any>()

/** 注册自定义Vue组件节点 */
export const registerCustomVueNode = (vueComKey: string, component) => {
  if (nodeCacheMap.has(vueComKey)) return
  register({
    shape: vueComKey,
    component,
  })
  nodeCacheMap.set(vueComKey, component)
}
