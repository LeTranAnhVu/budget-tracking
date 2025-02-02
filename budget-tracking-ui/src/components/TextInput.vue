<script setup lang="ts">
defineProps<{
  placeholder: string
  isPassword?: boolean
}>()

const value = defineModel<string | undefined>({ required: true })
</script>

<template>
  <input
    v-model="value"
    :placeholder="placeholder"
    :type="isPassword ? 'password' : 'text'"
    class="form-input flex w-full min-w-0 flex-1 resize-none overflow-hidden rounded-xl text-[#111318] focus:outline-4 focus:outline-blue-50 border-none bg-[#f0f2f4] focus:border-none h-14 placeholder:text-[#636e88] p-4 border-r-0 pr-2 text-base font-normal leading-normal"
  >
</template>
