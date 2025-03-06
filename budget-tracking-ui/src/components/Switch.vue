<script setup lang="ts">
import { computed } from 'vue'

const props = defineProps<{
  modelValue: boolean
  label?: string
  disabled?: boolean
}>()

const emit = defineEmits<{
  'update:modelValue': [value: boolean]
}>()

const isChecked = computed({
  get: () => props.modelValue,
  set: (value: boolean) => emit('update:modelValue', value),
})
</script>

<template>
  <div class="flex items-center">
    <label class="relative flex w-full items-center cursor-pointer justify-between">
      <span
        v-if="label"
        class="text-[#111318] text-base font-medium leading-normal pb-2"
      >
        {{ label }}
      </span>
      <div class="relative">
        <input
          type="checkbox"
          class="sr-only peer"
          :checked="isChecked"
          :disabled="disabled"
          @change="isChecked = !isChecked"
        >
        <div
          class="w-11 h-6 bg-gray-200 rounded-full peer peer-focus:ring-4 peer-focus:ring-blue-300
        peer-checked:after:translate-x-full peer-checked:after:border-white peer-checked:bg-blue-600
        after:content-[''] after:absolute after:top-0.5 after:left-[2px] after:bg-white
        after:border-gray-300 after:border after:rounded-full after:h-5 after:w-5
        after:transition-all peer-disabled:cursor-not-allowed peer-disabled:opacity-50"
        />
      </div>
    </label>
  </div>
</template>
