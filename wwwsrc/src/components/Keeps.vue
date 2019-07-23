<template>
  <div class="keeps" id="cards">
    <div class="card " id="keeps-card">
      <div class="card-body">
        <img :src="keep.img" width="300px" alt="I'm not here">
      </div>
      <h4><b>
          <div class="keep-title">{{keep.name}}</div>
        </b>
      </h4>
      <div class="card-footer">{{keep.description}}
        <!-- TODO Don't forget to remove this! -->
        <div class="status">{{keep.isPrivate}}</div>
        <div id="actions">
          <!-- TODO Figure out how to pass the keep id -->
          <button class="btn rounded-circle btn-light" title="Add to My Stache">
            <img src="../assets/icons8-english-mustache-50.png" height="30px" alt="I'm not here">
          </button>
          <button class="btn rounded-circle btn-light" title="Share">
            <img src="../assets/icons8-share-30.png" alt="I'm not here">
          </button>
          <button class="btn rounded-circle btn-light" title="Edit">
            <img src="../assets/icons8-pencil-20.png" alt="I'm not here">
          </button>
          <button @click="Delete()" class="btn rounded-circle btn-light" title="Delete">
            <img src="../assets/icons8-trash-can-30.png" alt="I'm not here">
          </button>
        </div>
      </div>
    </div>
  </div>
  </div>
</template>
<!-- shadow p-3 mb-5 bg-white rounded -->
<script>
  export default {
    name: "keeps",
    props: ["keep"],
    data() {
      return {}
    },
    methods: {
      Stache() {
        this.$store.dispatch("AddKeepToVault")
      },
      Share() {
        this.$store.dispatch("makePublic")
      },
      Edit() {
        this.$store.dispatch("EditKeep")
      },
      Delete() {
        this.$store.dispatch("DeleteKeep", keep.id)
      }
    }
  }
</script>
<style scoped>
  body {
    margin: 100px;
  }

  .keep-title {
    /* font-family: 'Asap', sans-serif; */
    font-family: 'Abril Fatface', cursive;
  }

  #actions {
    display: flex;
    justify-content: space-evenly;
  }

  #cards {
    display: flex;
    align-items: center;
    padding: 30px;
  }

  /* #keeps-card {} */
</style>