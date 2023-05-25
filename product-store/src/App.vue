<template>
  <router-view v-if="products"
  
  :baseURL="baseURL"
  :products="products"
  @fetchData="fetchData"
  >
  </router-view>

</template>

<script>

import axios from 'axios';
import Navbar from './components/Navbar.vue' 
export default {

components:{
  Navbar,
  
},

data(){
  return{
    baseURL: "http://localhost:3000/products",
    products: null,
  
  }

},

methods:{

  async fetchData(){
    await axios.get(this.baseURL)
    .then(res =>{
      this.products= res.data
    }).catch((err)=> console.log("err", err))
  }
},

mounted(){
  this.fetchData();
}
}
</script>
<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}
</style>
