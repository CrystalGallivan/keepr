<template>
    <div class="login">
        <form v-if="loginForm" @submit.prevent="loginUser">
            <input type="email" v-model="creds.email" placeholder="email">
            <input type="password" v-model="creds.password" placeholder="password">
            <button type="submit">Login</button>
        </form>
        <form v-else @submit.prevent="register">
            <input type="text" v-model="newUser.username" placeholder="name">
            <input type="email" v-model="newUser.email" placeholder="email">
            <input type="password" v-model="newUser.password" placeholder="password">
            <button type="submit">Create Account</button>
        </form>
        <div @click="loginForm = !loginForm">
            <p v-if="loginForm">No account Click to Register</p>
            <p v-else>Already have an account click to Login</p>
        </div>
        <div class="container-fluid">
            <div class="row" id="keep-cards">
                <keeps v-if="keep.isPrivate == false" v-for="keep in keeps" :keep="keep" />
            </div>
        </div>
    </div>
</template>

<script>
    import Keeps from "@/components/Keeps.vue"
    export default {
        name: "login",
        data() {
            return {
                loginForm: true,
                creds: {
                    email: "",
                    password: ""
                },
                newUser: {
                    email: "",
                    password: "",
                    username: ""
                }
            };
        },
        beforeCreate() {
            if (this.$store.state.user.id) {
                this.$router.push({ name: "home" })
            }
        },
        computed: {
            keeps() {
                return this.$store.state.publicKeeps;
            }
        },
        mounted() {
            this.$store.dispatch("getAllKeeps")
        },
        methods: {
            register() {
                this.$store.dispatch("register", this.newUser);
            },
            loginUser() {
                this.$store.dispatch("login", this.creds);
            }
        },
        components: {
            Keeps
        }
    };
</script>
<style scoped>
    #keep-cards {
        display: flex;
        justify-content: center;
    }
</style>