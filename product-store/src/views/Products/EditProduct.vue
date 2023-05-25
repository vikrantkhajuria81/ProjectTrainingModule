<template>
    <div class="container">
        <div class="row">
            <div class="col-12 text-center">
                <h4 class="pt-3"> Edit Product</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-3"></div>
            <div class="col-6">
                <form v-if="product">
                     <div class="form-group">
                        <label>Name</label>
                        <input type="text" class="form-control" v-model="product.title" required>
                    </div>
                    <div class="form-group">
                        <label>Description</label>
                        <input type="text" class="form-control" v-model="product.description" required>
                    </div>
                    <div class="form-group">
                        <label>ImageURL</label>
                        <input type="url" class="form-control" v-model="product.thumbnail" required>
                    </div>
                    <div class="form-group">
                        <label>Price</label>
                        <input type="number" class="form-control" v-model="product.price" required>
                    </div>

                     <div class="form-group">
                            <label>category</label>
                            <input type="text" class="form-control" v-model="product.category" required>
                        </div>

                        <div class="form-group">
                                <label>brand</label>
                                <input type="text" class="form-control" v-model="product.brand" required>
                            </div>

                        
                            <div class="form-group">
                                    <label>stock</label>
                                    <input type="number" class="form-control" v-model="product.stock" required>
                                </div>

                                <div class="form-group">
                                        <label>rating</label>
                                        <input type="number" class="form-control" v-model="product.rating" required>
                                    </div>

                                       <div class="form-group">
                                            <label>discountPercentage</label>
                                            <input type="number" class="form-control" v-model="product.discountPercentage" required>
                                        </div>
                    <button type="button" class="btn btn-primary" @click="editProduct">Submit</button>
                </form>
            </div>
            <div class="col-3"></div>
        </div>
    </div>
</template>
<script>
import axios from 'axios'
import swal from 'sweetalert'
export default {
    data() {
        return {
            product: null,
            id: null
        }
    },
    props: ["baseURL","products"],
    methods: {
        async editProduct() {
            console.log('product', this.product)
            await axios.put(`${this.baseURL}/${this.id}`,
                this.product)
                .then(() => {
                    this.$emit("fetchData");
                    this.$router.push({ name: 'Product' })
                    swal({
                        text: "product has been updated successfully",
                        icon: "success"
                    })
                }).catch(err => console.log('err', err));
        }
    },
    mounted() {
        this.id = this.$route.params.id;
        this.product = this.products.find(product => product.id == this.id)
    }
}
</script>
