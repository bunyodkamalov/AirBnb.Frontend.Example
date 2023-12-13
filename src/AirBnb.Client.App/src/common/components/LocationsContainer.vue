<script setup lang="ts">

import LocationsTab from "@/modules/locations/components/LocationsTab.vue";
import LocationsGrid from "@/modules/locations/components/LocationsGrid.vue";
</script>

<template>
  <article class="mt-[20px] bg-defaultBackground content-padding">
    <div class="flex flex-col items-center justify-center">


      <!-- Locations Tab -->
      <locations-tab/>

      <!-- Locations Grid -->
      <locations-grid/>

    </div>
  </article>
</template>

<style scoped>

</style>