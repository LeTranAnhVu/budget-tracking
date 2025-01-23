<script setup lang="ts">
import HelloWorld from './components/HelloWorld.vue'
</script>

<template>
  <div>
    <a href="https://vite.dev" target="_blank">
      <img src="/vite.svg" class="logo" alt="Vite logo">
    </a>
    <a href="https://vuejs.org/" target="_blank">
      <img src="./assets/vue.svg" class="logo vue" alt="Vue logo">
    </a>
  </div>
  <HelloWorld msg="Vite + Vue" />
  <button class="bg-blue-900 text-white px-4 py-2 rounded-md hover:bg-blue-700 ml-4 cursor-pointer">
    Click me
  </button>
  <div class="flex flex-col gap-2 p-8 sm:flex-row sm:items-center sm:gap-6 sm:py-4">
    <img class="mx-auto block h-24 rounded-full sm:mx-0 sm:shrink-0" src="https://tailwindcss.com/_next/static/media/erin-lindford.90b9d461.jpg" alt="">
    <div class="space-y-2 text-center sm:text-left">
      <div class="space-y-0.5">
        <p class="text-lg font-semibold text-black">
          Erin Lindford
        </p>
        <p class="font-medium text-gray-500">
          Product Engineer
        </p>
      </div>
      <button class="rounded-full border border-purple-200 px-4 py-1 text-sm font-semibold text-purple-600 hover:border-transparent hover:bg-purple-600 hover:text-white active:bg-purple-700">
        Message
      </button>
    </div>
  </div>
</template>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}
.logo:hover {
    filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>
