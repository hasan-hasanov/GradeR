<template>
  <div v-if="isLoading">
    <teleport to="#spinner">
      <div id="overlay">
        <div class="spinner"></div>
      </div>
    </teleport>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "Spinner",
  props: {
    isLoading: {
      type: Boolean,
      required: true,
    },
  },
});
</script>

<style scoped>
#overlay {
  background: #ffffff;
  color: #666666;
  position: fixed;
  height: 100%;
  width: 100%;
  z-index: 5000;
  top: 0;
  left: 0;
  float: left;
  text-align: center;
  padding-top: 25%;
  opacity: 0.8;
}
button {
  margin: 40px;
  padding: 5px 20px;
  cursor: pointer;
}
.spinner {
  margin: 0 auto;
  height: 64px;
  width: 64px;
  animation: rotate 0.8s infinite linear;
  border: 5px solid rgb(104, 174, 224);
  border-right-color: transparent;
  border-radius: 50%;
}
@keyframes rotate {
  0% {
    transform: rotate(0deg);
  }
  100% {
    transform: rotate(360deg);
  }
}
</style>
