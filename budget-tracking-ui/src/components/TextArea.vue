<script setup lang="ts">
defineProps<{
  label: string
  placeholder: string
}>()
const value = defineModel<string>()
</script>

<template>
  <div class="flex max-w-[480px] flex-wrap items-end gap-4">
    <label class="flex flex-col min-w-40 flex-1">
      <p class="text-[#111318] text-base font-medium leading-normal pb-2">{{ label }}</p>
      <textarea
        v-model="value"
        :placeholder="placeholder"
        class="form-input flex w-full min-w-0 flex-1 resize-none overflow-hidden rounded-xl text-[#111318] focus:outline-0 focus:ring-0 border-none bg-[#f0f2f4] focus:border-none min-h-36 placeholder:text-[#636e88] p-4 text-base font-normal leading-normal"
      />
    </label>
  </div>
</template>
