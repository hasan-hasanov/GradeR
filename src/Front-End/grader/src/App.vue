<template>
  <navigation-header />
  <div class="main">
    <router-view />
  </div>
</template>

<script lang="ts">
import { defineComponent, computed } from "vue";
import { useRoute } from "vue-router";

import NavigationHeader from "../src/components/Layout/NavigationHeader/NavigationHeader.vue";

export default defineComponent({
  name: "App",
  components: {
    "navigation-header": NavigationHeader,
  },
  setup() {
    const route = useRoute();
    const routeHeader = computed(() => route.meta.header);

    return {
      routeHeader,
    };
  },
});
</script>

<style>
html,
body {
  font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
}

.app {
  flex: 1;
  background-color: #f7f7f7;
  border-bottom: 1px solid #d6d5d5;
  justify-content: flex-end;
}
</style>
