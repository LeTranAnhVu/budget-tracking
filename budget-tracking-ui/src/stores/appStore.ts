import { APP_ACCESS_TOKEN } from '@/constants'
import { ApiService } from '@/services/ApiService'
import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useAppStore = defineStore('app', () => {
  const apiService = ref<ApiService | null>(null)

  function initializeApi(baseUrl: string, handleUnauthorized?: () => void): void {
    apiService.value = new ApiService(baseUrl, APP_ACCESS_TOKEN, handleUnauthorized)
  }

  function getApi(): ApiService {
    if (!apiService.value) {
      throw new Error('ApiService not initialized')
    }
    return apiService.value as ApiService
  }

  return {
    initializeApi,
    getApi,
  }
})
