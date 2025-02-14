import { APP_ACCESS_TOKEN } from '@/constants'
import { ApiService } from '@/services/ApiService'
import { watchThrottled } from '@vueuse/core'
import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useAppStore = defineStore('app', () => {
  const apiService = ref<ApiService | null>(null)
  const isLoading = ref(false)
  const throttledIsLoading = ref(false)

  watchThrottled(isLoading, () => {
    throttledIsLoading.value = isLoading.value
  }, { throttle: 500 })

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
    isLoading,
    throttledIsLoading,
    initializeApi,
    getApi,
  }
})
