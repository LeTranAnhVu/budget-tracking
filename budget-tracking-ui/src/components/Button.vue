<script setup lang="ts">
import { computed } from 'vue'

const props = withDefaults(defineProps<{
  color?: 'primary' | 'danger'
}>(), {
  color: 'primary',
})

const computedColor = computed<string>(() => {
  switch (props.color) {
    case 'primary':
      return 'bg-gray-800'
    case 'danger':
      return 'bg-red-500'

    default:
      return 'bg-gray-800'
  }
})
</script>

<template>
  <button
    class="cursor-pointer w-full items-center justify-center overflow-hidden rounded-lg h-12 py-2 px-5 text-white text-base font-bold"
    :class="computedColor"
  >
    <slot />
  </button>
</template>
