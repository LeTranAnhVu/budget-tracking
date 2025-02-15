<script setup lang="ts">
import type ExpenseDto from '@/models/ExpenseDto'
import ExpenseCard from '@/components/ExpenseCard.vue'
import FilterTags from '@/components/FilterTags.vue'
import PlusIcon from '@/components/icons/PlusIcon.vue'
import toCurrency from '@/helpers/toCurrency'
import { routeNames } from '@/routes'
import { useAppStore } from '@/stores/appStore'
import { computed, onMounted, ref, watch } from 'vue'
import { useRouter } from 'vue-router'
import { useSupCategoriesStore } from '@/stores/supCategoriesStore'

const appStore = useAppStore()
const { getApi } = useAppStore()
const selectedDate = ref('all-time')
const selectedCategory = ref(-1)

const dateOptions = [
  { id: 'all-time', name: 'All Time', value: null },
  { id: 'today', name: 'Today', value: 1 },
  { id: 'this-week', name: 'This Week', value: 7 },
  { id: 'last-7-days', name: 'Last 7 Days', value: 7 },
  { id: 'this-month', name: 'This Month', value: 30 },
]
const expenses = ref<ExpenseDto[]>([])
const router = useRouter()

const availableCategoryIds = ref<number[]>([])
const supCategoryOptions = ref<{id: number, name: string}[]>([]) 

function getAvailableCategoryIds(): number[] {
  const raw = expenses.value.reduce((acc, ex) => {
    if(!acc[ex.categoryId]){
        acc[ex.categoryId] = 1
    }
    return acc
  }, {} as Record<number, number>)

  return Object.keys(raw).map(Number)
}

function getSupCatetoryOptions (): {id: number, name: string}[] {
  const result = useSupCategoriesStore().supCategories.filter(sup => {
    return sup.categories.find(cat => availableCategoryIds.value.includes(cat.id))
  }).map((s) => {
    return {id: s.id, name: s.name}
  })

  result.unshift({id: -1, name: 'All'})

  return result
}
const totalAmount = computed(() => {
  const sum = expenses.value.reduce((acc, c) => acc + c.amount, 0)
  return toCurrency(sum)
})
function handleEdit(id: number): void {
  router.push({ name: routeNames.editExpense, params: { id } })
}

async function handleDelete(id: number): Promise<void> {
  await getApi().delete(`/expenses/${id}`)

  await loadData()
}

function addExpense(): void {
  router.push({ name: routeNames.addExpense })
}

onMounted(async () => {
  await loadData()
  availableCategoryIds.value = getAvailableCategoryIds()
  supCategoryOptions.value = getSupCatetoryOptions()
})

function buildQueryParam(): string {
  let params = ''
  const selectedDaysAgo = dateOptions.find(o => o.id === selectedDate.value)?.value

  if (selectedDaysAgo) {
    params += `daysAgo=${selectedDaysAgo}`
  }

  if(selectedCategory.value !== -1) {
    const supCategoryId = supCategoryOptions.value.find(o => o.id === selectedCategory.value)?.id
    if(supCategoryId) {
      params += `supCategoryId=${supCategoryId}`

    }
  }
  return params ? `?${params}` : ''
}

watch([selectedDate, selectedCategory], async () => {
  await loadData()
})

async function loadData(): Promise<void> {
  appStore.isLoading = true
  const params = buildQueryParam()
  expenses.value = await getApi().get(`/expenses${params}`)
  appStore.isLoading = false
}
</script>

<template>
  <div class="p-4 pt-0 min-h-screen">
    <!-- Header Section -->
    <div class="mb-6">
      <!-- Date Range Tags -->
      <FilterTags
        v-model="selectedDate"
        :options="dateOptions"
      />
      <!-- Category Tags -->
      <FilterTags
        v-model="selectedCategory"
        :options="supCategoryOptions"
      />
    </div>

    <!-- Total Amount Card -->
    <div class="bg-white rounded-2xl p-4 shadow mb-4">
      <div class="flex justify-between items-center">
        <span class="text-gray-600">Total Expenses</span>
        <span class="text-xl font-bold text-gray-800">{{ totalAmount }}</span>
      </div>
    </div>

    <!-- Expenses List -->
    <div class="space-y-4">
      <ExpenseCard
        v-for="expense in expenses"
        :key="expense.id"
        :expense="expense"
        @edit="() => handleEdit(expense.id)"
        @delete="handleDelete(expense.id)"
      />
    </div>

    <!-- Floating Add Button -->
    <button
      class="fixed bottom-6 right-6 w-14 h-14 rounded-full bg-gray-800 text-white shadow-lg flex items-center justify-center"
      @click="addExpense"
    >
      <PlusIcon />
    </button>
  </div>
</template>

<style scoped>
</style>
