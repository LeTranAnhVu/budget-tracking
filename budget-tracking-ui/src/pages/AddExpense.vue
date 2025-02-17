<script setup lang="ts">
import type { InputExpenseDto } from '@/models/InputExpenseDto'
import Button from '@/components/Button.vue'
import ExpenseForm from '@/components/forms/ExpenseForm.vue'
import date2Str from '@/helpers/date2Str'
import { useAppStore } from '@/stores/appStore'
import { useToastStore } from '@/stores/toastStore'
import { onMounted, reactive } from 'vue'

const appStore = useAppStore()
const toastStore = useToastStore()
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
  try {
    await appStore.getApi().post('/expenses', form)
    toastStore.showToast('Expense created!')
    resetForm()
  } catch (error) {
    toastStore.showToast('Error saving expense', 'error')
    console.error(error)
  }
}

function resetForm(): void {
  form.amount = 0
  form.paidDate = date2Str(new Date())
  form.note = ''
  form.categoryId = -1
  form.includedTax = false
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
