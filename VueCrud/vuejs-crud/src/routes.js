import Home from './components/Home.vue'
import SignUp from './components/SignUp.vue'
import Login from './components/Login.vue'
import Add from './components/Add.vue'
import Update from './components/Update.vue'

import { createWebHistory, createRouter } from 'vue-router'

const routes = [

    //Lazy Loading

    {
        name: 'Home',
        path: '/',
        component: Home
    },

    {
        name: 'SignUp',
        path: '/signup',
        component: SignUp
    },

    {
        name: 'Login',
        path: '/login',
        component: Login
    },

    {
        name: 'Add',
        path: '/add',
        component: Add
    },

    {
        name: 'Update',
        path: '/update/:id',
        component: Update
    },
]


const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router
