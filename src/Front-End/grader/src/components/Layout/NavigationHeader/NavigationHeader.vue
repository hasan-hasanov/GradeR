<template>
  <spinner :isLoading="isLoading" />
  <status-modal :error="error" />
  <teleport
    to="#toast-container"
    v-if="successMessages != null && successMessages.length > 0"
  >
    <toasts
      :message="message"
      :divId="index"
      v-for="(message, index) in successMessages"
      :key="message"
    />
  </teleport>

  <div class="navigation-top-background-image">
    <div class="row no-right-margin ml-1 pr-5 pt-5 pl-5 pb-5">
      <div></div>
      <div class="ml-auto"></div>
    </div>
  </div>

  <nav
    class="navbar navbar-expand-lg navbar-light justify-content-between"
    style="background-color: #68aee0"
  >
    <router-link to="/" class="navbar-brand ml-2">
      <svg
        width="1em"
        height="1em"
        viewBox="0 0 16 16"
        class="bi bi-house-fill"
        fill="white"
        xmlns="http://www.w3.org/2000/svg"
      >
        <path
          fill-rule="evenodd"
          d="M8 3.293l6 6V13.5a1.5 1.5 0 0 1-1.5 1.5h-9A1.5 1.5 0 0 1 2 13.5V9.293l6-6zm5-.793V6l-2-2V2.5a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 .5.5z"
        />
        <path
          fill-rule="evenodd"
          d="M7.293 1.5a1 1 0 0 1 1.414 0l6.647 6.646a.5.5 0 0 1-.708.708L8 2.207 1.354 8.854a.5.5 0 1 1-.708-.708L7.293 1.5z"
        />
      </svg>
    </router-link>
  </nav>
</template>

<script lang="ts">
import { computed, defineComponent } from "vue";
import Store from "@/store/Store";
import Spinner from "@/components/Common/Spinner/Spinner.vue";
import StatusModal from "@/components/Common/StatusModal/StatusModal.vue";
import Toasts from "@/components/Common/Toasts/Toasts.vue";

export default defineComponent({
  name: "NavigationHeader",
  components: {
    spinner: Spinner,
    "status-modal": StatusModal,
    toasts: Toasts,
  },
  setup() {
    const isLoading = computed(() => Store.state.isLoading);
    const error = computed(() => Store.state.error);
    const successMessages = computed(() => Store.state.successMessages);

    return {
      isLoading,
      error,
      successMessages,
    };
  },
});
</script>

<style>
.navigation-top-background-image {
  background-image: url(/img/main-jumbotron-image.jpg);
  background-position: center;
  background-size: cover;
}

.navigation-grader-left-logo {
  height: 80px;
}

.navigation-grader-header-font {
  font-size: 3.5rem;
  font-weight: 300;
  line-height: 1.2;
  color: #0099da;
}

.no-right-margin {
  margin-right: 0px !important;
}
</style>
