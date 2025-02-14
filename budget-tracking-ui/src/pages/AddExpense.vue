<script setup lang="ts">
import type { InputExpenseDto } from '@/models/InputExpenseDto'
import Button from '@/components/Button.vue'
import ExpenseForm from '@/components/forms/ExpenseForm.vue'
import date2Str from '@/helpers/date2Str'
import { useAppStore } from '@/stores/appStore'
import { reactive } from 'vue'

const appStore = useAppStore()
const form = reactive<InputExpenseDto>({
  amount: 0,
  paidDate: date2Str(new Date()),
  note: '',
  categoryId: -1,
  includedTax: false,
})

function createNewCategory(value: string, supCategoryId: number): void {
  console.warn('new category', value, supCategoryId)
}

async function save(): Promise<void> {
  if (form.categoryId === -1 || form.amount === 0) {
    console.error('Nothing to create')
    return
  }
  await appStore.getApi().post('/expenses', form)
}
</script>

<template>
  <div>
    <div>
      <ExpenseForm
        v-model:expense-form="form"
        @new-category-save="createNewCategory"
      />
    </div>

    <div class="mt-10">
      <Button @click="save">
        Save
      </Button>
    </div>
  </div>
</template>

<style scoped>
</style>
