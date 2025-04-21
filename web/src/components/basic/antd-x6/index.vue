<template>
  <div>
    <div class="flex">
      <div class="mr-2" :style="{ width: `${leftWidth}px` }">
        <slot name="left" />
      </div>
      <div
        ref="canvasRef"
        class="flex h-full overflow-hidden"
        :style="`width: calc(100% - ${leftWidth + rigthWidth}px)`"
      >
        <div @dragover="dragoverHandle" @dragenter="dragoverHandle">
          <slot name="center" />
          <slot name="bottom-center" />
        </div>
      </div>
      <div class="ml-2 flex justify-center" :style="{ width: `${rigthWidth}px` }">
        <slot name="right" />
      </div>
    </div>
    <slot name="bottom-left" />
  </div>
</template>

<script lang="ts" setup>
  defineOptions({
    name: 'AntdX6',
  })
  const props = defineProps({
    leftWidth: {
      type: Number,
      default: 260,
    },
    rigthWidth: {
      type: Number,
      default: 300,
    },
  })

  const dragoverHandle = (e: DragEvent) => {
    e.preventDefault()
    if (e.dataTransfer) e.dataTransfer.dropEffect = 'copy'
  }
</script>

<style lang="less" scoped></style>
