<template>
<div class="card w-100 h-100" style="margin-top: 10px; margin-left: 10px;">
    <div class="embed-responsive embed-responsive-16by9">
        <img class="card-img-top embed-responsive-item" :src="product.thumbnail" alt="Card image cap" />
    </div>
    <div class="card-body">
        <router-link :to="{ name: 'ProductDetails', params: { id: product.id } }">
            <h5 class="card-title">{{ product.title }}</h5>
        </router-link>

        <p class="card-text">
            {{ product.description.substring(0,40) }}...
        </p>

        <router-link :to="{ name: 'EditProduct', params: { id: product.id } }">
            <button class="btn btn-primary">Edit</button>

        </router-link>
        <button class="btn btn-primary mx-2" v-on:click="delProduct(product.id)">Delete</button>

    </div>
</div>
</template>

<script>
import axios from 'axios';
export default {
    name: "ProductBox",
    props: ["product"],
    methods: {
              async delProduct(id) {
            let result = await axios.delete("http://localhost:3000/products/" + id)

            if (result.status == 200) {
                alert("Data Deleted Successfully")
            }

        },
    },
};
</script>

<style scoped>
.card-img-top {
    object-fit: cover;
}
</style>
