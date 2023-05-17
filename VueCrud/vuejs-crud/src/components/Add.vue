<template>
<Header />

<h3>Add employee data</h3>
<div class="register-emp">
    <input type="text" v-model="name" placeholder="Enter Name" />
    <input type="text" v-model="address" placeholder="Enter Address" />
    <input type="number" v-model="contact" placeholder="Enter Contact" />
    <button v-on:click="addEmployee">Add Data</button>
    <br>
    <br>

</div>
</template>

<script>
import axios from 'axios'
import Header from './Header.vue'
export default {
    name: "Home",

    data() {
        return {

            name: '',
            address: '',
            contact: ''

        }
    },

    components: {
        Header
    },

    methods: {

        async addEmployee() {

            let result = await axios.post("http://localhost:3000/employee", {
                name: result.name,
                address: result.address,
                contact: result.contact
            })
            console.warn(result)
            if (result.status == 201) {
                alert("user Added Succefull")
            }
            this.$router.push({
                name: 'Home'
            })

        }
    }
}
</script>

<style>
.register-emp input {

    width: 300px;
    height: 40px;

    padding-left: 20px;

    display: block;

    margin-bottom: 30px;
    margin-left: auto;

    margin-right: auto;

    border: 1px solid skyblue;

}
</style>
