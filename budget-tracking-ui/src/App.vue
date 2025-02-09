<script setup lang="ts">
import Container from '@/components/Container.vue'
import { onMounted } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import Header from './components/Header/Header.vue'
import { useAuth } from './composables/useAuth'
import { routeNames } from './routes'
import { useAppStore } from './stores/appStore'

const route = useRoute()
const router = useRouter()
const appStore = useAppStore()
const { logout } = useAuth()
function initialLoad(): void {
  const env = import.meta.env
  appStore.initializeApi(`${env.VITE_API_URL}/api`, () => {
    logout()
    router.push({ name: routeNames.login })
  })
}

onMounted(async () => {
  initialLoad()
})
</script>

<template>
  <div>
    <Header
      v-if="!route.meta.noHeader"
      class="sticky top-0 left-0 z-10 w-full"
    />
    <Container>
      <Transition
        name="fade"
        mode="out-in"
      >
        <router-view />
      </Transition>
    </Container>
    <div class="text-sm text-gray-500 text-center py-2">
      v1.0.3
    </div>
  </div>
</template>

<style scoped>
/* Fade transition */
.fade-enter-active, .fade-leave-active {
  transition: opacity 0.5s;
}
.fade-enter-from, .fade-leave-to {
  opacity: 0;
}
</style>
