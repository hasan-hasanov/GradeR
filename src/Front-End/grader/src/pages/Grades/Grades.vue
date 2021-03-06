<template>
  <center-header Text="Grades" />

  <div class="container">
    <table class="table">
      <thead style="background-color: #009ce6">
        <tr>
          <th scope="col" class="text-white">#</th>
          <th scope="col" class="text-white">Student</th>
          <th scope="col" class="text-white">Teacher</th>
          <th scope="col" class="text-white">Course</th>
          <th scope="col" class="text-white">Grade</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="grade in grades" :key="grade.Id">
          <td>{{ grade.Id }}</td>
          <td>{{ grade.Student }}</td>
          <td>{{ grade.Teacher }}</td>
          <td>{{ grade.Course }}</td>
          <td>{{ grade.Grade }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, computed } from "vue";
import { getModule } from "vuex-module-decorators";
import CenterHeader from "../../components/Common/CenterHeader/CenterHeader.vue";
import GradesModule from "../../store/modules/GradesModule";
import Store from "../../store/Store";

export default defineComponent({
  name: "Grades",
  components: {
    "center-header": CenterHeader,
  },
  setup() {
    const gradesModule = getModule(GradesModule, Store);
    const grades = computed(() => gradesModule.grades);

    onMounted(async () => {
      await gradesModule.GetGradesAsync();
    });

    return { grades };
  },
});
</script>

<style scoped>
</style>
