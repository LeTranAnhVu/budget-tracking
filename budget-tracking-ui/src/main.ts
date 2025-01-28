import {
  BarElement,
  CategoryScale,
  Chart as ChartJS,
  Filler,
  LinearScale,
  LineElement,
  PointElement,
  Title,
  Tooltip,
} from 'chart.js'
import { createApp } from 'vue'

import App from './App.vue'
import { router } from './routes'

import './index.css'

ChartJS.register(
  Title,
  Tooltip,
  BarElement,
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
