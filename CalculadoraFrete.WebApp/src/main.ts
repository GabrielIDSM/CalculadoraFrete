import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap/dist/js/bootstrap.js'

import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'
import { Imask } from './directives/imask'

import App from './App.vue'
import router from './router'

const app = createApp(App)

app.directive('imask', Imask)
app.use(createPinia())
app.use(router)

app.mount('#app')
