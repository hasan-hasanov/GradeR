<template>
  <p>Welcome to Courses page</p>
</template>

<script lang="ts">
import { defineComponent, onMounted, computed } from "vue";
import { getModule } from "vuex-module-decorators";
import CoursesModule from "../../store/modules/CoursesModule";
import Store from "../../store/Store";

export default defineComponent({
  name: "Courses",
  setup() {
    const coursesModule = getModule(CoursesModule, Store);
    const courses = computed(() => coursesModule.courses);

    onMounted(async () => {
      await coursesModule.GetCoursesAsync();
    });

    return { courses };
  },
});
</script>

<style scoped>
</style>
