<script setup lang="ts">
defineProps<{
  isVisible: boolean
}>()
</script>

<template>
  <Transition
    enter-active-class="[animation:drop-in_0.5s_ease-out_forwards]"
    leave-active-class="[animation:fly-out_0.5s_ease-in_forwards]"
  >
    <div
      v-if="isVisible"
      class="fixed inset-0 flex justify-center z-50"
    >
      <div class="mt-[50vh]">
        <div class="w-12 h-12 rounded-full [animation:spin_0.7s_linear_infinite] border-4 border-primary border-t-transparent shadow-lg" />
      </div>
    </div>
  </Transition>
</template>

<style>
@keyframes drop-in {
  0% { transform: translateY(-100%); }
  70% { transform: translateY(20%); }
  100% { transform: translateY(0%); }
}

@keyframes fly-out {
  0% { transform: translateY(0); }
  2% { transform: translateY(5%); }
  10% { transform: translateY(10%); }
  100% { transform: translateY(-240%); }
}

@keyframes spin {
  from { transform: rotate(0deg); }
  to { transform: rotate(360deg); }
}
</style>
