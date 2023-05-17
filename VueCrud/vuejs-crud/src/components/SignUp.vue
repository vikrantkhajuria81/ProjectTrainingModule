<template>


    <h3>Sign Up</h3>
    <div class="register">
        <input type="text" v-model="name" placeholder="Enter Name" />
        <input type="email" v-model="email" placeholder="Enter Email" />  
        <input type="password" v-model="password" placeholder="Enter Password" />
        <button v-on:click="signup">Sign Up</button>
        <br>
        <br>
        <button>
        <router-link to="/login">login</router-link>
        </button>
    </div>

</template>

<script>
import axios from 'axios'
export default {
    name:'SignUp',

    data(){
        return{
            name:'',
            email:'',
            password:''
        }
    },
     methods: {

           async signup(){
            
                let result = await axios.post("http://localhost:3000/user",{
                    name: this.name,
                    email: this.email,
                    password: this.password
                })
                console.warn(result)

                if(result.status==201){
                    // alert("SignUp Successfully");
                     localStorage.setItem("user-info", JSON.stringify(result.data))
                     this.$router.push({name:'Home'})
                }

            }
    },

    mounted(){
        let user= localStorage.getItem('user-info')
        if(user){
            this.$router.push({name:'Home'})
        }
    }

}

</script>

<style>

.register input {

width: 300px; height: 40px;

padding-left: 20px;

display: block;

margin-bottom: 30px; margin-left: auto;

margin-right: auto;

border: 1px solid skyblue;

}


.register button{

width: 320px;

height: 40px;

border: 1px solid skyblue;

color: #fff;

background-color: skyblue;

cursor: pointer;

}

.register p{
    width: 320px;

height: 40px;

border: 1px solid skyblue;

color: #fff;

background-color: skyblue;

cursor: pointer;

}

</style>