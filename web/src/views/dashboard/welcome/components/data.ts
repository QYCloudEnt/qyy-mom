export const option1 = {
  title: {
    text: 'TReport关系图',
    left: 'center',
    bottom: '5%',
    textStyle: {
      fontSize: 16,
    },
  },
  grid: {
    left: '10%',
    top: 60,
    right: '10%',
    bottom: 60,
  },
  series: [
    {
      type: 'graph',
      layout: 'force',
      force: {
        repulsion: 1000,
        edgeLength: 70,
        layoutAnimation: true,
      },
      symbolSize: 70,
      nodeScaleRatio: 1, //图标大小是否随鼠标滚动而变
      roam: false, //缩放
      draggable: true, //节点是否可以拖拽
      // focusNodeAdjacency: false, //是否在鼠标移到节点上的时候突出显示节点以及节点的边和邻接节点
      edgeSymbol: ['circle', 'arrow'], //线2头标记
      label: {
        show: true,
        position: 'inside',
        color: '#d2f0fd',
      },
      edgeLabel: {
        show: true,
        fontSize: 12,
        color: '#fff',
        formatter: '{c}',
      },
      categories: [
        {
          name: '图表',
        },
        {
          name: '特性',
          symbol: 'rect',
        },
      ],
      itemStyle: {
        borderColor: '#04f2a7',
        borderWidth: 2,
        shadowBlur: 2,
        shadowColor: '#9ee2f2',
        color: '#48b1b1',
      },
      lineStyle: {
        opacity: 0.9,
        width: 2,
        curveness: 0,
        color: {
          type: 'linear',
          x: 0,
          y: 0,
          x2: 0,
          y2: 1,
          colorStops: [
            {
              offset: 0,
              color: '#114858', // 0% 处的颜色
            },
            {
              offset: 1,
              color: '#abe5f6', // 100% 处的颜色
            },
          ],
          globalCoord: false, // 缺省为 false
        },
      },
      symbolKeepAspect: false,
      data: [
        {
          name: '可视化',
        },
        {
          name: '柱状图',
        },
        {
          name: '折线图',
        },
        {
          name: '饼图',
        },
        {
          name: '雷达图',
        },
        {
          name: 'TReport',
        },
        {
          name: '低代码',
        },
        {
          name: 'EChart',
        },
        {
          name: '数据大屏',
        },
        {
          name: '数据钻取',
        },
      ],
      links: [
        {
          source: 0,
          target: 1,
          value: '',
        },
        {
          source: 0,
          target: 2,
          value: '',
        },
        {
          source: 0,
          target: 3,
          value: '',
        },
        {
          source: 0,
          target: 4,
          value: '',
        },
        {
          source: 0,
          target: 5,
          value: '',
        },
        {
          source: 5,
          target: 6,
          value: '',
        },
        {
          source: 5,
          target: 7,
          value: '',
        },
        {
          source: 5,
          target: 8,
          value: '',
        },
        {
          source: 5,
          target: 9,
          value: '',
        },
      ],
    },
  ],
}

export const option2 = {
  title: {
    text: '流量趋势图',
    left: 'center',
    bottom: '5%',
    textStyle: {
      fontSize: 16,
    },
  },
  grid: {
    top: '20%',
    left: '10%',
    right: '10%',
    bottom: '15%',
    containLabel: true,
  },
  xAxis: {
    type: 'category',
    boundaryGap: false,
    data: ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12'],
    axisLabel: {
      margin: 30,
      // color: '#ffffff63'
    },
    axisLine: {
      show: false,
    },
    axisTick: {
      show: false,
      length: 25,
      lineStyle: {
        color: '#ffffff1f',
      },
    },
    splitLine: {
      show: false,
      lineStyle: {
        color: '#ffffff1f',
      },
    },
  },
  yAxis: [
    {
      type: 'value',
      position: 'right',
      axisLabel: {
        margin: 20,
        // color: '#ffffff63'
      },

      axisTick: {
        show: false,
        length: 15,
        lineStyle: {
          color: '#ffffff1f',
        },
      },
      splitLine: {
        show: false,
        lineStyle: {
          color: '#ffffff1f',
        },
      },
      axisLine: {
        lineStyle: {
          // color: '#fff',
          width: 2,
        },
      },
    },
  ],
  series: [
    {
      name: '注册总量',
      type: 'line',
      smooth: true, //是否平滑曲线显示
      showAllSymbol: true,
      symbol: 'circle',
      symbolSize: 6,
      lineStyle: {
        color: '#fff', // 线条颜色
      },
      label: {
        show: true,
        position: 'top',
        color: '#4c65b1',
      },
      itemStyle: {
        // color: 'red',
        borderColor: '#fff',
        borderWidth: 3,
      },
      tooltip: {
        show: false,
      },
      areaStyle: {
        // normal: {
        //   color: new echarts.graphic.LinearGradient(
        //     0,
        //     0,
        //     0,
        //     1,
        //     [
        //       {
        //         offset: 0,
        //         color: '#eb64fb'
        //       },
        //       {
        //         offset: 1,
        //         color: '#3fbbff0d'
        //       }
        //     ],
        //     false
        //   )
        // }
      },
      data: [393, 438, 485, 631, 689, 824, 987, 1000, 1100, 1200, 1400, 1683],
    },
  ],
}
