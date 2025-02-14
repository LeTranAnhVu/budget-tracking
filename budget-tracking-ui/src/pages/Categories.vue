<script setup lang="ts">
import type SupCategoryDto from '@/models/SupCategoryDto'
import SlimItem from '@/components/SlimItem.vue'
import { CURRENCY } from '@/constants'
import toCurrency from '@/helpers/toCurrency'
import { useAppStore } from '@/stores/appStore'
import { useSupCategoriesStore } from '@/stores/supCategoriesStore'
import { computed, onMounted, ref } from 'vue'

const supCategories = ref<SupCategoryDto[]>([])
const appStore = useAppStore()
const allTransactions = computed(() => {
  let result = []
  let totalAmount = 0
  let totalNoTrxs = 0
  for (const sup of supCategories.value) {
    const expenses = sup.categories.flatMap(c => c.expenses)
    const amount = expenses.reduce((acc, exp) => acc + exp.amount, 0)

    totalNoTrxs += expenses.length
    totalAmount += amount

    result.push({
      name: sup.name,
      noOfTrxs: expenses.length,
      amount,
      transactions: sup.categories.map(cat => ({ name: cat.name, amount: cat.expenses.reduce((acc, ex) => acc + ex.amount, 0) })),
    })
  }

  result = result.filter(r => r.amount !== 0)

  // Total
  result.push({
    name: 'Total',
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

async function loadData(): Promise<void> {
  appStore.isLoading = true
  supCategories.value = await appStore.getApi().get<SupCategoryDto[]>('/supCategories/withTransactions')
  appStore.isLoading = false
}

onMounted(async () => {
  await loadData()
})
</script>

<template>
  <div>
    <div class="flex flex-col gap-8">
      <div v-if="allTransactions.length">
        <div class="flex justify-between">
          <div>
            <h2 class="text-xl font-bold flex items-center">
              All
            </h2>
            <span class="font-normal text-xs text-[#636e88]">({{ toNoOfTrxText(allTransactions[allTransactions.length - 1]?.noOfTrxs) }})</span>
          </div>

          <div>
            <p class="text-lg font-medium">
              {{ `${CURRENCY} ${allTransactions[allTransactions.length - 1]?.amount.toFixed(2)}` }}
            </p>
          </div>
        </div>
        <div class="mt-2">
          <div
            v-for="(item, index) in allTransactions.slice(0, -1)"
            :key="index"
          >
            <SlimItem
              :title="item.name"
              :description="toNoOfTrxText(item.noOfTrxs)"
              :side-text="toCurrency(item.amount)"
              @click="handleClick(`all_${item.name}`)"
            />

            <div
              v-if="openedCategoryIndex === `all_${item.name}`"
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
