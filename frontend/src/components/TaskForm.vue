<template>
  <div id="newTask">
    <b-form class="m-5" inline @submit.prevent="handleSubmit">
      <b-row>
        <b-col cols="9">
          <b-input-group>
            <b-form-input
              v-model="task.name"
              type="text"
              placeholder="Enter task name here: "
            />
            <b-form-input
              v-model="task.category"
              type="text"
              placeholder="Enter task category here: "
            />
            <b-badge class="bg-secondary">{{ task.time }}</b-badge>
          </b-input-group>
        </b-col>
        <b-col class="text-end">
        <b-button-group>
          <b-button
            class="ms-2"
            :variant="toggleVariant"
            type="button"
            v-on:click="toggle(task)">
            {{ !taskState ? "Start" : "Pause" }}
          </b-button>
          <b-button class="ms-2" type="button" v-on:click="clearInfo()">Clear</b-button>
          <b-button class="ms-2" variant="primary" type="submit">End session</b-button>        
        </b-button-group>
        </b-col>
      </b-row>
    </b-form>
  </div>
</template>

<script>
export default {
  name: "task-form",
  data() {
    return {
      task: {
        name: "",
        category: "",
        time: "00:00:00",
      },
      counter: 0,
      taskState: false,
      toggleVariant: "success",
      timer: null,
    };
  },
  methods: {
    toggle(task) {
      this.taskState = !this.taskState;
      this.taskState ? this.toggleVariant = "warning" : this.toggleVariant = "success";
      if (this.taskState) {
        this.timer = setInterval(() => {
          task.time = this.convertTime(++this.counter);
        }, 1000);
      } else {
        clearTimeout(this.timer);
      }
    },

    convertTime(tt) {
      return new Date(tt * 1000).toISOString().substr(11, 8);
    },

    clearInfo() {
      this.taskState = false;
      this.toggleVariant = "success";
      clearTimeout(this.timer);
      this.task.name = "";
      this.task.category = "";
      this.task.time = "00:00:00";
      this.counter = 0;
    },

    handleSubmit() {
      this.$emit("add:task", this.task);
      this.clearInfo();
    },
  },
};
</script>
