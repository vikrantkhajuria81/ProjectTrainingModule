import { createRouter, createWebHistory } from 'vue-router'

const routes = [

  // lazy-loaded when the route is visited then component  is loaded
  {
    path: '/addproduct',
    name: 'AddProduct',
    component: () => import('../views/Products/AddProduct.vue')
  },


  {
    path: '/',
    name: 'Product',
    component: () => import('../views/Products/Product.vue')
  },

  {
    path: '/edit/:id',
    name: 'EditProduct',
    component: () => import('../views/Products/EditProduct.vue')
  },

  {
    path: '/productdetails/:id',
    name: 'ProductDetails',
    component: () => import('../views/Products/ProductDetails.vue')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
