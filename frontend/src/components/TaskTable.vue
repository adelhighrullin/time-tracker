<template>
  <div class="m-5">
    <b-table-simple class="table-striped">
      <b-tbody>
        <b-tr v-for="task in tasks" :key="task.id">
          <b-td class="text-start">{{ task.name }}</b-td>
          <b-td class="text-start">{{ task.category }}</b-td>
          <b-td class="text-end">{{ task.time }}</b-td>
          <b-td class="text-end"><b-button variant="danger" v-on:click="remove(task)">Delete</b-button></b-td>
        </b-tr>
      </b-tbody>
    </b-table-simple>
  </div>
</template>

<script>
export default {
  name: "task-table",
  props: {
    tasks: Array,
  },
  methods: {
    remove(task) {
      this.$emit("remove:task", task);
    },
  },
};
</script>
