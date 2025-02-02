<script setup lang="ts">
import { reactive } from 'vue'
import Button from '../components/Button.vue'
import TextInput from '../components/TextInput.vue'
import LoginIllustration from '/login-illustration.svg'

const form = reactive({
  email: '',
  password: '',
})

function handleLogin(): void {
  console.error(form)
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
