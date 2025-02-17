<script setup lang="ts">
import { useToastStore } from '@/stores/toastStore'

const toastStore = useToastStore()
</script>

<template>
  <div
    v-if="toastStore.show"
    class="fixed top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2 text-white px-4 py-2 rounded-lg shadow-md z-50 border transition-all duration-300 ease-in-out text-center"
    :class="[
      toastStore.type === 'error'
        ? 'bg-red-500/90 border-red-500/50'
        : 'bg-gray-800/90 border-gray-700/50',
    ]"
  >
    {{ toastStore.message }}
  </div>
</template>
