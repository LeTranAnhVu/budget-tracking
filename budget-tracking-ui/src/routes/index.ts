import AddExpense from '@/pages/AddExpense.vue'
import Categories from '@/pages/Categories.vue'
import EditExpense from '@/pages/EditExpense.vue'
import Login from '@/pages/Login.vue'
import { createRouter, createWebHashHistory } from 'vue-router'

const routes = [
  { path: '/', component: AddExpense },
  { path: '/edit-expense/:id', component: EditExpense },
  { path: '/categories', component: Categories },
  { path: '/login', component: Login },
]

export const router = createRouter({
  history: createWebHashHistory(),
  routes,
})
