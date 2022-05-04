<template>
  <h1 class="greeting">{{ greeting }}</h1>
  <Subtitle />
  <br /><br />
  <span
    v-for="product in this.$store.state.products"
    :key="product.productName"
    >{{ product.productName }}</span
  >
</template>

<script>
import Subtitle from "./Subtitle.vue";

export default {
  data() {
    return {
      greeting: "Welcome",
    };
  },
  components: {
    Subtitle,
  },
};
</script>

<style>
.greeting {
  font-size: 3.5rem;
  font-weight: 300;
  line-height: 1.2;
}
</style>