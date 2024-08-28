import { createRouter, createWebHistory } from '@ionic/vue-router';

const routes = [
  {
    path: '',
    redirect: '/auth'
  },
  {
    path: '/auth',
    name: 'Auth',
    component: () => import ('../modules/auth/SignInContainer.vue')
  },
  {
    path: '/register',
    name: 'Register',
    component: () => import ('../modules/auth/SignUpContainer.vue')
  },
  {
    path: '/forgot-password',
    name: 'ForgotPassword',
    component: () => import ('../modules/auth/ForgotPassword.vue')
  },
  {
    path: '/calendar',
    name: 'Calendar',
    component: () => import ('../modules/calendar/CalendarContainer.vue')
  },
  {
    path: '/service/:id',
    name: 'ServiceDetails',
    component: () => import ('../modules/services/ServiceDetails.vue')
  },
  {
    path: '/services',
    name: 'Services',
    component: () => import ('../modules/services/ServicesContainer.vue')
  },
  {
    path: '/users',
    name: 'Users',
    component: () => import ('../modules/users/UsersManagementContainer.vue')
  },
  {
    path: '/email-confirm',
    name: 'EmailConfirmation',
    component: () => import ('../modules/auth/EmailConfirmation.vue')
  },
  {
    path: '/settings',
    name: 'Settings',
    component: () => import ('../modules/settings/SettingsContainer.vue')
  }
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
})

export default router
