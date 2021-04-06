import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import About from '../views/About.vue'
import Invoice from '../components/Invoice'

Vue.use(VueRouter)

  const routes = [
    // {
    //   path: '/',
    //   redirect: '/login',
    // },
    {
      path: '/login',
      name: 'Login',
      component: Login
    },
    {
      path: '/',
      component: Home,
      props: (route) => ({ ...route.params }),
      children: [
        {
          path: '/',
          redirect: '/Invoice',
          props: (route) => ({ ...route.params }),
        },
        {
          path: '/Invoice',
          component: Invoice,
          props: (route) => ({ ...route.params }),
        },
      ]
    },
  {
    path: '/about',
    name: 'About',
    component: About
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    // component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  }
]

const router = new VueRouter({
  routes
})

export default router
