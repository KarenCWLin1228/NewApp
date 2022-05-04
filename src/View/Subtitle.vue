<template>
  <p>
    Learn about <a v-bind:href="url">{{ subtitle }}</a>
  </p>
  <br /><br />
  <span>Count: {{ this.$store.state.count }}</span>
  <button v-on:click="addCount(2)">Add Me</button>
</template>

<script>
export default {
  data() {
    return {
      url: "https://docs.microsoft.com/aspnet/core",
      subtitle: "building Web apps with ASP.NET Core",
    };
  },
  methods: {
    addCount(num) {
      this.$store.commit("addCount", num);
    },
  },
};
</script>

<style scope>
span {
  margin: 0.8em;
}
</style>