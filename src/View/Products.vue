<template>
  <div class="card">
    <div class="card-title">{{ product.name }}</div>
    <div class="card-body">
      <i v-bind:class="getIconClass(product.icon)"></i>
      <form>
        <div class="row">
          <div class="cell">
            <label>Type:</label>
          </div>
          <div class="cell">
            <em>{{
              product.type.charAt(0).toUpperCase() + product.type.slice(1)
            }}</em>
          </div>
        </div>
        <div class="row">
          <div class="cell">
            <label>Price:</label>
          </div>
          <div class="cell">${{ product.price.USD }}</div>
        </div>
        <div class="row">
          <div class="cell">
            <label>Quantity:</label>
          </div>
          <div class="cell">
            <input type="number" v-model.number="qty" />
          </div>
        </div>
      </form>
    </div>
    <div class="card-footer">
      <button v-on:click="addToCart(product.name)" class="btn btn-light">
        Add to cart
      </button>
    </div>
  </div>
</template>

<script>
export default {
  props: ["product"],
  data() {
    return {
      qty: 0,
    };
  },
  watch: {
    qty(curVal) {
      if(curVal < 0) this.qty = 0;
    }
  },
  methods: {
    getIconClass(icon) {
      return "icofont-10x icofont-" + icon;
    },
    addToCart(productName) {
      if(this.qty == 0) return;
      
      this.$store.commit("addToCart", {
        name: productName,
        qty: this.qty,
      });
      this.$store.commit("calculateTotalQty");
      this.qty = 0;
    },
  },
};
</script>