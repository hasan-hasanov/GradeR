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

  <div class="navigation-top-background-image"></div>

  <nav class="navbar navbar-expand-lg" style="background-color: #f3684e">
    <router-link to="/" class="navbar-brand">
      <a
        class="nav-link text-white text-uppercase"
        style="font-weight: bold"
        href="#"
        >Grader</a
      >
    </router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarNav"
      aria-controls="navbarNav"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNav">
      <router-link to="/courses" class="navbar-brand">
        <a class="nav-link text-white">Courses</a>
      </router-link>
      <router-link to="/students" class="navbar-brand">
        <a class="nav-link text-white" href="#">Students</a>
      </router-link>
      <router-link to="/grades" class="navbar-brand">
        <a class="nav-link text-white" href="#">Grades</a>
      </router-link>
      <router-link to="/evaluation" class="navbar-brand">
        <a class="nav-link text-white" href="#">Evaluation</a>
      </router-link>
    </div>
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
  background-image: url(/img/header-icon.png);
  background-color: #009ce6;
  min-height: 200px;
  background-size: 180px, 180px;
  background-position: center;
  background-repeat: no-repeat;
}

.navigation-grader-left-logo {
  height: 80px;
}

.navigation-grader-header-font {
  font-size: 3.5rem;
  font-weight: 300;
  line-height: 1.2;
  color: #6b95bc;
}

.no-right-margin {
  margin-right: 0px !important;
}

.fit-header-to-div {
  width: 100%;
  height: 200px;
  object-fit: cover;
}
</style>
