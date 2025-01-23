<script setup lang="ts">
import { reactive } from 'vue'
import Button from '../components/Button.vue'
import TextInput from '../components/TextInput.vue'

const form = reactive({
  email: '',
  password: '',
})

function handleLogin(): void {
  console.error(form)
}
</script>

<template>
  <div class="pt-4">
    <h1 class="text-2xl font-bold text-center">
      Login
    </h1>
    <div class="flex flex-col items-center mt-10">
      <TextInput
        v-model="form.email"
        placeholder="Email"
      />

      <TextInput
        v-model="form.password"
        class="mt-4"
        placeholder="Password"
        is-password
      />

      <Button
        class="mt-4"
        @click="handleLogin"
      >
        Log in
      </Button>
    </div>
  </div>
</template>

<style scoped>
</style>
