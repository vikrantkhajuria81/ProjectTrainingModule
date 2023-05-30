<template>

<div class="container">
    <div class="row">
        <div class="col-12 text-center">
            <h4 class="pt-3">Add new Product</h4>
        </div>
    </div>

    <div class="row">
        <div class="col-3"></div>
        <div class="col-md-6 px-5 px-md-0">
            <form >   
                <div class="form-group">
                    <label>Name</label>
                    <input type="text" class="form-control" v-model="title" required />
                </div>
                <div class="form-group">
                    <label>Description</label>
                    <input type="text" class="form-control" v-model="description" required />
                </div>
                <div class="form-group">
                    <label>ImageURL</label>
                    <input type="url" class="form-control" v-model="thumbnail" required />
                </div>
                <div class="form-group">
                    <label>Price</label>
                    <input type="number" class="form-control" v-model="price" required />
                </div>

                 <div class="form-group">
                        <label>category</label>
                        <input type="text" class="form-control" v-model="category" required />
                    </div>

                    <div class="form-group">
                            <label>brand</label>
                            <input type="text" class="form-control" v-model="brand" required />
                        </div>

                        
                        <div class="form-group">
                                <label>stock</label>
                                <input type="number" class="form-control" v-model="stock" required />
                            </div>

                            <div class="form-group">
                                    <label>rating</label>
                                    <input type="number" class="form-control" v-model="rating" required />
                                </div>

                                   <div class="form-group">
                                        <label>discountPercentage</label>
                                        <input type="number" class="form-control" v-model="discountPercentage" required />
                                    </div>

                <button type="button" class="btn btn-primary" @click="addProduct">Submit</button>
            </form>
        </div>
        <div class="col-3"></div>
    </div>
</div>
</template>

<script>
var axios = require('axios')
import swal from 'sweetalert';
export default {
    data() {
        
        return {

            title: '',
            description: '',
            thumbnail: '',
            price: '',
            category:'',
            brand:'',
            stock:'',
            rating:'',
            discountPercentage:''



        }
    },
    methods: {
        async addProduct() {
            const addProduct = {
                title: this.title,
                description: this.description,
                thumbnail: this.thumbnail,
                price: this.price,
                category: this.category,
                brand: this.brand,
                stock: this.stock,
                rating: this.rating,
                discountPercentage: this.discountPercentage
            };

            const baseURL = "http://localhost:5265/api/Product";

            await axios({
                    method: 'post',
                    url: `${baseURL +"/addproduct"}`,
                    data: JSON.stringify(addProduct),
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
                .then(() => {
                     this.$emit("fetchData");
                     this.$router.push({ name: 'Product' })
                    swal({

                        text: "Product Added Successfully!",
                        icon: "success",
                        closeOnClickOutside: false,
                       
                    });
                })
                .catch(err => console.log(err));
        }
    },
    mounted() {}
}
</script>

<style scoped>
h4 {
    font-family: 'Roboto', sans-serif;
    color: #484848;
    font-weight: 700;
}


</style>
