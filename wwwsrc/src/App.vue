<template>
  <div id="app">
    <nav class="container-fluid navbar fixed-bottom navbar-light bg-light">
      <div class="row" id="navbar">
        <a class="navbar-brand" href="#">Stache</a>
        <img src="assets/icons8-english-mustache-50.png" alt="">
        <form class="form-inline my-2 my-lg-0">
          <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search">
          <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
        </form>
        <button class="btn btn-light">My Staches</button>
        <!-- TODO rename this to something to do with mustaches -->
        <button class="btn btn-light">My Keeps</button>
      </div>

    </nav>
    <router-view />
  </div>
</template>

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

  .navbar {
    height: 75px;
    display: flex;
    justify-content: center;
    align-content: space-between;
    flex-direction: row;
  }
</style>