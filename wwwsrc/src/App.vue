<template>
  <div id="app">
    <router-view />
    <nav class="container-fluid navbar fixed-top navbar-light bg-light">
      <div class="row" id="navbar">
        <div class="nav-item-1">
          <router-link to="/">
            <img src="../src/assets/mustache-final.jpg" alt="">
          </router-link>
          <a class="navbar-brand"
            style="font-family: 'Lobster', cursive; font-size: 45px; padding: 0px; margin-top: -18px;" to="/">Stache</a>
        </div>
        <div class="nav-item-2">
          <form class="form-inline">
            <input class="form-control" style="max-width: 600px" type="search" placeholder="Search" aria-label="Search">
            <button class="btn btn-outline-dark" type="submit">Search</button>
          </form>
        </div>
        <div v-if="user.id" class="nav-item-3">
          <button class="btn btn-light btn-sm">
            <router-link to="/vaults">My Staches</router-link>
          </button>
          <!-- TODO rename this to something to do with mustaches -->
          <button class="btn btn-light btn-sm" to="/keeps">
            <router-link to="/keeps">My Keeps</router-link>
          </button>
          <button class="btn btn-light btn-sm" to="/dashboards">
            <router-link to="/dashboards">My Dashboard</router-link>
          </button>
        </div>
        <div v-else class="nav-item-3">
          <button type="button" id="login-button" class="btn btn-light" data-toggle="modal" data-target="#loginModal">
            Login
          </button>
        </div>
      </div>
    </nav>

  </div>
</template>

<script>
  export default {
    name: "app",
    data() {
      return {

      }
    },
    computed: {
      user() {
        return this.$store.state.user
      }
    },
    components: {

    }
  }
</script>
<style>
  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  body {
    background-color: black;
    color: whitesmoke;
  }

  .nav-item-1 {
    display: flex;
    align-content: center;
    padding: 10px;
  }

  .nav-item-3 {
    padding: 10px;
    margin-right: 40px;
  }

  button {
    color: black;
    font-family: 'Varela Round', sans-serif;
  }

  #navbar {
    width: 100%;
    display: flex;
    justify-content: space-between;

  }

  .navbar {
    height: 65px;
    display: flex;
    justify-content: space-around;
    page-break-after: auto;

  }
</style>