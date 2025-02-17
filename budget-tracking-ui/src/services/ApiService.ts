export class ApiService {
  private baseUrl: string
  private accessTokenKey: string
  private unauthorizedCallback?: () => void

  constructor(
    baseUrl: string,
    accessTokenKey: string,
    unauthorizedCallback?: () => void,
  ) {
    this.baseUrl = baseUrl
    this.accessTokenKey = accessTokenKey
    this.unauthorizedCallback = unauthorizedCallback
  }

  private getAuthHeader(): Headers {
    const token = localStorage.getItem(this.accessTokenKey)
    const headers = new Headers({
      'Content-Type': 'application/json',
    })

    if (token) {
      headers.append('Authorization', `Bearer ${token}`)
    }

    return headers
  }

  private async handleResponse<T>(response: Response): Promise<T> {
    if (!response.ok) {
      if (response instanceof Response && (response.status === 401 || response.status === 403)) {
        this.unauthorizedCallback?.()
      }
      throw response
    }

    // Check if there's content to parse
    const contentType = response.headers.get('content-type')
    if (contentType && contentType.includes('application/json')) {
      return await response.json()
    }

    // Return null for no-content responses
    return null as T
  }

  async get<T>(endpoint: string): Promise<T> {
    const response = await fetch(`${this.baseUrl}${endpoint}`, {
      method: 'GET',
      headers: this.getAuthHeader(),
    })
    return await this.handleResponse<T>(response)
  }

  async post<T>(endpoint: string, data: any): Promise<T> {
    const response = await fetch(`${this.baseUrl}${endpoint}`, {
      method: 'POST',
      headers: this.getAuthHeader(),
      body: JSON.stringify(data),
    })
    return await this.handleResponse<T>(response)
  }

  async put<T>(endpoint: string, data: any): Promise<T> {
    const response = await fetch(`${this.baseUrl}${endpoint}`, {
      method: 'PUT',
      headers: this.getAuthHeader(),
      body: JSON.stringify(data),
    })
    return await this.handleResponse<T>(response)
  }

  async delete<T>(endpoint: string): Promise<T> {
    const response = await fetch(`${this.baseUrl}${endpoint}`, {
      method: 'DELETE',
      headers: this.getAuthHeader(),
    })
    return await this.handleResponse<T>(response)
  }
}
