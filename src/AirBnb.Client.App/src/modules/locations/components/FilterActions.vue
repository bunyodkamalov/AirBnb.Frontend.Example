<script setup lang="ts">

</script>

<template>
  <div class="w-[500px] hidden lg:flex items-center justify-center pb-3">

    <!-- Locations filter -->
    <button
        class="ml-3 flex group h-12 w-auto px-4 border border-borderSecondary justify-center items-center rounded-lg gap-3">
      <svg class="text-textSecondary select-text" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32"
           aria-hidden="true"
           role="presentation"
           focusable="false"
           style="display: block; fill: none; height: 16px; width: 16px; stroke: currentcolor; stroke-width: 4; overflow: visible;">
        <path fill="none"
              d="M7 16H3m26 0H15M29 6h-4m-8 0H3m26 20h-4M7 16a4 4 0 1 0 8 0 4 4 0 0 0-8 0zM17 6a4 4 0 1 0 8 0 4 4 0 0 0-8 0zm0 20a4 4 0 1 0 8 0 4 4 0 0 0-8 0zm0 0H3"></path>
      </svg>
      <span>Filters</span>
    </button>

    <button
        class="ml-3 flex group h-12 w-auto px-4 border border-borderSecondary justify-center items-center rounded-lg gap-3">
      <span class="text-xs font-medium whitespace-nowrap">Display total before taxes</span>
    </button>

  </div>
</template>

<style scoped>

</style>