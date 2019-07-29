<template>
  <div class="home">
    <div class="container-fluid navbar navbar-light" id="top-navbar">
      <div class="row" id="nav-row-1">

        <!-- <p>Welcome {{user.username}}</p> -->
        <!-- </div>
      <div class="row"> -->

        <button class="btn btn-light btn-sm" id="logout-btn" v-if="user.id" @click="logout">Logout</button>
        <router-link v-else :to="{name: 'login'}">Login</router-link>

      </div>
    </div>
    <div class="row" style="margin-top: 100px;" id="keep-cards">
      <keeps v-if="keep.isPrivate == false" v-for="keep in keeps" :keep="keep" />
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
    /* display: flex;
    justify-content: space-evenly; */
    color: whitesmoke;
    font-family: 'Lobster', cursive;
    height: 40px;
    font-size: 30px;
    margin-top: -10px;
    float: left;
  }

  .navbar {
    height: 20px;
    padding-bottom: 20px;
    margin: 10px;
    display: flex;
    justify-content: flex-end;
    align-content: center;
  }

  #logout-btn {
    top: 0;
    margin-top: 57px;
    z-index: 1032;
  }

  #keep-cards {
    display: flex;
    justify-content: center;
    padding: 60px;
  }
</style>