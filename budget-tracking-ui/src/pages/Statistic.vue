<script setup lang="ts">
import type ExpenseDto from '@/models/ExpenseDto'
import DaySpending from '@/components/Statistics/DaySpending.vue'
import MonthlySpending from '@/components/Statistics/MonthlySpending.vue'
import TotalSpending from '@/components/Statistics/TotalSpending.vue'
import { useAppStore } from '@/stores/appStore'
import { onMounted, ref } from 'vue'

const expenses = ref<ExpenseDto[]>([])
const appStore = useAppStore()

async function loadData(): Promise<void> {
  expenses.value = await appStore.getApi().get<ExpenseDto[]>('/expenses')
}

onMounted(async () => {
  appStore.isLoading = true
  await loadData()
  appStore.isLoading = false
})
</script>

<template>
  <div>
    <div class="flex flex-col gap-20 mt-5">
      <div>
        <TotalSpending :expenses="expenses" />
      </div>

      <div>
        <MonthlySpending :expenses="expenses" />
      </div>

      <div>
        <h2 class="font-bold text-gray-800 mb-5">
          By Category
        </h2>
        <div class="flex flex-col gap-15">
          <DaySpending :days="7" />
          <DaySpending :days="30" />
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
</style>
