<script setup lang="ts">
defineProps<{
  isRotated: boolean
}>()
</script>

<template>
  <svg
    :class="{ 'rotate-180': isRotated }"
    xmlns="http://www.w3.org/2000/svg"
    class="h-5 w-5 transition-transform duration-300"
    fill="none"
    viewBox="0 0 24 24"
    stroke="currentColor"
  >
    <path
      stroke-linecap="round"
      stroke-linejoin="round"
      stroke-width="2"
      d="M19 9l-7 7-7-7"
    />
  </svg>
</template>
