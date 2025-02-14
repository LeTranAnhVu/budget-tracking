<script setup lang="ts">
import type ExpenseDto from '@/models/ExpenseDto'
import BarChart from '@/components/charts/BarChart.vue'
import { MONTHS } from '@/constants'
import { getThreeLetterMonth } from '@/helpers/dateUtils'
import { computed } from 'vue'

const props = defineProps<{
  expenses: ExpenseDto[]
}>()

const monthlyAmounts = computed<number[]>(() => {
  const aggre = props.expenses.reduce((acc, ex) => {
    const month = getThreeLetterMonth(ex.paidDate)
    if (!acc[month]) {
      acc[month] = 0
    }

    acc[month] += ex.amount
    return acc
  }, {} as Record<string, number>)

  return MONTHS.map(mo => aggre[mo] || 0)
})
</script>

<template>
  <div>
    <h2 class="font-bold text-gray-800 mb-2">
      Monthly spending
    </h2>
    <div>
      <BarChart
        color="red"
        label="Expense"
        :y="[...monthlyAmounts]"
        :x="[...MONTHS]"
      />
    </div>
  </div>
</template>
