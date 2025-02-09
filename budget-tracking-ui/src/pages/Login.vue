<script setup lang="ts">
import { useAuth } from '@/composables/useAuth'
import { routeNames } from '@/routes'
import { reactive } from 'vue'
import { useRouter } from 'vue-router'
import Button from '../components/Button.vue'
import TextInput from '../components/TextInput.vue'
import LoginIllustration from '/login-illustration.svg'

const { login } = useAuth()
const router = useRouter()
const form = reactive({
  email: '',
  password: '',
  error: '',
})

function validate(): boolean {
  let errorCode = 0
  if (!form.email) {
    errorCode += 1
  }

  if (!form.password) {
    errorCode += 2
  }

  if (errorCode === 1) {
    form.error = 'Email is required'
  } else if (errorCode === 2) {
    form.error = 'Password is required'
  } else if (errorCode > 2) {
    form.error = 'Email and password are required'
  }

  return errorCode === 0
}

async function handleLogin(): Promise<void> {
  try {
    if (validate()) {
      await login(form.email, form.password)
      router.push({ name: routeNames.home })
    }
  } catch {
    form.error = 'Invalid email or password'
  }
}
</script>

<template>
  <div class="pt-30 text-gray-800">
    <h1 class="text-3xl font-bold text-center">
      Welcome back
    </h1>
    <p class="text-center text-gray-600 mt-2">
      Login to access you account
    </p>
    <div class="flex flex-col items-center mt-10 max-w-md mx-auto">
      <img
        :src="LoginIllustration"
        alt="Login illustration"
        class="w-64 mb-8"
      >

      <p
        v-if="form.error"
        class="text-red-600 text-sm mb-4 text-center"
      >
        {{ form.error }}
      </p>

      <TextInput
        v-model="form.email"
        placeholder="Email"
      />

      <TextInput
        v-model="form.password"
        class="mt-6"
        placeholder="Password"
        is-password
      />

      <Button
        class="mt-7"
        @click="handleLogin"
      >
        Log in
      </Button>
    </div>
  </div>
</template>

<style scoped>
</style>
