<script setup lang="ts">
defineProps<{
  process: number
  delay: number
  info?: string
  isShowInfo?: boolean
}>()
</script>

<template>
  <div class="flex h-full flex-row relative">
    <div
      class="h-full border-gray-500 transition-all ease-in-out duration-350 w-full relative bg-gradient-to-r from-red-200/50 to-red-300 rounded-br-md rounded-tr-md"
      :style="{ width: `${process * 100}%`, transitionDelay: `${delay}ms` }"
    >
      <p
        v-if="info && isShowInfo"
        class="text-xs text-black font-light absolute left-[50%] top-[50%] translate-[-50%] z-10"
      >
        {{ info }}
      </p>
    </div>
  </div>
</template>
