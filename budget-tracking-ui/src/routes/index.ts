import { useAuth } from '@/composables/useAuth'
import AddExpense from '@/pages/AddExpense.vue'
import Categories from '@/pages/Categories.vue'
import EditExpense from '@/pages/EditExpense.vue'
import Expenses from '@/pages/Expenses.vue'
import Login from '@/pages/Login.vue'
import Statistic from '@/pages/Statistic.vue'
import { createRouter, createWebHashHistory } from 'vue-router'

export const routeNames = {
  home: 'expenses',
  addExpense: 'addExpense',
  editExpense: 'editExpense',
  categories: 'categories',
  statistic: 'statistic',
  login: 'login',
}

const routes = [
  { path: '/', component: Expenses, name: routeNames.home, meta: { title: 'Expenses' } },
  { path: '/add-expense', component: AddExpense, name: routeNames.addExpense, meta: { title: 'Add Expense' } },
  { path: '/edit-expense/:id', component: EditExpense, name: routeNames.editExpense, meta: { title: 'Edit Expense' } },
  { path: '/categories', component: Categories, name: routeNames.categories, meta: { title: 'Categories' } },
  { path: '/statistic', component: Statistic, name: routeNames.statistic, meta: { title: 'Statistic' } },
  { path: '/login', component: Login, name: routeNames.login, meta: { title: 'Login', noHeader: true, noAuthRequired: true } },
]

export const router = createRouter({
  history: createWebHashHistory(),
  routes,
})

router.beforeEach((to, _) => {
  if (to.meta.noAuthRequired) {
    return true
  }

  if (useAuth().isAuthenticated()) {
    return true
  }

  return { name: routeNames.login }
})
