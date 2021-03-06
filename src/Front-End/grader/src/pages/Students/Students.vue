<template>
  <center-header Text="Students" />

  <div class="container">
    <table class="table">
      <thead style="background-color: #009ce6">
        <tr>
          <th scope="col" class="text-white">#</th>
          <th scope="col" class="text-white">Name</th>
          <th scope="col" class="text-white">Birth Date</th>
          <th scope="col" class="text-white">Courses</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="student in students" :key="student.Id">
          <td>{{ student.Id }}</td>
          <td>{{ student.Name }}</td>
          <td>{{ student.BirthDate.toString().split("T")[0] }}</td>
          <td>{{ student.Courses }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, computed } from "vue";
import { getModule } from "vuex-module-decorators";
import CenterHeader from "../../components/Common/CenterHeader/CenterHeader.vue";
import StudentModule from "../../store/modules/StudentsModule";
import Store from "../../store/Store";

export default defineComponent({
  name: "Students",
  components: {
    "center-header": CenterHeader,
  },
  setup() {
    const studentModule = getModule(StudentModule, Store);
    const students = computed(() => studentModule.students);

    onMounted(async () => {
      await studentModule.GetStudentsAsync();
    });

    return { students };
  },
});
</script>

<style scoped>
</style>
