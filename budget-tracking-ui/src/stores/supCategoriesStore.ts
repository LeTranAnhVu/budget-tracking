import type SupCategoryDto from '@/models/SupCategoryDto'
import { defineStore } from 'pinia'
import { ref } from 'vue'
import { useAppStore } from './appStore'

export const useSupCategoriesStore = defineStore('supCategories', () => {
  const supCategories = ref<SupCategoryDto[]>([])
  const appStore = useAppStore()

  async function loadSupCategories(): Promise<void> {
    supCategories.value = await appStore.getApi().get<SupCategoryDto[]>('/sup-categories')
  }

  return {
    supCategories,
    loadSupCategories,
  }
})
