import path from 'node:path'
import tailwindcss from '@tailwindcss/vite'
import vue from '@vitejs/plugin-vue'
import { defineConfig } from 'vite'
import { VitePWA } from 'vite-plugin-pwa'

// https://vite.dev/config/
export default defineConfig({
  plugins: [
    tailwindcss(),
    vue(),
    VitePWA({
      includeAssets: ['favicon.ico', 'apple-touch-icon-180x180.png'],
      // registerType: 'autoUpdate',
      // srcDir: 'src',
      // filename: 'service-worker.ts',
      // workbox: {
      //   cleanupOutdatedCaches: true,
      //   globPatterns: ['**/*.{js,css,html,png,svg,ico}'],
      // },
      devOptions: {
        enabled: true,
      },
      manifest: {
        name: 'Budget Tracking',
        short_name: 'BudgetTracking',
        description: 'Track your budget',
        theme_color: '#ffffff',
        background_color: '#ffffff',
        display: 'standalone',
        icons: [
          {
            src: 'pwa-192x192.png',
            sizes: '192x192',
            type: 'image/png',
          },
          {
            src: 'pwa-512x512.png',
            sizes: '512x512',
            type: 'image/png',
          },
        ],
      },
    }),
  ],
  resolve: {
    alias: {
      '@': path.resolve(__dirname, './src'),
    },
  },
})
