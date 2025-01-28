<script setup lang="ts">
import LineChartGradient from '@/components/LineChartGradient.vue'
import StatisticByDays from '@/components/StatisticByDays.vue'
import toCurrency from '@/helpers/toCurrency'

const totalAmount = 12000
</script>

<template>
  <div class="pt-4">
    <div class="relative">
      <h1 class="text-2xl font-bold text-center text-gray-700">
        Statistic
      </h1>
    </div>
    <div class="mt-6">
      <div>
        <h2 class="text-lg font-bold text-gray-800 mb-5">
          Total spending
        </h2>
        <div>
          <p class="font-bold text-gray-700 text-3xl mb-3">
            {{ toCurrency(totalAmount) }}
          </p>
          <LineChartGradient
            label="Expense"
            :y="[1, 12, 24, 43, 16, 43]"
            :x="['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun']"
          />
        </div>
      </div>
    </div>

    <div>
      <h2 class="text-lg font-bold text-gray-800 mb-5">
        By Category
      </h2>
      <div class="flex flex-col gap-15">
        <StatisticByDays :days="5" />
        <StatisticByDays :days="30" />
      </div>
    </div>
  </div>
</template>

<style scoped>
</style>
