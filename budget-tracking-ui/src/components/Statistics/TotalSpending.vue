<script setup lang="ts">
import type ExpenseDto from '@/models/ExpenseDto'
import LineChartGradient from '@/components/charts/LineChart.vue'
import { MONTHS } from '@/constants'
import { getThreeLetterMonth } from '@/helpers/dateUtils'
import toCurrency from '@/helpers/toCurrency'
import { computed } from 'vue'

const props = defineProps<{
  expenses: ExpenseDto[]
}>()

const totalAmount = computed(() => {
  return props.expenses.reduce((acc, ex) => acc + ex.amount, 0)
})

const accummulatedAmounts = computed<number[]>(() => {
  const aggre = props.expenses.reduce((acc, ex) => {
    const month = getThreeLetterMonth(ex.paidDate)
    if (!acc[month]) {
      acc[month] = 0
    }

    acc[month] += ex.amount
    return acc
  }, {} as Record<string, number>)

  let acc = 0
  return MONTHS.map((mo) => {
    acc += aggre[mo] || 0
    return acc
  })
})
</script>

<template>
  <div>
    <h2 class="font-bold text-gray-800 mb-2">
      Total spending
    </h2>
    <div>
      <p class="font-bold text-gray-700 text-3xl mb-3">
        {{ toCurrency(totalAmount) }}
      </p>
      <LineChartGradient
        color="red"
        label="Expense"
        :y="[...accummulatedAmounts]"
        :x="[...MONTHS]"
      />
    </div>
  </div>
</template>
