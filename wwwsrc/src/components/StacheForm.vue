<template>
  <div class="stache-form">
    <!-- <div class="tab-pane fade" id="nav-stache" role="tabpanel" aria-labelledby="nav-stache-tab"> -->
    <form @submit.prevent="AddStache">
      <h1>Make a Stache</h1>
      <div class="form-group mb-2">
        <label for="title" class="sr-only">Title</label>
        <input v-model="newVault.name" type="text" class="form-control-plaintext rounded" id="title" value="Title">
      </div>
      <div class="form-group mb-2">
        <label for="description" class="sr-only">Description</label>
        <textarea v-model="newVault.description" type="text" class="form-control-plaintext rounded" id="description"
          value="Description"></textarea>
      </div>
      <button class="btn btn-outline-dark" type="submit">Create Stache</button>
    </form>
    <!-- </div> -->
  </div>
</template>
<script>
  export default {
    name: "StacheForm",
    data() {
      return {
        newVault: {
          name: '',
          description: ''
        }
      }
    },
    methods: {
      AddStache() {
        this.$store.dispatch("CreateVault", this.newVault)
        this.newVault = {}
      }
    }


  }
</script>
<style scoped>
  h1 {
    font-family: 'Lobster', cursive;
  }

  .stache-form {
    padding: 47px;
    display: flex;
    justify-content: center;
    align-content: center;
  }

  input {
    background-color: black;
    color: whitesmoke;
    width: 600px;
  }

  textarea {
    background-color: black;
    color: whitesmoke;
    width: 600px;
    height: 150px;
  }
</style>