<template>
<Header />
<h3>Update employee data</h3>
<div class="update-emp">
    <input type="text" v-model="employee.name" placeholder="Enter Name" />
    <input type="text" v-model="employee.address" placeholder="Enter Address" />
    <input type="number" v-model="employee.contact" placeholder="Enter Contact" />
    <button v-on:click="updateEmployee">Update Data</button>
    <br>
    <br>

</div>
</template>

<script>
import axios from 'axios';
import Header from './Header.vue'
export default {
    name: "Home",

    components: {
        Header
    },

    data() {
        return {

            employee: {
                name: '',
                address: '',
                contact: ''
            }

        }
    },

      methods: {
      async  updateEmployee(){

            let result = await axios.put("http://localhost:3000/employee/"+this.$route.params.id, {
                name: this.employee.name,
                address: this.employee.address,
                contact: this.employee.contact
            })
            console.warn(result)
            if (result.status == 200) {
                alert("Data Updated Succefully")
            }
            this.$router.push({
                name: 'Home'
            })

        }
    },

    async mounted() {

        const result = await axios.get("http://localhost:3000/employee/" + this.$route.params.id)
        console.warn(result)
        this.employee = result.data
    },
}
</script>

<style>

.update-emp input {

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
