<script setup lang="ts">
import Badge from '@/components/Badge.vue'
import Collapse from '@/components/Collapse.vue'
import DateInput from '@/components/DateInput.vue'
import DateIcon from '@/components/icons/DateIcon.vue'
import MoneyIcon from '@/components/icons/MoneyIcon.vue'
import NumericInput from '@/components/NumericInput.vue'
import TextArea from '@/components/TextArea.vue'
import { CURRENCY } from '@/constants'
import { computed, reactive } from 'vue'
import SingleSelector from './SingleSelector/SingleSelector.vue'

const ingredients = [
  { value: 1, name: 'milk' },
  { value: 2, name: 'diesel' },
  { value: 3, name: 'sugar' },
  { value: 4, name: 'toppings' },
]

const packaging = [
  { value: 5, name: 'cups' },
  { value: 6, name: 'cones' },
  { value: 7, name: 'napkins' },
  { value: 8, name: 'spoons' },
]

const fuel = [
  { value: 9, name: 'gasoline' },
  { value: 10, name: 'diesel' },
]

const maintaince = [
  { value: 11, name: 'repairs' },
  { value: 12, name: 'servicing' },
]

const categories = {
  ingredients,
  packaging,
  fuel,
  maintaince,
}

const form = reactive({
  amount: 0,
  date: Date,
  notes: '',
  categoryId: 1,
})

const selectedCategory = computed<{ value: number, name: string } | null>(() => {
  const items = Object.values(categories).flat()
  return items.find(item => form.categoryId === item.value) || null
})
</script>

<template>
  <div>
    <NumericInput
      v-model="form.amount"
      :symbol="CURRENCY"
      label="Amount"
    >
      <template #icon>
        <MoneyIcon />
      </template>
    </NumericInput>

    <div class="relative">
      <Badge
        v-if="selectedCategory?.name"
        class="absolute top-4 left-26"
        :content="selectedCategory?.name"
      />
      <div>
        <Collapse
          title="Categories"
          :initial-open="true"
        >
          <div class="px-2">
            <div class="bg-[#f0f2f4] rounded-xl">
              <template
                v-for="(childCategories, key) in categories"
                :key="key"
              >
                <Collapse :title="key">
                  <SingleSelector
                    id="category"
                    v-model="form.categoryId"
                    :items="childCategories"
                  />
                </Collapse>
              </template>
            </div>
          </div>
        </Collapse>
      </div>
    </div>

    <DateInput
      v-model="form.date"
      label="Date"
    >
      <template #icon>
        <DateIcon />
      </template>
    </DateInput>
    <TextArea
      v-model="form.notes"
      label="Note"
      placeholder="Add notes"
    />
  </div>
</template>
