<template>
  <div class="container mt-4">
    <div class="row justify-content-md-center">
      <div class="col-md-5">
        <div class="card mb-4 box-shadow">
          <img
            class="card-img-top"
            data-src="holder.js/100px225?theme=thumb&amp;bg=55595c&amp;fg=eceeef&amp;text=Thumbnail"
            style="height: 400px; width: 100%; display: block"
            src="/img/csharp-basics.png"
            data-holder-rendered="true"
          />
          <div class="card-body text-center">
            <h3>C# Programming Basics</h3>
          </div>
        </div>
      </div>

      <div class="col-md-5">
        <div class="card mb-4 box-shadow">
          <img
            class="card-img-top"
            data-src="holder.js/100px225?theme=thumb&amp;bg=55595c&amp;fg=eceeef&amp;text=Thumbnail"
            style="height: 400px; width: 100%; display: block"
            src="/img/csharp-advanced.png"
            data-holder-rendered="true"
          />
          <div class="card-body text-center">
            <h3>C# Programming Advanced</h3>
          </div>
        </div>
      </div>

      <div class="col-md-5">
        <div class="card mb-4 box-shadow">
          <div style="background-color: #464e69">
            <img
              class="card-img-top"
              data-src="holder.js/100px225?theme=thumb&amp;bg=55595c&amp;fg=eceeef&amp;text=Thumbnail"
              style="height: 400px; width: 100%; display: block"
              src="/img/java-basics.png"
              data-holder-rendered="true"
            />
          </div>
          <div class="card-body text-center">
            <h3>Java Programming Basics</h3>
          </div>
        </div>
      </div>

      <div class="col-md-5">
        <div class="card mb-4 box-shadow">
          <div style="background-color: #54974d">
            <img
              class="card-img-top"
              data-src="holder.js/100px225?theme=thumb&amp;bg=55595c&amp;fg=eceeef&amp;text=Thumbnail"
              style="height: 400px; width: 100%; display: block"
              src="/img/java-advanced.png"
              data-holder-rendered="true"
            />
          </div>
          <div class="card-body text-center">
            <h3>Java Programming Advanced</h3>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "Home",
  setup() {},
});
</script>

<style scoped>
.text-center {
  text-align: center;
}
</style>
