<template>
  <nav class="top-bar-nav">
    <a v-on:click="clickMenu('Home')" class="top-bar-link">
      <i class="icofont-spoon-and-fork"></i>
      <span>Home</span>
    </a>
    <a v-on:click="clickMenu('Products')" class="top-bar-link">
      <span>Products</span>
    </a>
    <a v-on:click="clickMenu('Orders')" class="top-bar-link">
      <span>Past Orders</span>
    </a>
  </nav>
</template>

<script>
export default {
  methods: {
      clickMenu(page){
          this.$store.commit('isShowField', page);
      }
  }
};
</script>

<style scope>
  a {
    cursor: pointer;
  }
</style>