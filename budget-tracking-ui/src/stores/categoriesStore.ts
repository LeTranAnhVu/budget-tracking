import type CategoryDto from '@/models/CategoryDto'
import { defineStore } from 'pinia'
import { ref } from 'vue'
import { useAppStore } from './appStore'

export const useCategoriesStore = defineStore('categories', () => {
  const categories = ref<CategoryDto[]>([])
  const appStore = useAppStore()

  async function loadCategories(): Promise<void> {
    categories.value = await appStore.getApi().get('/categories')
  }

  return {
    categories,
    loadCategories,
  }
})
