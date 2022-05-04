<template>
    <table class="product-table">
        <thead>
        <tr>
            <td><span class="sr-only">Product Image</span></td>
            <td>Product</td>
            <td>Price</td>
            <td>Quantity</td>
            <td>Total</td>
            <td><span class="sr-only">Actions</span></td>
        </tr>
        </thead>
        <tbody>
        <tr v-for="order in this.$store.state.pastOrders" :key="order.name">
            <td><i v-bind:class="getIconClass(order.name)" /></td>
            <td>{{order.name}}</td>
            <td>${{getUnitPrice(order.name)}}</td>
            <td>{{order.qty}}</td>
            <td>${{getSubTotal(order.name, order.qty)}}</td>
            <td><button v-on:click="addToCart(order.name, order.qty)" class="btn btn-dark">Add</button></td>
        </tr>
        </tbody>
    </table>
</template>

<script>
export default {
  methods: {
    getIconClass(productName) {
      var found = this.$store.state.products.find(
        (p) => p.name === productName
      );
      if (found) return `icofont-${found.icon} icofont-4x`;
      return "icofont-4x";
    },
    getUnitPrice(productName) {
      var found = this.$store.state.products.find(
        (p) => p.name === productName
      );
      if (found) return found.price.USD;
      return 0;
    },
    getSubTotal(productName, qty) {
      var unitPrice = this.getUnitPrice(productName);
      return (unitPrice * qty).toFixed(2);
    },
    addToCart(productName, qty) {
      this.$store.commit("addToCart", {
        name: productName,
        qty: qty,
      });
      this.$store.commit("calculateTotalQty");
    },
  },
};
</script>