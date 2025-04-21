<template>
  <div class="md:flex">
    <template v-for="(item, index) in growCardList" :key="item.title">
      <Card
        size="small"
        :loading="loading"
        :title="item.title"
        class="md:w-1/4 w-full !md:mt-0"
        :class="{ '!md:mr-4': index + 1 < 4, '!mt-4': index > 0 }"
      >
        <template #extra>
          <Tag :color="item.color">{{ item.action }}</Tag>
        </template>

        <div class="py-4 px-4 flex justify-between items-center">
          <CountTo prefix="+" :start-val="1" :end-val="item.value" class="text-2xl" />
          <Icon :icon="item.icon" :color="item.color" size="40" />
        </div>

        <div class="p-2 px-4 flex justify-between">
          <span>{{ $t('common.totalAlone') }}{{ item.title }}</span>
          <CountTo :start-val="1" :end-val="item.total" />
        </div>
      </Card>
    </template>
  </div>
</template>
<script lang="ts" setup>
  import { Tag, Card } from 'ant-design-vue'
  import { CountTo } from '@/components/basic/countTo'
  import { Icon } from '@/components/basic/icon'
  import { useI18n } from '@/hooks/useI18n'

  defineProps({
    loading: {
      type: Boolean,
    },
  })

  const { t } = useI18n()
  interface GrowCardItem {
    icon: string
    title: string
    value: number
    total: number
    color: string
    action: string
  }
  const growCardList: GrowCardItem[] = [
    {
      title: t('common.visit'),
      icon: 'yonghu',
      value: Math.random() * 100,
      total: 56356,
      color: '#50c48f',
      action: t('common.day'),
    },
    {
      title: t('common.customer'),
      icon: 'fenxiang',
      value: Math.random() * 10,
      total: 63,
      color: 'pink',
      action: t('common.week'),
    },
    {
      title: t('column.template'),
      icon: 'tiaoxingtu',
      value: Math.random() * 10,
      total: 631,
      color: '#a3e3f3',
      action: t('common.month'),
    },
    {
      title: t('common.deal'),
      icon: 'xindaifuwu',
      value: Math.random() * 10,
      total: 156,
      color: '#48b1b1',
      action: t('common.year'),
    },
  ]
</script>
