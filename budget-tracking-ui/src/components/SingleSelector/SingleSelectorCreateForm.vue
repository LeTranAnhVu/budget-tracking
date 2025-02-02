<script setup lang="ts">
import PlusIcon from '@/components/icons/PlusIcon.vue'
import { ref } from 'vue'
import TimeIcon from '../icons/TimeIcon.vue'
import TextButton from '../TextButton.vue'

const emit = defineEmits<{
  save: [value: string]
}>()

const textValue = ref('')
const isCreating = ref(false)
function save(): void {
  if (textValue.value) {
    emit('save', textValue.value)
  }
}
</script>

<template>
  <label class="flex items-center rounded-lg border border-solid border-[#dcdfe5] p-[8px] relative">
    <template v-if="!isCreating">
      <div
        class="flex gap-1 justify-center items-center"
        @click="isCreating = !isCreating"
      >
        <PlusIcon class="text-[#111318]" />
        <p class="text-sm">New</p>
      </div>
    </template>
    <template v-else>
      <div class="flex gap-1">
        <input
          v-model="textValue"
          placeholder="Enter ..."
          class="inline w-20 min-w-0.5 overflow-hidden text-[#111318] outline-0 border-none bg-[#f0f2f4] focus:border-none placeholder:text-[#636e88] border-r-0 text-sm font-normal leading-normal"
        >
        <TextButton
          class="b border-l-1 pl-2"
          @click="save"
        >save</TextButton>
      </div>

      <TextButton
        class="absolute -top-2 -right-2 w-3 h-3 flex items-center justify-center ring-1 rounded-full"
        @click="isCreating = false"
      >
        <TimeIcon />
      </TextButton>
    </template>
  </label>
</template>
