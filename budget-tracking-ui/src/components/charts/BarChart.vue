<script setup lang="ts">
import type { ChartData } from 'chart.js'
import { computed, onMounted, ref, watch } from 'vue'
import { Bar } from 'vue-chartjs'
import { GREEN, RED } from './constant'

const props = defineProps<{
  x: string[]
  y: number[]
  label: string
  color: 'green' | 'red'
}>()

const gradientBottom = 'white'
const lineColor = computed(() => props.color === 'green' ? GREEN : RED)
const gradient = ref<CanvasGradient | null>(null)
const wrapperRef = ref<HTMLDivElement | null>(null)

const chartData = computed<ChartData<'bar'>>(() => {
  return {
    labels: props.x,
    datasets: [
      {
        label: props.label,
        data: props.y,
        backgroundColor: gradient.value,
        barThickness: 15,
        borderRadius: 3,
        borderWidth: 0, // Thin and elegant line
      },
    ],
  } as ChartData<'bar'>
},
)

const chartOptions = ref({
  responsive: true,
  maintainAspectRatio: false, // Ensure responsiveness
  plugins: {
    legend: {
      display: false, // Hide the legend for a minimalist look
    },
    tooltip: {
      enabled: true, // Enable tooltips
    },
  },
  scales: {
    x: {
      grid: {
        display: false, // Remove grid lines on x-axis
      },
      ticks: {
        color: '#6B7280', // Neutral gray for text
      },
    },
    y: {
      grid: {
        display: true, // Remove grid lines on y-axis
      },
      ticks: {
        color: '#6B7280', // Neutral gray for text
      },
    },
  },
})

// Create gradient background
onMounted(() => {
  gradient.value = buildGradientBg(lineColor.value, gradientBottom) || null
})

watch(lineColor, () => {
  gradient.value = buildGradientBg(lineColor.value, gradientBottom) || null
})

function buildGradientBg(top: string, bottom: string): CanvasGradient | undefined {
  if (!wrapperRef.value) {
    return
  }

  const canvas = (wrapperRef.value! as HTMLDivElement)?.querySelector<HTMLCanvasElement>('canvas')
  if (!canvas) {
    return
  }

  const ctx = canvas.getContext('2d')
  const gradient = ctx?.createLinearGradient(0, 0, 0, 300)
  gradient?.addColorStop(0, top) // Top gradient color
  gradient?.addColorStop(1, bottom) // Transparent at the bottom
  return gradient
}
</script>

<template>
  <div ref="wrapperRef">
    <Bar
      :data="chartData"
      :options="chartOptions"
      class="w-full h-64"
    />
  </div>
</template>

<style scoped>
  /* Optional styles for chart container */
  canvas {
    display: block;
    width: 100%;
    height: auto;
  }
</style>
