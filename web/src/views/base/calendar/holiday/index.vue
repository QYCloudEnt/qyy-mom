<template>
  <div>
    <Calendar v-model:value="value" @panelChange="onPanelChange" @select="onSelect">
      <template #dateCellRender="{ current }">
        <Tag :color="isHoliday(current) ? '#e4393c' : '#13c2c2'">
          {{ isHoliday(current) ? '休' : '班' }}
        </Tag>
      </template>
    </Calendar>
  </div>
</template>

<script lang="ts" setup>
  import { ref } from 'vue'
  import { Calendar, Tag } from 'ant-design-vue'
  import type { Dayjs } from 'dayjs'
  import { formatToDate, dateUtil } from '@/utils/dateUtil'
  import { useI18n } from '@/hooks/useI18n'
  import { useFormModal } from '@/hooks/useModal/useFormModal'
  import { formSchemas } from './formSchemas'
  import action from '@/api/base/calendar/holiday/index.ts'

  defineOptions({
    name: 'BaseCalendarHoliday',
  })

  const value = ref<Dayjs>()
  const yearMonth = ref('')
  const holidays = ref<string[]>([])

  const { t } = useI18n()
  const [showModal] = useFormModal()

  const load = async () => {
    if (!yearMonth.value) {
      yearMonth.value = dateUtil().format('YYYY-MM')
    }
    const data = await action.getHolidays(yearMonth.value)
    holidays.value = data
  }

  load()

  const onPanelChange = (value: Dayjs, _: string) => {
    yearMonth.value = value.format('YYYY-MM')
  }

  const onSelect = async (date: Dayjs, { source }) => {
    if (source !== 'date') return
    const [formRef] = await showModal({
      modalProps: {
        title: t('common.edit'),
        width: '30%',
        onFinish: async values => {
          await action.updateDate(formatToDate(date), values.type === 'holiday')
          await load()
        },
      },
      formProps: {
        labelWidth: 120,
        layout: 'horizontal',
        schemas: formSchemas,
      },
    })
    formRef?.setFieldsValue({
      type: isHoliday(date) ? 'holiday' : 'workday',
      date: formatToDate(date),
    })
  }

  const isHoliday = (value: Dayjs) => {
    const date = formatToDate(value)
    return holidays.value.includes(date)
  }
</script>

<style lang="less" scoped></style>
