<script setup lang="ts">
import BarChart from '@/components/charts/BarChart.vue'
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
        :y="[1, 12, 24, 43, 16, 43, 32, 56, 45, 67, 34, 11]"
        :x="['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']"
      />
    </div>
  </div>
</template>
