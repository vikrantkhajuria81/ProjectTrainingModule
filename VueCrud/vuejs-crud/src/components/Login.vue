<template>
    <h3>Login</h3>
    <div class="Login">
        <input type="email"  v-model="email"  placeholder="Enter Email" />
        <input type="password"   v-model="password" placeholder="Enter Password" />
        <button v-on:click="login">login</button>
    </div>
</template>

<script>
import axios from 'axios';
export default {
    name:'Login',
     data() {
        return {
            email: '',
            password: ''
        }
    },

    methods:
    {
        async login()
        {
            let result =  await axios.get(`http://localhost:3000/user?email=${this.email}&password=${this.password}`);

            console.log(result)
             if (result.status == 200 && result.data.length > 0) {
                // alert("SignUp Successfully");
                localStorage.setItem("user-info", JSON.stringify(result.data[0]))
                this.$router.push({ name: 'Home' })
            }
        } 
    },

     mounted() {
        let user = localStorage.getItem('user-info')
        if (user) {
            alert("already Logged in")
            this.$router.push({ name: 'Home' })
        }
    }
}
</script>


<style>
.Login input {

width: 300px; height: 40px;

padding-left: 20px;

display: block;

margin-bottom: 30px; margin-left: auto;

margin-right: auto;

border: 1px solid skyblue;

}
</style>