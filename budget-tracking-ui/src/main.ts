import { createApp } from 'vue'
import App from './App.vue'

import { router } from './routes'
import './index.css'

const app = createApp(App)

app
  .use(router)
  .mount('#app')
