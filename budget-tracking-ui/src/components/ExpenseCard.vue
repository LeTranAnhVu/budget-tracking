<script setup lang="ts">
import { ref } from 'vue'
// import ChevronDownIcon from './icons/ChevronDownIcon.vue'
import CaretDownIcon from './icons/CaretDownIcon.vue'
import EditIcon from './icons/EditIcon.vue'
import TrashIcon from './icons/TrashIcon.vue'

defineProps<{
  date: string
  title: string
  amount: number
  description: string
  category: string
}>()

const emit = defineEmits<{
  edit: []
  delete: []
}>()

const isExpanded = ref(false)
</script>

<template>
  <div class="bg-white rounded-2xl p-4 shadow">
    <div
      class="flex justify-between items-start cursor-pointer"
      @click="isExpanded = !isExpanded"
    >
      <div>
        <span class="text-sm text-gray-500">{{ date }}</span>
        <h3 class="font-medium text-gray-800 mt-1">
          {{ title }}
        </h3>
      </div>
      <div class="flex flex-col items-end gap-2">
        <div class="flex items-center gap-2">
          <span class="font-bold text-gray-800">${{ amount.toFixed(2) }}</span>
          <CaretDownIcon
            :is-open="isExpanded"
            class="h-5 w-5 text-gray-400"
          />
        </div>
        <span class="px-2 py-0.5 bg-gray-100 text-gray-600 text-xs rounded-full">
          {{ category }}
        </span>
      </div>
    </div>

    <!-- Collapsible content -->
    <div
      v-if="isExpanded"
      class="mt-3 pt-3 border-dashed text-gray-200"
    >
      <p class="text-gray-600 text-sm mb-3">
        {{ description }}
      </p>
      <div class="flex justify-end gap-3">
        <button
          class="p-1.5 rounded-full text-gray-500 hover:bg-gray-100"
          @click="emit('edit')"
        >
          <div class="w-5 h-5">
            <EditIcon />
          </div>
        </button>
        <button
          class="p-1.5 rounded-full text-red-400"
          @click="emit('delete')"
        >
          <div class="w-5 h-5">
            <TrashIcon />
          </div>
        </button>
      </div>
    </div>
  </div>
</template>

<style scoped>
.border-dashed {
  border-style: dashed;
  border-width: 1px 0 0 0;
  border-image: repeating-linear-gradient(
    to right,
    currentColor 0px,
    currentColor 8px,
    transparent 8px,
    transparent 12px
  ) 1;
}
</style>
