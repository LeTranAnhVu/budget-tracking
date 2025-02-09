<script setup lang="ts">
import ExpenseCard from '@/components/ExpenseCard.vue'
import FilterTags from '@/components/FilterTags.vue'
import PlusIcon from '@/components/icons/PlusIcon.vue'
import { routeNames } from '@/routes'
import { useAppStore } from '@/stores/appStore'
import { onMounted, ref } from 'vue'
import { useRouter } from 'vue-router'

const { getApi } = useAppStore()
const selectedDate = ref('today')
const selectedCategory = ref('all')

const dateOptions = [
  { id: 'today', name: 'Today' },
  { id: 'this-week', name: 'This Week' },
  { id: 'last-7-days', name: 'Last 7 Days' },
  { id: 'this-month', name: 'This Month' },
  { id: 'all-time', name: 'All Time' },
]

const categoryOptions = [
  { id: 'all', name: 'All' },
  { id: 'ingredients', name: 'Ingredients' },
  { id: 'packaging', name: 'Packaging' },
  { id: 'fuel', name: 'Fuel' },
  { id: 'maintenance', name: 'Maintenance' },
]

const router = useRouter()

function handleEdit(id: number): void {
  router.push({ name: routeNames.editExpense, params: { id } })
}

function handleDelete(): void {
}

function addExpense(): void {
  router.push({ name: routeNames.addExpense })
}

onMounted(async () => {
  await loadData()
})

async function loadData(): Promise<void> {
  const expenses = await getApi().get('/expenses')
  console.log(expenses)
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
        :options="categoryOptions"
      />
    </div>

    <!-- Total Amount Card -->
    <div class="bg-white rounded-2xl p-4 shadow mb-4">
      <div class="flex justify-between items-center">
        <span class="text-gray-600">Total Expenses</span>
        <span class="text-xl font-bold text-gray-800">$2,450.00</span>
      </div>
    </div>

    <!-- Expenses List -->
    <div class="space-y-4">
      <ExpenseCard
        date="Mar 15, 2024"
        title="Milk"
        :amount="250.00"
        description="Monthly milk supply for ice cream production"
        category="Ingredients"
        @edit="() => handleEdit(1)"
        @delete="handleDelete"
      />

      <ExpenseCard
        date="Mar 14, 2024"
        title="Cups"
        :amount="150.00"
        description="Paper cups stock replenishment"
        category="Ingredients"
        @edit="() => handleEdit(2)"
        @delete="handleDelete"
      />

      <ExpenseCard
        date="Mar 13, 2024"
        title="Repairs"
        :amount="500.00"
        description="Ice cream machine maintenance"
        category="Maintenance"
        @edit="() => handleEdit(3)"
        @delete="handleDelete"
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
