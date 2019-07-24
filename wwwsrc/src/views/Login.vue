<template>
    <div class="login">
        <!-- <button type="button" id="login-button" class="btn btn-light" data-toggle="modal" data-target="#loginModal">
            Login
        </button> -->

        <div class="modal fade" id="loginModal" tabindex="-1" role="dialog" aria-labelledby="loginModalTitle"
            aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="loginModalTitle">Login</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <form v-if="loginForm" @submit.prevent="loginUser">
                            <input class="rounded" type="email" v-model="creds.email" placeholder="email">
                            <input class="rounded" type="password" v-model="creds.password" placeholder="password">
                            <button class="btn btn-outline-dark" type="submit">Login</button>
                        </form>
                        <form v-else @submit.prevent="register">
                            <input class="rounded" type="text" v-model="newUser.username" placeholder="name">
                            <input class="rounded" type="email" v-model="newUser.email" placeholder="email">
                            <input class="rounded" type="password" v-model="newUser.password" placeholder="password">
                            <button class="btn btn-outline-dark" type="submit">Create Account</button>
                        </form>
                        <div class="modal-footer">
                            <div @click="loginForm = !loginForm">
                                <p v-if="loginForm">No account Click to Register</p>
                                <p v-else>Already have an account click to Login</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
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
                $("#loginModal").modal("hide");
                $(".modal-backdrop").remove();
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

    .modal-body {
        display: flex;
        justify-content: center;
    }

    #login-button {
        float: inline-start;
        z-index: 10;
    }

    input {
        display: block;
        flex-direction: column;
    }
</style>