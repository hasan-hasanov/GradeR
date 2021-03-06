<template>
  <div v-if="error != null && error.length > 0">
    <teleport to="#base-modal">
      <transition name="modal modal-dialog modal-dialog-centered">
        <div class="modal-mask">
          <div class="modal-wrapper">
            <div class="modal-dialog">
              <div class="modal-content">
                <div class="modal-header bg-danger">
                  <h5 class="modal-title text-white" id="staticBackdropLabel">
                    Error
                  </h5>
                </div>
                <div class="modal-body">
                  {{ error }}
                </div>
                <div class="modal-footer">
                  <button
                    type="button"
                    class="btn btn-secondary bg-danger"
                    @click="clearSuccessAndError"
                  >
                    Close
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </transition>
    </teleport>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import Store from "../../../store/Store";

export default defineComponent({
  name: "StatusModal",
  props: {
    error: {
      type: String,
      required: false,
    },
  },
  setup() {
    const clearSuccessAndError = () => Store.dispatch("ClearErrorAsync");

    return {
      clearSuccessAndError,
    };
  },
});
</script>

<style scoped>
.modal-mask {
  position: fixed;
  z-index: 9998;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: table;
  transition: opacity 0.3s ease;
}

.modal-wrapper {
  display: table-cell;
  vertical-align: middle;
}
</style>
