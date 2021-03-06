<template>
  <h2 class="center-header mt-4 mb-4">Courses</h2>

  <div class="container">
    <table class="table">
      <thead style="background-color: #009ce6">
        <tr>
          <th scope="col" class="text-white">#</th>
          <th scope="col" class="text-white">Name</th>
          <th scope="col" class="text-white">Start Date</th>
          <th scope="col" class="text-white">End Date</th>
          <th scope="col" class="text-white">Teachers</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="course in courses" :key="course.Id">
          <td>{{ course.Id }}</td>
          <td>{{ course.Name }}</td>
          <td>{{ course.StartDate.toString().split("T")[0] }}</td>
          <td>{{ course.EndDate.toString().split("T")[0] }}</td>
          <td>
            {{
              course.Teachers.map((t) => `${t.FirstName} ${t.LastName}`).join(
                ", "
              )
            }}
          </td>
        </tr>
      </tbody>
    </table>
  </div>
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
.center-header {
  text-align: center;
}
</style>
