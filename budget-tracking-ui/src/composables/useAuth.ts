import { APP_ACCESS_TOKEN } from '@/constants'
import { useAppStore } from '@/stores/appStore'

interface UseAuthReturn {
  login: (email: string, password: string) => Promise<void>
  logout: () => void
  isAuthenticated: () => boolean
}

export function useAuth(): UseAuthReturn {
  const appStore = useAppStore()

  function isAuthenticated(): boolean {
    return !!(localStorage.getItem(APP_ACCESS_TOKEN))
  }

  async function login(email: string, password: string): Promise<void> {
    const accessToken = await appStore.getApi().post<string>('/auth/login', { email, password })
    if (accessToken) {
      localStorage.setItem(APP_ACCESS_TOKEN, accessToken)
    }
  }

  function logout(): void {
    localStorage.removeItem(APP_ACCESS_TOKEN)
  }

  return { login, logout, isAuthenticated }
}
