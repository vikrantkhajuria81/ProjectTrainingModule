<template>
<Header />
<h2>Hello Welcom to Home Page Home page</h2>

<table border="1">

    <tr>
        <td>Id</td>
        <td>Name</td>
        <td>Address</td>
        <td>Contact</td>
        <td>Update</td>
        <td>Delete</td>
    </tr>
    <tr v-for="item in employee" :key="item.id">
        <td>{{ item.id }} </td>
        <td>{{ item.name }} </td>
        <td>{{ item.address }} </td>
        <td>{{ item.contact }} </td>
        <td>
            <router-link :to="'/update/'+item.id">Update</router-link>
        </td>
        <td><button v-on:click="delEmployee(item.id)">Delete</button></td>
    </tr>
</table>
</template>

<script>
import axios from 'axios'
import Header from './Header.vue'
export default {
    name: "Home",
    data() {
        return {

            employee: [],
        }
    },

    components: {
        Header
    },

    methods:{
       async  delEmployee(id)
        {
              let result = await axios.delete("http://localhost:3000/employee/"+ id)

              if(result.status== 200){
                alert("Data Deleted Successfully")
                this.loadPage()
              }
        },

        async loadPage(){
            let user = localStorage.getItem('user-info')
            if (!user) {
                this.$router.push({
                    name: 'SignUp'
                })
            }

            let result = await axios.get("http://localhost:3000/employee")
            console.warn(result)
            this.employee = result.data
        }
    },

    async mounted() {
      this.loadPage()
    }

}
</script>

<style>
td {
    width: 160px;
    height: 40px;
}
</style>
