<script setup lang="ts">
import CaretDownIcon from '@/components/icons/CaretDownIcon.vue'
import { ref } from 'vue'

const props = defineProps<{
  title: string
  initialOpen?: boolean
}>()
const isOpen = ref<boolean>(props.initialOpen === true || false)

function toggle(): void {
  isOpen.value = !isOpen.value
}

function beforeEnter(el: Element): void {
  (el as HTMLDivElement).style.height = '0'
}

function enter(el: Element): void {
  (el as HTMLDivElement).style.height = `${el.scrollHeight}px`
  el.addEventListener(
    'transitionend',
    () => {
      (el as HTMLDivElement).style.height = 'auto'
    },
    { once: true },
  )
}

function leave(el: Element): void {
  (el as HTMLDivElement).style.height = `${el.scrollHeight}px`
  // Force a reflow to trigger the transition
  void (el as HTMLDivElement).offsetHeight;
  (el as HTMLDivElement).style.height = '0'
}
</script>

<template>
  <div class="">
    <div class="overflow-hidden">
      <button
        class="flex justify-between items-center w-full py-4 text-left text-gray-700 font-medium focus:outline-none hover:bg-gray-100 transition"
        @click="toggle"
      >
        <span>{{ title }}</span>
        <CaretDownIcon :is-open="isOpen" />
      </button>
      <transition
        name="collapse"
        @before-enter="beforeEnter"
        @enter="enter"
        @leave="leave"
      >
        <div
          v-show="isOpen"
          class="text-gray-600"
        >
          <slot />
        </div>
      </transition>
    </div>
  </div>
</template>

<style scoped>
.collapse-enter-active,
.collapse-leave-active {
  transition: height 0.3s ease;
}
.collapse-enter-from,
.collapse-leave-to {
  height: 0;
}
</style>
