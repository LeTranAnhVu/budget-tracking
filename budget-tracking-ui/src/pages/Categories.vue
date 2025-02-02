<script setup lang="ts">
import SlimItem from '@/components/SlimItem.vue'
import { CURRENCY } from '@/constants'
import toCurrency from '@/helpers/toCurrency'
import { computed, ref } from 'vue'

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
      transactions: childrenCategories,
    })
  }

  // Total
  result.push({
    title: 'Total',
    noOfTrxs: totalNoTrxs,
    amount: totalAmount,
    transactions: [],
  })

  return result
})

function toNoOfTrxText(noOfTrx: number): string {
  const suffix = noOfTrx === 1 ? 'transaction' : 'transactions'
  return `${noOfTrx === 0 ? 'No' : noOfTrx} ${suffix}`
}

const openedCategoryIndex = ref<string | null>(null)
function handleClick(id: string): void {
  if (openedCategoryIndex.value === id) {
    openedCategoryIndex.value = null
  } else {
    openedCategoryIndex.value = id
  }
}
</script>

<template>
  <div>
    <div class="flex flex-col gap-8">
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
          <div
            v-for="(item, index) in calcCategories.slice(0, -1)"
            :key="index"
          >
            <SlimItem
              :title="item.title"
              :description="toNoOfTrxText(item.noOfTrxs)"
              :side-text="toCurrency(item.amount)"
              @click="handleClick(`this_week_${item.title}`)"
            />

            <div
              v-if="openedCategoryIndex === `this_week_${item.title}`"
              class="pl-2 text-[#636e88] flex flex-col gap-3 mb-5"
            >
              <div
                v-for="(trx, trxInd) in item.transactions"
                :key="trxInd"
                class="flex flex-nowrap items-center justify-between"
              >
                <span>{{ trx.name }}</span><span>{{ toCurrency(trx.amount, false) }}</span>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
</style>
