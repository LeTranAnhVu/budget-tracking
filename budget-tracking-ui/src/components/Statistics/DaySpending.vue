<script setup lang="ts">
import type SupCategoryDto from '@/models/SupCategoryDto'
import XBar from '@/components/XBar.vue'
import toCurrency from '@/helpers/toCurrency'
import { useAppStore } from '@/stores/appStore'
import { computed, onMounted, ref } from 'vue'

const props = defineProps<{
  days: number
}>()

const appStore = useAppStore()
const loadedData = ref(false)
const supCategories = ref<SupCategoryDto[]>([])
const data = computed(() => {
  return supCategories.value.map((sup) => {
    return {
      name: sup.name,
      value: sup.categories.flatMap(c => c.expenses).reduce((acc, ex) => acc + ex.amount, 0),
    }
  }).filter(d => d.value !== 0)
})
const mostSpendingAmount = computed(() => {
  return Math.max(...data.value.map(i => i.value))
})

const totalAmount = computed(() => {
  return data.value.reduce((acc, current) => acc + current.value, 0)
})

async function loadData(): Promise<void> {
  supCategories.value = await appStore.getApi().get<SupCategoryDto[]>(`/sup-categories/with-transactions?daysAgo=${props.days}`)
  loadedData.value = true
}

function calcRatio(value: number): number {
  return mostSpendingAmount.value !== 0 ? value / mostSpendingAmount.value : 0
}

function random100(): number {
  return Math.floor(Math.random() * 500 + 100)
}

onMounted(async () => {
  await loadData()
})
</script>

<template>
  <div>
    <p class="font-bold text-gray-700 text-3xl mb-3">
      {{ toCurrency(totalAmount) }}
    </p>
    <p class="font-sm font-medium text-gray-400 text-sm">
      Last {{ days }} days
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
