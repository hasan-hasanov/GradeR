import { createApp } from 'vue'
import App from './App.vue'
import Store from '../src/store/Store'
import Router from '../src/router/router'

import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'

createApp(App)
    .use(Router)
    .use(Store)
    .mount("#app");