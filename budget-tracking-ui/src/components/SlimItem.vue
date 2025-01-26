<script setup lang="ts">
defineProps<{
  title: string
  description: string
  sideText: string
}>()
</script>

<template>
  <div class="flex items-center gap-4 bg-white min-h-[72px] justify-between">
    <div class="flex flex-col justify-center">
      <p class="text-[#111318] text-base font-medium leading-normal line-clamp-1">
        {{ title }}
      </p>
      <p class="text-[#636e88] text-sm font-normal leading-normal line-clamp-2">
        {{ description }}
      </p>
    </div>
    <div class="shrink-0">
      <p class="text-[#111318] text-base font-normal leading-normal">
        {{ sideText }}
      </p>
    </div>
  </div>
</template>
