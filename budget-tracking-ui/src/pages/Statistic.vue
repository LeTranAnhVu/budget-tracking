<script setup lang="ts">
import DaySpending from '@/components/Statistics/DaySpending.vue'
import MonthlySpending from '@/components/Statistics/MonthlySpending.vue'
import TotalSpending from '@/components/Statistics/TotalSpending.vue'
</script>

<template>
  <div class="pt-4">
    <div class="relative">
      <h1 class="text-2xl font-bold text-center text-gray-700">
        Statistic
      </h1>
    </div>
    <div class="flex flex-col gap-20 mt-5">
      <div>
        <TotalSpending />
      </div>

      <div>
        <MonthlySpending />
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
