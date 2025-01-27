<script setup lang="ts">
import StatisticByDays from '@/components/StatisticByDays.vue'
</script>

<template>
  <div class="pt-4">
    <div class="relative">
      <h1 class="text-2xl font-bold text-center text-gray-700">
        Statistic
      </h1>
    </div>
    <div class="mt-6">
      <h2 class="text-lg font-bold text-gray-800 mb-5">
        By Category
      </h2>
      <div class="flex flex-col gap-15">
        <StatisticByDays :days="5"/>
        <StatisticByDays :days="30"/>
        <StatisticByDays :days="100"/>
      </div>
    </div>
  </div>
</template>

<style scoped>
</style>
