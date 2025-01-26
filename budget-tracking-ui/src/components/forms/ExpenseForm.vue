<script setup lang="ts">
import Badge from '@/components/Badge.vue'
import Collapse from '@/components/Collapse.vue'
import DateInput from '@/components/DateInput.vue'
import DateIcon from '@/components/icons/DateIcon.vue'
import MoneyIcon from '@/components/icons/MoneyIcon.vue'
import NumericInput from '@/components/NumericInput.vue'
import SingleSelector, { type SingleSelectorItem } from '@/components/SingleSelector/SingleSelector.vue'
import TextArea from '@/components/TextArea.vue'
import { CURRENCY } from '@/constants'
import type CategoryDto from '@/models/CategoryDto'
import { computed } from 'vue'

const props = defineProps<{
  categories : Record<string, CategoryDto[]>
}>()

const form = defineModel<{
  amount: number
  date: string
  notes: string
  categoryId: number
}>({required: true})


const mappedCategories = computed<Record<string, SingleSelectorItem[]>>(() => {
  let result:Record<string, SingleSelectorItem[]> = {}
  for (const [key, childrenCategories] of Object.entries(props.categories)) {
    result[key] = childrenCategories.map(c => ({name: c.name, value: c.id} as SingleSelectorItem))
  }

  return result
})

const selectedCategory = computed<CategoryDto | null>(() => {
  const items = Object.values(props.categories).flat()
  return items.find(item => form.value.categoryId === item.id) || null
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
          <div class="px-3 bg-[#f0f2f4] rounded-xl">
            <div class="">
              <template
                v-for="(childCategories, key) in mappedCategories"
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
