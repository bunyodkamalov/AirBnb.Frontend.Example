<script setup lang="ts">
import MainLogo from "@/common/components/icons/MainLogo.vue";
import LocationsMenu from "@/modules/locations/components/LocationsMenu.vue";
import ProfileMenu from "@/modules/locations/components/ProfileMenu.vue";
import LocationsFilter from "@/modules/locations/components/LocationsFilter.vue";
import BottomBorder from "@/modules/locations/components/BottomBorder.vue";


</script>

<template>
  <div
      class="fixed h-20 top-0 z-10 content-padding w-full bg-defaultBackground flex justify-between items-center border-b border-borderSecondary text-textPrimary">

    <!-- Logo -->
    <main-logo/>

    <!-- Locations menu -->
    <locations-menu/>

    <!-- Profile menu -->
    <profile-menu/>

    <!-- Locations filter -->
    <locations-filter/>

    <!-- Bottom border -->
    <bottom-border/>

    <div class="absolute border-b-2 border-borderSecondary"></div>

  </div>

</template>

<style scoped>

</style>