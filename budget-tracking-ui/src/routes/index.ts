import AddExpense from '@/pages/AddExpense.vue'
import { createRouter, createWebHashHistory } from 'vue-router'
import Login from '../pages/Login.vue'

const routes = [
  { path: '/', component: AddExpense },
  { path: '/login', component: Login },
]

export const router = createRouter({
  history: createWebHashHistory(),
  routes,
})
