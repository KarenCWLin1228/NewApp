<template>
  <aside class="cart-container">
    <div class="cart">
      <h1 class="cart-title spread">
        <span>
          Cart
          <i class="icofont-cart-alt icofont-1x"></i>
        </span>
        <button class="cart-close">&times;</button>
      </h1>

      <div class="cart-body">
        <table class="cart-table">
          <thead>
            <tr>
              <th><span class="sr-only">Product Image</span></th>
              <th>Product</th>
              <th>Price</th>
              <th>Qty</th>
              <th>Total</th>
              <th><span class="sr-only">Actions</span></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="product in this.$store.state.cart" :key="product.name">
              <td><i v-bind:class="getIconClass(product.name)"></i></td>
              <td>{{ product.name }}</td>
              <td>$ {{ getUnitPrice(product.name) }}</td>
              <td class="center">{{ product.qty }}</td>
              <td>${{getSubTotal(product.name, product.qty)}}</td>
              <td class="center">
                <button class="btn btn-light cart-remove" v-on:click="removeItem(product.name)">&times;</button>
              </td>
            </tr>
          </tbody>
        </table>

        <p class="center">
          <em v-show="!this.$store.state.cart.length">No items in cart</em>
        </p>
        <div class="spread">
          <span><strong>Total:</strong> ${{getTotal()}}</span>
          <button class="btn btn-light" v-on:click="checkOut">Checkout</button>
        </div>
      </div>
    </div>
  </aside>
</template>

<script>
export default {
  data() {
    return {
      qty: 0,
    };
  },
  methods: {
    getIconClass(productName) {
      var found = this.$store.state.products.find(
        (p) => p.name === productName
      );
      if (found) return `icofont-${found.icon} icofont-3x`;
      return "icofont-3x";
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
    getTotal() {
        var total = 0;
        var products = this.$store.state.products;
        $.each(this.$store.state.cart, function(index, product) {
            var unitPrice = 0;
            var found = products.find((p) => p.name === product.name);
            if (found) unitPrice = found.price.USD;
            total += (unitPrice * product.qty);
        });
        return total.toFixed(2);
    },
    removeItem(productName) {
        this.$store.commit("removeItemFromCart", productName);
    },
    checkOut() {
        this.$store.commit("checkOut");
    }
  },
};
</script>