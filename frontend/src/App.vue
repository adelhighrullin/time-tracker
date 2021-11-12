<template>
  <div id="nav">
    <b-navbar variant="light">
      <b-navbar-brand class="ms-5" href="#">time tracker</b-navbar-brand>
    </b-navbar>
    <task-form @add:task="addTask" />
    <task-table :tasks="tasks" @remove:task="removeTask" />
  </div>
</template>

<script>
import TaskForm from "@/components/TaskForm.vue";
import TaskTable from "@/components/TaskTable.vue";

import axios from "axios";

export default {
  name: "app",
  components: {
    TaskForm,
    TaskTable,
  },
  data() {
    return {
      tasks: [],
    };
  },
  mounted() {
    this.getTasks();
  },
  methods: {
    getTasks() {
      axios
        .get("https://localhost:5001/api/Tasks")
        .then((response) => (this.tasks = response.data));
    },

    async addTask(task) {
      await axios
        .post("https://localhost:5001/api/Tasks", task)
        .then((response) => (this.tasks = [...this.tasks, response.data]));
      this.getTasks();
    },

    async removeTask(task) {
      await axios
        .delete(`https://localhost:5001/api/Tasks/${task.id}`)
        .then((response) => console.log(response));
      this.getTasks();
    },
  },
};
</script>
<style>
@import'~bootstrap/dist/css/bootstrap.css';
</style>
