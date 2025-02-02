<script setup lang="ts">
import type CategoryDto from '@/models/CategoryDto'
import Button from '@/components/Button.vue'
import ExpenseForm from '@/components/forms/ExpenseForm.vue'
import date2Str from '@/helpers/date2Str'
import { reactive } from 'vue'

const ingredients = [
  { id: 1, name: 'milk' },
  { id: 2, name: 'diesel' },
  { id: 3, name: 'sugar' },
  { id: 4, name: 'toppings' },
]

const packaging = [
  { id: 5, name: 'cups' },
  { id: 6, name: 'cones' },
  { id: 7, name: 'napkins' },
  { id: 8, name: 'spoons' },
]

const fuel = [
  { id: 9, name: 'gasoline' },
  { id: 10, name: 'diesel' },
]

const maintaince = [
  { id: 11, name: 'repairs' },
  { id: 12, name: 'servicing' },
]

const categories: Record<string, { id: number, categories: CategoryDto[] }> = {
  ingredients: {
    id: 1,
    categories: ingredients,
  },
  packaging: {
    id: 2,
    categories: packaging,
  },
  fuel: {
    id: 3,
    categories: fuel,
  },
  maintaince: {
    id: 4,
    categories: maintaince,
  },
}

const form = reactive({
  amount: 12.3,
  date: date2Str(new Date()),
  notes: '',
  categoryId: 2,
})
function save(): void {
  console.error('save', form)
}

function createNewCategory(value: string, supCategoryId: number): void {
  console.warn('new category', value, supCategoryId)
}
</script>

<template>
  <div>
    <div>
      <ExpenseForm
        v-model:expense-form="form"
        :categories="categories"
        @new-category-save="createNewCategory"
      />
    </div>

    <div class="mt-10 flex flex-col gap-4">
      <Button @click="save">
        Update
      </Button>
    </div>
  </div>
</template>

<style scoped>
</style>
