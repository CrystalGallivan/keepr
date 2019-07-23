<template>
  <div class="home">
    <div class="container-fluid navbar fixed-top navbar-light" id="top-navbar">
      <div class="row" id="nav-row">
        <h4>Welcome Home {{user.username}}</h4>
        <button class="btn btn-light btn-sm" v-if="user.id" @click="logout">Logout</button>
        <router-link v-else :to="{name: 'login'}">Login</router-link>
      </div>
    </div>
    <div class="row" id="keep-cards">
      <keeps v-for="keep in keeps" :keep="keep" />
    </div>
  </div>
</template>

<script>
  import Keeps from "@/components/Keeps.vue"
  export default {
    name: "home",
    computed: {
      user() {
        return this.$store.state.user;
      },
      keeps() {
        return this.$store.state.publicKeeps;
      }
    },
    mounted() {
      this.$store.dispatch("getAllKeeps")
    },
    methods: {
      logout() {
        this.$store.dispatch("logout");
      }
    },
    components: {
      Keeps
    }
  };
</script>
<style scoped>
  #top-navbar {

    background-color: #fff;
    color: black;
    font-family: 'Pacifico', cursive;
    height: 40px;
    font-size: 10px;

  }

  #navrow {
    display: flex;
    justify-content: space-between;
    align-content: space-between;
  }

  .navbar {
    height: 20px;
    padding-bottom: 20px;
    margin: 10px;

  }

  #keep-cards {
    display: flex;
    justify-content: center;
    padding: 60px;
  }
</style>