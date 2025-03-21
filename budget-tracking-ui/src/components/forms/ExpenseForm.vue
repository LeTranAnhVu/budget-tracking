<script setup lang="ts">
import type CategoryDto from '@/models/CategoryDto'
import type { InputExpenseDto } from '@/models/InputExpenseDto'
import Badge from '@/components/Badge.vue'
import Collapse from '@/components/Collapse.vue'
import DateInput from '@/components/DateInput.vue'
import DateIcon from '@/components/icons/DateIcon.vue'
import MoneyIcon from '@/components/icons/MoneyIcon.vue'
import TaxIcon from '@/components/icons/TaxIcon.vue'
import NumericInput from '@/components/NumericInput.vue'
import SingleSelector, { type SingleSelectorItem } from '@/components/SingleSelector/SingleSelector.vue'
import SingleSelectorCreateForm from '@/components/SingleSelector/SingleSelectorCreateForm.vue'
import Switch from '@/components/Switch.vue'
import TextArea from '@/components/TextArea.vue'
import { CURRENCY } from '@/constants'
import { useSupCategoriesStore } from '@/stores/supCategoriesStore'
import { computed, watch } from 'vue'

const emit = defineEmits<{
  newCategorySave: [value: string, supCategoryId: number]
}>()

const supCategoryStore = useSupCategoriesStore()

const form = defineModel<InputExpenseDto>('expenseForm', { required: true })

const supCategories = computed(() => supCategoryStore.supCategories)

const mappedCategories = computed < Record<string, { id: number, categories: SingleSelectorItem[] }>>(() => {
  const result: Record<string, { id: number, categories: SingleSelectorItem[] }> = {}
  for (const supCategory of supCategories.value) {
    result[supCategory.name] = {
      id: supCategory.id,
      categories: supCategory.categories.map(c => ({ name: c.name, value: c.id } as SingleSelectorItem)),
    }
  }

  return result
})

const selectedCategory = computed<CategoryDto | null>(() => {
  const categories = supCategories.value.flatMap(item => item.categories)
  return categories.find(category => form.value.categoryId === category.id) || null
})

watch(() => form.value.includedTax, () => {
  form.value.vat = form.value.includedTax ? 0 : null
})

function saveNewCategory(value: string, supCategoryId: number): void {
  emit('newCategorySave', value, supCategoryId)
}
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

    <Switch
      v-model="form.includedTax"
      class="mt-4"
      label="Include tax"
    />

    <NumericInput
      v-if="form.includedTax"
      v-model="form.vat"
      class="mt-2"
      symbol="%"
      label="Tax (%)"
    >
      <template #icon>
        <TaxIcon />
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
                v-for="(supCategory, key) in mappedCategories"
                :key="key"
              >
                <Collapse :title="key">
                  <div class="flex flex-row flex-wrap gap-3 p-4">
                    <SingleSelector
                      v-for="item in supCategory.categories"
                      id="category"
                      :key="item.name"
                      v-model="form.categoryId"
                      :item="item"
                    />
                    <SingleSelectorCreateForm @save="(value) => saveNewCategory(value, supCategory.id)" />
                  </div>
                </Collapse>
              </template>
            </div>
          </div>
        </Collapse>
      </div>
    </div>

    <DateInput
      v-model="form.paidDate"
      label="Date"
    >
      <template #icon>
        <DateIcon />
      </template>
    </DateInput>
    <TextArea
      v-model="form.note"
      label="Note"
      placeholder="Add notes"
    />
  </div>
</template>
