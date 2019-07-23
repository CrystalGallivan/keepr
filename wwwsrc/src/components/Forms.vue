<template>
  <div class="keep-form">
    <!-- <div class="tab-pane fade show active" id="nav-keeps" role="tabpanel" aria-labelledby="nav-keeps-tab"> -->
    <form @submit.prevent="AddKeep">
      <h1>Make a Keep</h1>
      <div class="form-group mb-2">
        <label for="title" class="sr-only">Title</label>
        <input v-model="newKeep.name" type="text" class="form-control-plaintext rounded" id="title" value="Title">
      </div>
      <div class="form-group mb-2">
        <label for="description" class="sr-only">Description</label>
        <textarea v-model="newKeep.description" type="text" class="form-control-plaintext rounded" id="description"
          value="Description"></textarea>
      </div>
      <div class="form-group">
        <label for="image">Image</label>
        <input v-model="newKeep.img" type="url" class="form-control-plaintext rounded" id="image">
      </div>
      <div class="custom-control custom-switch">
        <input v-model="newKeep.isPrivate" type="checkbox" class="custom-control-input rounded" id="isPrivate">
        <label class="custom-control-label" for="isPrivate">Keep Private?</label>
      </div>
      <button class="btn btn-outline-dark" type="submit">Post</button>
    </form>
    <!-- </div> -->
  </div>
</template>
<script>
  export default {
    name: "KeepForm",
    data() {
      return {
        newKeep: {
          name: '',
          description: '',
          img: '',
          isPrivate: false
        }
      }
    },
    methods: {
      AddKeep() {
        this.$store.dispatch("CreateKeep", this.newKeep)
        this.newKeep = {}
      }
    }


  }
</script>
<style scoped>
  /* #card-form {
    padding: 20px;
    background-color: white;
  } */

  h1 {
    font-family: 'Lobster', cursive;
  }

  .keep-form {
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