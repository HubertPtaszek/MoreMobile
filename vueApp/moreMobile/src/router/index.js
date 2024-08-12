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
    path: '/calendar',
    name: 'EmailConfirmation',
    component: () => import ('../modules/auth/EmailConfirmation.vue')
  }
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
})

export default router
