import { defineStore } from 'pinia'
import { ref } from 'vue'

type ToastType = 'success' | 'error'

export const useToastStore = defineStore('toast', () => {
  const show = ref(false)
  const message = ref('')
  const type = ref<ToastType>('success')

  function showToast(msg: string, toastType: ToastType = 'success'): void {
    message.value = msg
    type.value = toastType
    show.value = true
    setTimeout(() => {
      show.value = false
    }, 3000)
  }

  return {
    show,
    message,
    type,
    showToast,
  }
})
