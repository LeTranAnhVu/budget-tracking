<script setup lang="ts">
import AddExpenseForm from '@/components/AddExpenseForm.vue'
import TextButton from '@/components/TextButton.vue'

function save(): void {
  console.error('save')
}
</script>

<template>
  <div class="pt-4">
    <div class="relative">
      <h1 class="text-2xl font-bold text-center">
        Add Expense
      </h1>
      <div class="absolute top-1 right-1">
        <TextButton @click="save">
          Save
        </TextButton>
      </div>
    </div>

    <div>
      <AddExpenseForm />
    </div>
  </div>
</template>

<style scoped>
</style>
