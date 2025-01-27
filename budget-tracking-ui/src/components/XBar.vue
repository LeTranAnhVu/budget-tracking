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
      class="h-full bg-[#f0f2f4] border-gray-500 transition-all ease-in-out duration-350 w-full relative"
      :style="{ width: `${process * 100}%`, transitionDelay: `${delay}ms` }"
    >
      <p
        v-if="info && isShowInfo"
        class="text-xs font-light absolute left-[50%] top-[50%] translate-[-50%] z-10"
      >
        {{ info }}
      </p>
    </div>
    <!-- :style="{ transform: `scaleX(${process})`, transformOrigin: 'top left' }" -->
    <div class="h-full w-[2px] bg-gray-700" />
  </div>
</template>
