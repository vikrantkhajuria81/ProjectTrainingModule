<template>
    <div class="container">
        <div class="row pt-5">
            <div class="col-md-1"></div>
            <!--            display image-->
            <div class="col-md-4 col-12 " style="margin-top: 50px;" >
                <img :src="product.thumbnail" class="img-fluid">
            </div>
            <!--            display product details-->
            <div class="col-md-6 col-12 pt-3 pt-md-0">
                <h4>{{ product.title }}</h4>
              
                <h6 class="font-weight-bold"> $ {{ product.price }}</h6>
                <p>
                    {{ product.description }}
                </p>
                <div class="features pt-3">
                    <h5><strong>Features</strong></h5>
                    <ul>
                        <li><strong>Rating:</strong> {{ product.rating }}</li>
                        <li> Stocks: {{  product.stock}}</li>
                        <li> Brand: {{ product.brand }}</li>
                        <li>Category: {{ product.category }}</li>
                         <li>discountPercentage: {{ product.discountPercentage }}</li>

                    </ul>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    data() {
        return {
            product: {},
          
        }
    },
    props: ["baseURL", "products"],
    mounted() {
        this.id = this.$route.params.id;
        this.product = this.products.find((product) => product.id == this.id)
    }
}
</script>
<style>
.category {
    font-weight: 400;
}
</style>