

<template>
  <div class="fixed w-full top-0 pt-2 mt-20 z-10 bg-white flex items-center justify-center gap-4 content-padding">

    <!-- Location previous pagination -->
    <div class="mb-3">
      <button class="border border-borderSecondary h-8 w-8 flex items-center justify-center rounded-full shadow-md">
        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" aria-hidden="true" role="presentation"
             focusable="false"
             style="display: block; fill: none; height: 12px; width: 12px; stroke: currentcolor; stroke-width: 5.33333; overflow: visible;">
          <path fill="none" d="M20 28 8.7 16.7a1 1 0 0 1 0-1.4L20 4"></path>
        </svg>
      </button>
    </div>

  <location-categories/>

    <!-- Location next pagination -->
    <div class="mb-3">
      <button class="border border-borderSecondary h-8 w-8 flex items-center justify-center rounded-full shadow-md">
        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" aria-hidden="true" role="presentation"
             focusable="false"
             style="display: block; fill: none; height: 12px; width: 12px; stroke: currentcolor; stroke-width: 5.33333; overflow: visible;">
          <path
              fill="none" d="m12 4 11.3 11.3a1 1 0 0 1 0 1.4L12 28"></path>
        </svg>
      </button>
    </div>
    <filter-actions/>
  </div>

</template>

<script setup lang="ts">
import LocationCategories from "@/modules/locations/components/LocationCategories.vue";
import FilterActions from "@/modules/locations/components/FilterActions.vue";


</script>
<style scoped>

</style>