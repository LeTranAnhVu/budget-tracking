import AddExpense from '@/pages/AddExpense.vue'
import Categories from '@/pages/Categories.vue'
import EditExpense from '@/pages/EditExpense.vue'
import Login from '@/pages/Login.vue'
import Statistic from '@/pages/Statistic.vue'
import { createRouter, createWebHashHistory } from 'vue-router'

export const routeNames = {
  addExpense: 'addExpense',
  editExpense: 'editExpense',
  categories: 'categories',
  statistic: 'statistic',
  login: 'login',
}

const routes = [
  { path: '/', component: AddExpense, name: routeNames.addExpense, meta: { title: 'Add Expense' } },
  { path: '/edit-expense/:id', component: EditExpense, name: routeNames.editExpense, meta: { title: 'Edit Expense' } },
  { path: '/categories', component: Categories, name: routeNames.categories, meta: { title: 'Categories' } },
  { path: '/statistic', component: Statistic, name: routeNames.statistic, meta: { title: 'Statistic' } },
  { path: '/login', component: Login, name: routeNames.login, meta: { title: 'Login', noHeader: true } },
]

export const router = createRouter({
  history: createWebHashHistory(),
  routes,
})
