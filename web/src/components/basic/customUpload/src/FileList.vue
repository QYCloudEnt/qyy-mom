<script lang="tsx">
  import { defineComponent, type CSSProperties, watch, nextTick, computed } from 'vue'
  import { fileListProps } from './props'
  import { isFunction } from '@/utils/is'
  import { useModalContext } from '@/components/core/Modal/src/hooks/useModalContext'
  import { useLayoutSettingStore } from '@/store/modules/layoutSetting'

  export default defineComponent({
    name: 'FileList',
    props: fileListProps,
    setup(props) {
      const modalFn = useModalContext()
      const themeStore = useLayoutSettingStore()

      watch(
        () => props.dataSource,
        () => {
          nextTick(() => {
            modalFn?.redoModalHeight?.()
          })
        },
      )

      const getStyle = computed((): CSSProperties => {
        const { getNavTheme } = themeStore
        return {
          border:
            getNavTheme === 'realDark'
              ? '1px solid rgba(253, 253, 253, 0.12)'
              : '1px solid rgba(5, 5, 5, 0.06)',
        }
      })

      return () => {
        const { columns, actionColumn, dataSource } = props
        const columnList = [...columns, actionColumn]
        return (
          <table class="file-table" style={getStyle.value}>
            <colgroup>
              {columnList.map(item => {
                const { width = 0, dataIndex } = item
                const style: CSSProperties = {
                  width: `${width}px`,
                  minWidth: `${width}px`,
                }
                return <col style={width ? style : {}} key={dataIndex} />
              })}
            </colgroup>
            <thead>
              <tr class="file-table-tr">
                {columnList.map(item => {
                  const { title = '', align = 'center', dataIndex } = item
                  return (
                    <th class={['file-table-th', align]} key={dataIndex} style={getStyle.value}>
                      {title}
                    </th>
                  )
                })}
              </tr>
            </thead>
            <tbody>
              {dataSource.map((record = {}, index) => {
                return (
                  <tr class="file-table-tr" key={`${index + record.name || ''}`}>
                    {columnList.map(item => {
                      const { dataIndex = '', customRender, align = 'center' } = item
                      const render = customRender && isFunction(customRender)
                      return (
                        <td class={['file-table-td', align]} key={dataIndex} style={getStyle.value}>
                          {render
                            ? customRender?.({ text: record[dataIndex], record })
                            : record[dataIndex]}
                        </td>
                      )
                    })}
                  </tr>
                )
              })}
            </tbody>
          </table>
        )
      }
    },
  })
</script>
<style lang="less" scoped>
  .file-table {
    width: 100%;
    border-collapse: collapse;

    .center {
      text-align: center;
    }

    .left {
      text-align: left;
    }

    .right {
      text-align: right;
    }

    &-th,
    &-td {
      padding: 12px 8px;
    }

    // thead {
    //   background-color: @background-color-light;
    // }

    // table,
    // td,
    // th {
    //   border: 1px solid #d9d9d9;
    // }
  }
</style>
