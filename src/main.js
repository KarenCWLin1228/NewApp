import {createApp} from 'vue';
import { createStore } from 'vuex'
import Products from './View/Products.vue';
import Cart from './View/Cart.vue';
import Menus from './View/Menu.vue';
import Orders from './View/Orders.vue';

var pastOrders = [];
carts.forEach(function(c) {
    pastOrders.push({
        name: c.productName,
        qty: c.qty
    });
});

const store = createStore({
    state () {
      return {
        currPage: 'Home',
        products: [],
        cart: [],
        pastOrders: pastOrders,
        totalQty: 0,
        isShowHome: true,
        isShowProducts: false,
        isShowOrders: false,
      }
    },
    mutations: {
        setProducts(state, payload){
            state.products = payload;
        },
        addToCart(state, payload) {
            var found = state.cart.find(p => p.name === payload.name);
            if(found) {
                found.qty += payload.qty;
            }
            else
            {
                state.cart.push({
                    name: payload.name,
                    qty: payload.qty
                });
            }
        },
        calculateTotalQty(state) {
            var totalQty = state.cart.map(c => c.qty).reduce((acc, cur) => acc += cur, 0);
            state.totalQty = totalQty;
        },
        removeItemFromCart(state, productName) {
            var filtered = state.cart.filter(function(item){ 
                return item.name !== productName;
            });
            state.cart = filtered;
        },
        isShowField(state, page) {
            state.isShowHome= false;
            state.isShowProducts= false;
            state.isShowOrders= false;

            switch(page)
            {
                case 'Home':
                    state.isShowHome = true;
                    break;
                case 'Products':
                    state.isShowProducts = true;
                    break;
                case 'Orders':
                    state.isShowOrders = true;
                    break;
            }
        },
        checkOut(state) {
            var carts = [];
            state.cart.forEach(function(c) {
                var found = state.products.find(
                (p) => p.name === c.name
                );
                if (found) 
                {
                    carts.push({
                        ProductName: c.name,
                        UnitPrice: found.price.USD,
                        Qty: c.qty
                    });
                }
            });
   
            fetch('@Url.Action("CheckOut", "Home")', {
                method: 'POST', 
                body: JSON.stringify(carts), 
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                  },
              }).then(res => console.log(res.json()))
              .catch(error => console.error('Error:', error))
              .then(response => console.log('Success:', response));
        }
    }
  })

var app = createApp({
    data() {
        return {
            isShowCart: false,
            products: [],
        }
    },
    async mounted() {
        var response = await fetch("../../food.json");
        var products = await response.json();
        this.$store.commit('setProducts', products);
        this.products = products;
    },
    components:{
        Products,
        Cart,
        Menus,
        Orders
    },
    methods: {
        toggleCart() {
            this.isShowCart = !this.isShowCart;
        }
    }
});
app.use(store);
app.mount('#app');