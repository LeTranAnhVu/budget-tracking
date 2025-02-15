<script setup lang="ts">
import type ExpenseDto from '@/models/ExpenseDto'
import type { InputExpenseDto } from '@/models/InputExpenseDto'
import Button from '@/components/Button.vue'
import ExpenseForm from '@/components/forms/ExpenseForm.vue'
import { useAppStore } from '@/stores/appStore'
import { onMounted, reactive, ref } from 'vue'
import { useRoute } from 'vue-router'

const route = useRoute()
const appStore = useAppStore()
const expense = ref<ExpenseDto>()
const form = reactive<InputExpenseDto>({
  amount: 0,
  paidDate: '',
  note: '',
  categoryId: -1,
  includedTax: false,
})

async function save(): Promise<void> {
  if (form.categoryId === -1 || form.amount === 0) {
    console.error('Nothing to create')
    return
  }
  await appStore.getApi().put(`/expenses/${route.params.id}`, form)
  await loadData()
}

function createNewCategory(value: string, supCategoryId: number): void {
  console.warn('new category', value, supCategoryId)
}

async function loadData(): Promise<void> {
  appStore.isLoading = true
  expense.value = await appStore.getApi().get<ExpenseDto>(`/expenses/${route.params.id}`)
  appStore.isLoading = false
}

onMounted(async () => {
  await loadData()
  if (expense.value) {
    form.amount = expense.value?.amount
    form.categoryId = expense.value?.categoryId
    form.paidDate = expense.value?.paidDate
    form.note = expense.value?.note
  }
})
</script>

<template>
  <div>
    <div>
      <ExpenseForm
        v-model:expense-form="form"
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
