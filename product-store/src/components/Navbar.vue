<template>
    <div class="sidebar">
      <router-link :to="'/'" class="active">Home</router-link>
      <router-link :to="'/addproduct/'">Add Product</router-link>
      <a>Contact</a>
      <a href="#about">About</a>
    </div>

   
</template>
<script>
export default {
    name: "Navbar",

  
};
</script>
<style scoped>
#logo {
    width: 150px;
    margin-left: 20px;
    margin-right: 20px;
    height: 40px;
}
.sidebar {
  margin: 0;
  padding: 0;
  width: 110px;
  background-color: grey;
  position: fixed;
  height: 100%;
  overflow: auto;
}

.sidebar a {
  display: block;
  color: black;
  padding: 16px;
  text-decoration: none;
}
 
.sidebar a.active {
  background-color: #04AA6D;
  color: white;
}

.sidebar a:hover:not(.active) {
  background-color: #555;
  color: white;
}

div.content {
  margin-left: 200px;
  padding: 1px 16px;
  height: 1000px;
}

@media screen and (max-width: 700px) {
  .sidebar {
    width: 100%;
    height: auto;
    position: relative;
  }
  .sidebar a {float: left;}
  div.content {margin-left: 0;}
}

@media screen and (max-width: 400px) {
  .sidebar a {
    text-align: center;
    float: none;
  }
}

a {
    color: white;
}
</style>
