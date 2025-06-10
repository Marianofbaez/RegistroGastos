import { createRouter, createWebHistory } from 'vue-router'
import GastoView from '@/views/GastoView.vue';
import HistorialView from '@/views/HistorialView.vue';
import HomeView from '../views/HomeView.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView,
    },

    {
      path: '/gasto',
      name: 'Gasto',
      component: GastoView,
    },

    {
      path: '/historial',
      name: 'Historial',
      component: HistorialView,
    },

  ],
})

export default router
