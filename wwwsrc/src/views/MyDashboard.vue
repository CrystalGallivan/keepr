<template>
  <div class="my-dashboard contianer-fluid">
    <div class="row">
      <h1>Welcome to the Dashboard Where you can manage your Staches and Keeps</h1>
    </div>
    <div class="row" id="create-forms">
      <div class="card rounded" id="card-form">
        <ul class="nav nav-tabs" id="nav-tab" role="tablist">
          <li class="nav-item">
            <a class="nav-link active" id="nav-keeps-tab" data-toggle="tab" href="#nav-keeps" role="tab"
              aria-controls="nav-keeps" aria-selected="true">Keeps</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" id="nav-stache-tab" data-toggle="tab" href="#nav-stache" role="tab"
              aria-controls="nav-stache">Staches</a>
          </li>
        </ul>
        <div class="tab-content" id="nav-tabContent">
          <div class="tab-pane fade" id="nav-stache" role="tabpanel" aria-labelledby="nav-stache-tab">
            <stache-form />
          </div>
          <div class="tab-pane fade show active" id="nav-keeps" role="tabpanel" aria-labelledby="nav-keeps-tab">
            <keep-form />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
  import KeepForm from "@/components/Forms.vue"
  import StacheForm from "@/components/StacheForm.vue"
  export default {
    name: "MyDashboard",
    data() {
      return {

      }
    },

    components: {
      KeepForm,
      StacheForm
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