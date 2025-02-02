<script setup lang="ts">
export interface SingleSelectorItem {
  value: number | string
  name: string
}

defineProps<{
  item: SingleSelectorItem
  id: string
}>()

const value = defineModel()
</script>

<template>
  <label class="flex items-center gap-4 rounded-lg border border-solid border-[#dcdfe5] p-[8px]">
    <input
      v-model="value"
      type="radio"
      class="h-4 w-4 border-2 border-[#dcdfe5] bg-transparent text-transparent checked:border-[#111318] checked:bg-[image:--radio-dot-svg] focus:outline-none focus:ring-0 focus:ring-offset-0 checked:focus:border-[#111318]"
      :name="id"
      :value="item.value"
    >
    <div class="flex grow flex-col">
      <p class="text-[#636e88] text-sm font-normal leading-normal">{{ item.name }}</p>
    </div>
  </label>
</template>
