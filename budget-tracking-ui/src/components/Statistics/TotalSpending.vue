<script setup lang="ts">
import LineChartGradient from '@/components/charts/LineChart.vue'
import toCurrency from '@/helpers/toCurrency'

const totalAmount = 12000
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
        :y="[1, 12, 24, 43, 16, 43]"
        :x="['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun']"
      />
    </div>
  </div>
</template>
