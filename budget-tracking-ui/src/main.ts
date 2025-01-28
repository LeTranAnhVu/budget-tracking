import { createApp } from 'vue'
import App from './App.vue'

import { router } from './routes'
import './index.css'

import {
  CategoryScale,
  Chart as ChartJS,
  Filler,
  LinearScale,
  LineElement,
  PointElement,
  Title,
  Tooltip,
} from 'chart.js'
ChartJS.register(
  Title,
  Tooltip,
  LineElement,
  LinearScale,
  PointElement,
  CategoryScale,
  Filler,
)
const app = createApp(App)

app
  .use(router)
  .mount('#app')
