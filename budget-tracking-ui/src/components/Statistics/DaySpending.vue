<script setup lang="ts">
import XBar from '@/components/XBar.vue'
import toCurrency from '@/helpers/toCurrency'
import { computed, onMounted, ref } from 'vue'

defineProps<{
  days: number
}>()

const initialValue = 0
const loadedData = ref(false)
const changedPercent = -12
const data = ref([
  { name: 'Ingredients', value: initialValue },
  { name: 'Packaging', value: initialValue },
  { name: 'Fuel', value: initialValue },
  { name: 'Maintaince', value: initialValue },
])

const mostSpendingAmount = computed(() => {
  return Math.max(...data.value.map(i => i.value))
})

const totalAmount = computed(() => {
  return data.value.reduce((acc, current) => acc + current.value, 0)
})

function loadData(): void {
  setTimeout(() => {
    data.value = [
      { name: 'Ingredients', value: 105.32 },
      { name: 'Packaging', value: 235.4 },
      { name: 'Fuel', value: 200.6 },
      { name: 'Maintaince', value: 590.8 },
    ]
    loadedData.value = true
  }, 1000)
}

function calcRatio(value: number): number {
  return mostSpendingAmount.value !== 0 ? value / mostSpendingAmount.value : 0
}

function random100(): number {
  return Math.floor(Math.random() * 500 + 100)
}

function presentNumberWithIndicator(numb: number): string {
  const symbol = numb > 0 ? '+' : ''
  return symbol + numb.toString()
}
onMounted(() => {
  loadData()
})
</script>

<template>
  <div>
    <p class="font-bold text-gray-700 text-3xl mb-3">
      {{ toCurrency(totalAmount) }}
    </p>
    <p class="font-sm font-medium text-gray-400 text-sm">
      Last {{ days }} days
      <span :class="changedPercent < 0 ? 'text-green-600' : changedPercent > 0 ? 'text-red-600' : '' ">{{ presentNumberWithIndicator(changedPercent) }}%</span>
    </p>
    <div class="flex flex-col gap-4 mt-5">
      <div
        v-for="(item, index) in data"
        :key="index"
      >
        <div class="grid grid-cols-[25%_75%] font-bold text-gray-500">
          <p class="text-sm">
            {{ item.name }}
          </p>
          <div>
            <XBar
              :process="calcRatio(item.value)"
              :delay="random100()"
              :is-show-info="loadedData"
              :info="item.value.toFixed(2)"
            />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
</style>
