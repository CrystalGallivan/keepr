<template>
  <div class="my-dashboard contianer-fluid">
    <div class="row">
      <h1>Welcome to the Dashboard Where you can manage your Staches and Keeps</h1>
    </div>
    <div class="row" id="create-forms">
      <div class="card rounded" id="card-form">
        <ul class="nav nav-tabs">
          <li class="nav-item">
            <a class="nav-link active" href="#">Keeps</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#">Staches</a>
          </li>
        </ul>
        <stach-form />
        <keep-form />
      </div>
    </div>
  </div>
</template>
<script>
  import KeepForm from "@/components/Forms.vue"
  export default {
    name: "MyDashboard",
    data() {
      return {

      }
    },

    components: {
      KeepForm
    }


  }
</script>
<style scoped>
  #create-forms {
    display: flex;
    justify-content: center;
    padding: 47px;
  }

  #card-form {
    display: flex;
    justify-content: center;
    padding: 20px;
    background-color: white;
    height: 600px;
    width: 700px;
  }
</style>