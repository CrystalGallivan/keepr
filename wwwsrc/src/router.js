import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import UserKeeps from './views/UserKeeps.vue'
// @ts-ignore
import MyDashboard from './views/MyDashboard.vue'
// @ts-ignore
import VaultKeeps from './views/VaultKeeps.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/keeps',
      name: 'UserKeeps',
      component: UserKeeps
    },
    {
      path: '/dashboards',
      name: 'MyDashboard',
      component: MyDashboard
    },
    {
      path: '/vaults',
      name: 'VaultKeeps',
      component: VaultKeeps
    }
  ]
})
