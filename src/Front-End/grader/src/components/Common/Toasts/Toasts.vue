<template>
  <div
    v-bind:id="'toast' + divId"
    class="toast d-flex align-items-center text-white bg-success border-0"
    role="alert"
    aria-live="assertive"
    aria-atomic="true"
  >
    <div class="toast-body">
      <h6>{{ message }}</h6>
    </div>
    <button
      type="button"
      class="btn-close btn-close-white ms-auto me-2"
      data-bs-dismiss="toast"
      aria-label="Close"
    ></button>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted } from "vue";
import Store from "../../../store/Store";
import Toast from "bootstrap/js/dist/toast";

export default defineComponent({
  name: "Toast",
  props: {
    message: {
      type: String,
      required: true,
    },
    divId: {
      type: Number,
      required: true,
    },
  },
  setup(props) {
    onMounted(() => {
      const toast = new Toast(document.getElementById("toast" + props.divId)!);
      toast.show();
      setTimeout(function () {
        Store.dispatch("RemoveFirstSuccessMessageAsync");
      }, 5000);
    });
    return {};
  },
});
</script>

<style scoped>
</style>
