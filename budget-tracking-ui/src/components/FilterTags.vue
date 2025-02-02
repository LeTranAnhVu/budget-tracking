<script setup lang="ts">
defineProps<{
  modelValue: string | number
  options: { id: string | number, name: string }[]
}>()

const emit = defineEmits<{
  'update:modelValue': [value: string | number]
}>()
</script>

<template>
  <div class="flex flex-wrap gap-2 mb-4">
    <button
      v-for="option in options"
      :key="option.id"
      class="px-3 py-1.5 rounded-full text-sm font-medium"
      :class="[
        modelValue === option.id
          ? 'bg-gray-800 text-white'
          : 'bg-gray-100 text-gray-600 hover:bg-gray-200',
      ]"
      @click="emit('update:modelValue', option.id)"
    >
      {{ option.name }}
    </button>
  </div>
</template>
