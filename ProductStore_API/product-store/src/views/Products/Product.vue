<template>
<Navbar />
<div class="container">
    <div class="row">

        <div class="col-12 text-center">

            <br>
            <div id="app">
                <input v-model="searchQuery" placeholder="Search Here" style="width:500px">
                <div v-for="r of resultQuery" :key="r.id">

                    <div class="card w-100 h-100" style="margin-top: 10px; margin-left:45px;">

                        <div class="card-body" style="margin-left: 10px;">
                            <router-link :to="{ name: 'ProductDetails', params: { id: r.id } }">
                                <h5 class="card-title">{{ r.title }}</h5>
                            </router-link>

                            <p class="card-text">
                                {{ r.description.substring(0, 40) }}...
                            </p>

                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <br>
    <table id="customers" border="2" style="width:100%; margin-left: 30px;">

        <tr>
            <td>Id</td>
            <td>Title</td>
            <td>Description</td>
            <td>Price</td>
            <td>discountPercentage</td>
            <td>rating</td>
            <td>stock</td>
            <td>brand</td>
            <td>category</td>
            <td> Show Details</td>
            <td>Update</td>
            <td>Delete</td>

        </tr>
        <tr v-for="product in paginatedItems" :key="product.id">
            <td>{{ product.id }} </td>
            <td>{{ product.title }} </td>
            <td> {{ product.description.substring(0, 30) }}... </td>
            <td>{{ product.price }} </td>
            <td>{{ product.discountPercentage }} </td>
            <td>{{ product.rating }} </td>
            <td>{{ product.stock }} </td>
            <td>{{ product.brand }} </td>
            <td>{{ product.category }} </td>

            <td>
                <router-link :to="'/productdetails/' + product.id">
                    <i class="fa-solid fa-circle-info"></i>
                </router-link>
            </td>

            <td>
                <router-link :to="'/edit/' + product.id">
                    <i class="fa fa-edit"></i>
                </router-link>
            </td>

            <td>
                <i class="fa-solid fa-trash" style="color: #0d35fd;" v-on:click="delProduct(product.id)"></i>

            </td>
        </tr>
    </table>
<br>
    <div>
    
        <div>
            <button @click="previousPage" :disabled="currentPage === 1">Previous</button>
            <span>{{ currentPage }}</span>
            <button @click="nextPage" :disabled="currentPage === totalPages">Next</button>
        </div>
    </div>

</div>
</template>

<script>
import axios from 'axios';
import Navbar from '../../components/Navbar.vue'

export default {
    name: "Product",
    props: ["products", "baseURL"],

    components: {
        Navbar
    },

    data() {
        return {
            searchQuery: null,
            currentPage: 1,
            itemsPerPage: 4,
            totalPages:1

        };
    },

    methods: {
        async delProduct(id) {
            
            let result = await axios.delete(`${"http://localhost:5265/api/Product/delete?id="}${id}`)
         
            if (result.status == 200) {
                alert("Data Deleted Successfully")
            }
        },

        fetchItems() {
            axios.get(this.baseURL + "/getall").then(response => {
                this.product = response.data;
                this.totalPages = Math.ceil(this.product.length / this.itemsPerPage);
            }).catch(error => {
                console.error(error);
            });
        },

         previousPage() {
            if (this.currentPage > 1) {
                this.currentPage--;
            }
        },
        nextPage() {
            if (this.currentPage < this.totalPages) {
                this.currentPage++;
            }
        }
    },

    mounted(){
        this.fetchItems()
    },

    computed: {
        resultQuery() {
            if (this.searchQuery) {
                return this.products.filter(item => {
                    return this.searchQuery
                        .toLowerCase()
                        .split(" ")
                        .every(v => item.title.toLowerCase().includes(v));
                });
            } else {
                return this.resources;
            }
        },

          paginatedItems() {
            const startIndex = (this.currentPage - 1) * this.itemsPerPage;
            const endIndex = startIndex + this.itemsPerPage;
            return this.products.slice(startIndex, endIndex);
        }
    }
};
</script>

<style scoped>
.btn:focus,
.btn:active {
    outline: none !important;
    box-shadow: none !important;
    -webkit-box-shadow: none !important;
}

#customers {
  font-family: Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

#customers td, #customers th {
  border: 1px solid #ddd;
  padding: 8px;
}

#customers tr:nth-child(even){background-color: #f2f2f2;}

#customers tr:hover {background-color: #ddd;}

#customers th {
  padding-top: 12px;
  padding-bottom: 12px;
  text-align: left;
  background-color: #04AA6D;
  color: white;
}
</style>
