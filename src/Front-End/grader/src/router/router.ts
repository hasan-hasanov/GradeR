import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import Home from '../pages/Home/Home.vue'
import Courses from '../pages/Courses/Courses.vue'
import Grades from '../pages/Grades/Grades.vue'
import Students from '../pages/Students/Students.vue'

const routes: Array<RouteRecordRaw> = [
    {
        path: '/',
        name: 'Home',
        component: Home,
    },
    {
        path: '/courses',
        name: 'Courses',
        component: Courses,
    },
    {
        path: '/grades',
        name: 'Grades',
        component: Grades,
    },
    {
        path: '/students',
        name: 'Students',
        component: Students,
    },
    {
        path: '/:catchAll(.*)',
        name: 'NotFound',
        component: () => import('../pages/NotFound/NotFound.vue'),
    }
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router