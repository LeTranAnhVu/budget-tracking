<script setup lang="ts">
import Divider from '@/components/Divider.vue'
import SlimItem from '@/components/SlimItem.vue'
import { CURRENCY } from '@/constants'
import { computed } from 'vue'

const ingredients = [
  { id: 1, amount: 10.5, name: 'milk' },
  { id: 2, amount: 123.12, name: 'diesel' },
  { id: 3, amount: 11.5, name: 'sugar' },
  { id: 4, amount: 34.5, name: 'toppings' },
]

const packaging = [
  { id: 5, amount: 10.0, name: 'cups' },
  { id: 6, amount: 21.32, name: 'cones' },
  { id: 7, amount: 3.0, name: 'napkins' },
  { id: 8, amount: 12.3, name: 'spoons' },
]

const fuel = [
  { id: 9, amount: 35.45, name: 'gasoline' },
  { id: 10, amount: 0.0, name: 'diesel' },
]

const maintaince = [
  { id: 11, amount: 1045.5, name: 'repairs' },
  { id: 12, amount: 8.6, name: 'servicing' },
]

const categories = {
  ingredients,
  packaging,
  fuel,
  maintaince,
}

const calcCategories = computed(() => {
  const result = []
  let totalAmount = 0
  let totalNoTrxs = 0
  for (const [key, childrenCategories] of Object.entries(categories)) {
    const catLen = childrenCategories.length
    const amount = childrenCategories.reduce((acc, cat) => acc + cat.amount, 0)

    totalNoTrxs += catLen
    totalAmount += amount

    result.push({
      title: key,
      noOfTrxs: catLen,
      amount,
    })
  }

  // Total
  result.push({
    title: 'Total',
    noOfTrxs: totalNoTrxs,
    amount: totalAmount,
  })

  return result
})

function toNoOfTrxText(noOfTrx: number): string {
  const suffix = noOfTrx === 1 ? 'transaction' : 'transactions'
  return `${noOfTrx === 0 ? 'No' : noOfTrx} ${suffix}`
}
</script>

<template>
  <div class="pt-4">
    <div class="relative">
      <h1 class="text-2xl font-bold text-center">
        Categories
      </h1>
    </div>
    <div class="mt-10 flex flex-col gap-8">
      <div>
        <div class="flex justify-between">
          <div>
            <h2 class="text-xl font-bold flex items-center">
              This week
            </h2>
            <span class="font-normal text-xs text-[#636e88]">({{ toNoOfTrxText(calcCategories[calcCategories.length - 1]?.noOfTrxs) }})</span>
          </div>

          <div>
            <p class="text-lg font-medium">
              {{ `${CURRENCY} ${calcCategories[calcCategories.length - 1]?.amount.toFixed(2)}` }}
            </p>
          </div>
        </div>
        <div class="mt-2">
          <SlimItem
            v-for="(item, index) in calcCategories.slice(0, -1)"
            :key="index"
            :title="item.title"
            :description="toNoOfTrxText(item.noOfTrxs)"
            :side-text="`${CURRENCY} ${item.amount.toFixed(2)}`"
          />
        </div>
      </div>

      <div>
        <div class="flex justify-between">
          <div>
            <h2 class="text-xl font-bold flex items-center">
              This month
            </h2>
            <span class="font-normal text-xs text-[#636e88]">({{ toNoOfTrxText(calcCategories[calcCategories.length - 1]?.noOfTrxs) }})</span>
          </div>

          <div>
            <p class="text-lg font-medium">
              {{ `${CURRENCY} ${calcCategories[calcCategories.length - 1]?.amount.toFixed(2)}` }}
            </p>
          </div>
        </div>
        <div class="mt-2">
          <SlimItem
            v-for="(item, index) in calcCategories.slice(0, -1)"
            :key="index"
            :title="item.title"
            :description="toNoOfTrxText(item.noOfTrxs)"
            :side-text="`${CURRENCY} ${item.amount.toFixed(2)}`"
          />
        </div>
      </div>
    </div>

    <!-- <div class="flex items-center gap-4 bg-white min-h-14 justify-between">
      <p class="text-[#111318] text-base font-normal leading-normal flex-1 truncate">
        Add a new category
      </p>
      <div class="shrink-0">
        <div
          class="text-[#111318] flex size-7 items-center justify-center"
          data-icon="Plus"
          data-size="24px"
          data-weight="regular"
        >
          <PlusIcon />
        </div>
      </div>
    </div> -->
  </div>
</template>

<style scoped>
</style>
