<script setup lang="ts">
defineProps<{
  label: string
  symbol?: string
}>()
const value = defineModel<Date>()
</script>

<template>
  <div class="flex max-w-[480px] flex-wrap items-end gap-4 px-4 py-3">
    <label class="flex flex-col min-w-40 flex-1">
      <p class="text-[#111318] text-base font-medium leading-normal pb-2">{{ label }}</p>
      <div class="flex w-full flex-1 items-stretch rounded-xl relative">
        <span
          v-if="symbol"
          class="absolute left-4 top-[50%] translate-y-[-50%] text-[#636e88] "
        >{{ symbol }}</span>
        <input
          v-model="value"
          placeholder="Select a date"
          type="date"
          class="form-input appearance-none flex w-full min-w-0 flex-1 resize-none overflow-hidden rounded-xl text-[#111318] focus:outline-0 focus:ring-0 border-none bg-[#f0f2f4] focus:border-none h-14 placeholder:text-[#636e88] p-4 rounded-r-none border-r-0 pr-2 text-base font-normal leading-normal"
        >
        <div
          class="text-[#636e88] flex border-none bg-[#f0f2f4] items-center justify-center pr-4 rounded-r-xl border-l-0"
          data-icon="icon"
          data-size="24px"
          data-weight="regular"
        >
          <slot name="icon" />
        </div>
      </div>
    </label>
  </div>
</template>
