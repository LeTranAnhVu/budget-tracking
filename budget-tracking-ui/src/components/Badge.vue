<script setup lang="ts">
defineProps<{
  content: string
}>()
</script>

<template>
  <span class="inline-flex items-center rounded-md bg-blue-50 px-2 py-1 text-xs font-medium text-blue-500 ring-1 ring-blue-700/10 ring-inset">{{ content }}</span>
</template>
