<template>
  <h2 class="center-header mt-4 mb-4">{{ Text }}</h2>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "Spinner",
  props: {
    Text: {
      type: String,
      required: true,
    },
  },
});
</script>

<style scoped>
.center-header {
  text-align: center;
}
</style>
