<script setup lang="ts">
import Container from './components/Container.vue'
</script>

<template>
  <div>
    <Container>
      <router-view />
    </Container>
    <div class="text-sm text-gray-500 text-center py-2">
      v1.0.0
    </div>
  </div>
</template>

<style scoped>
</style>
