<script lang="ts" setup>
import HamIcon from '@/components/icons/HamIcon.vue'
import { routeNames } from '@/routes'
import { onClickOutside } from '@vueuse/core'
import { ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import Divider from '../Divider.vue'
import LogoutIcon from '../icons/LogoutIcon.vue'

const route = useRoute()
const router = useRouter()

const isOpen = ref(false)
const drawerRef = ref<HTMLDivElement | null>(null)

// Update navigation items to use route names and meta titles
const navItems = [
  {
    name: routeNames.expenses,
    displayName: 'Expenses',
    icon: `<svg xmlns="http://www.w3.org/2000/svg" class="w-5 h-5" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
            <path d="M9 17h6m-6-4h6m-6-4h6M5 21h14a2 2 0 002-2V5a2 2 0 00-2-2H5a2 2 0 00-2 2v14a2 2 0 002 2z"/>
          </svg>`,
  },
  {
    name: routeNames.addExpense,
    displayName: 'Add Expense',
    icon: `<svg xmlns="http://www.w3.org/2000/svg" class="w-5 h-5" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
            <path d="M12 4v16m-8-8h16"/>
          </svg>`,
  },
  {
    name: routeNames.categories,
    displayName: 'Categories',
    icon: `<svg xmlns="http://www.w3.org/2000/svg" class="w-5 h-5" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
            <path d="M4 6h16M4 12h16M4 18h16"/>
          </svg>`,
  },
  {
    name: routeNames.statistic,
    displayName: 'Statistic',
    icon: `<svg xmlns="http://www.w3.org/2000/svg" class="w-5 h-5" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
            <path d="M16 8v12M12 4v16M8 12v8"/>
          </svg>`,
  },
]

// Add navigation handler
function handleNavigation(routeName: string): void {
  router.push({ name: routeName })
  isOpen.value = false
}

function handleLogout(): void {
  // Add your logout logic here
  router.push({ name: routeNames.login })
  isOpen.value = false
}

function toggle(): void {
  isOpen.value = !isOpen.value
}

onClickOutside(drawerRef, (_) => {
  if (isOpen.value) {
    isOpen.value = false
  }
})
</script>

<template>
  <div class="header-container flex justify-between items-center px-10 py-12">
    <button
      class="w-6 h-6"
      @click="toggle"
    >
      <HamIcon />
    </button>

    <h1 class="text-2xl font-bold text-center text-gray-800">
      {{ route.meta.title?.toString()?.toUpperCase() }}
    </h1>
  </div>
  <div
    ref="drawerRef"
    class="drawer fixed bg-gray-900 w-[200px] h-screen top-0 z-30 transition-all ease-in-out duration-150"
    :class="isOpen ? 'left-0' : '-left-[200px]'"
  >
    <nav class="pt-24 px-4 flex-grow mb-5 text-white">
      <ul class="space-y-4">
        <li
          v-for="item in navItems"
          :key="item.name"
        >
          <button
            class="w-full text-left px-4 py-2 rounded-lg hover:bg-gray-300/30 transition-colors flex items-center gap-3"
            :class="{ 'font-bold': route.name === item.name }"
            @click="handleNavigation(item.name)"
          >
            <span v-html="item.icon" />
            {{ item.displayName }}
          </button>
        </li>
      </ul>
    </nav>

    <Divider />
    <!-- Logout section at bottom -->
    <div class="px-4 pt-6">
      <button
        class="w-full text-left px-4 py-2 rounded-lg text-red-400 transition-colors flex items-center gap-3"
        @click="handleLogout"
      >
        <LogoutIcon class="w-5 h-5" />
        Logout
      </button>
    </div>
  </div>
</template>

<style scoped>
.header-container {
  background: linear-gradient(180deg,
    rgba(255, 255, 255, 0.95) 0%,
    rgba(255, 255, 255, 0.85) 100%
  );
  backdrop-filter: blur(8px);
  -webkit-backdrop-filter: blur(8px); /* For Safari support */
  position: sticky;
  top: 0;
  z-index: 10;
}
</style>
