import { createRouter, createWebHashHistory } from 'vue-router'

import Login from '../pages/Login.vue'
import Page1 from '../pages/Page1.vue'

const routes = [
  { path: '/', component: Page1 },
  { path: '/login', component: Login },
]

export const router = createRouter({
  history: createWebHashHistory(),
  routes,
})
