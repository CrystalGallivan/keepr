<template>
  <div class="keeps" id="cards">
    <div class="card " id="keeps-card" @click="Views">
      <!-- @click="SelectKeep" -->
      <div class="card-body">
        <img :src="keep.img" width="300px" alt="I'm not here">
      </div>
      <small id="icons"><img src="../assets/icons8-eye-18.png" alt="">{{keep.views}}<img
          src="../assets/icons8-english-mustache-18.png" alt="">{{keep.keeps}}</small>
      <h4><b>
          <div class="keep-title">{{keep.name}}</div>
        </b>
      </h4>
      <div class="card-footer">{{keep.description}}
        <!-- TODO Don't forget to remove this! -->

        <!-- <div class="status">{{keep.isPrivate}}-{{keep.keeps}}-{{keep.views}} </div> -->
        <div id="actions">
          <!-- TODO Figure out how to pass the keep id -->
          <div class="dropdown">
            <button class="btn rounded-circle btn-light dropdown-toggle" type="button" id="vaultDropDown"
              title="Add to My Stache" data-toggle="dropdown" aria-haspopup="true" arie-expanded="fasle">
              <img src="../assets/icons8-english-mustache-50.png" height="30px" alt="I'm not here">
            </button>
            <div class="dropdown-menu" aria-labelledby="vaultDropDown">
              <a class="dropdown-item" @click="Stache(vault.id)" :value="vault.id" v-for="vault in vaults"
                href="#">{{vault.name}}-{{vault.id}}</a>

            </div>
          </div>
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
    props: ["keep", "vault"],
    data() {
      return {
        vaultKeep: {
          userId: "",
          vaultId: 0,
          keepId: 0,
        },
        // vault: {}
      }
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      },
      user() {
        return this.$store.state.user
      },
    },
    methods: {
      Views() {
        this.keep.views += 1
      },
      Stache(id) {
        this.vaultKeep.keepId = this.keep.id
        this.vaultKeep.userId = this.user.id
        this.vaultKeep.vaultId = id
        this.keep.keeps += 1
        this.$store.dispatch("AddKeepToVault", this.vaultKeep)
        alert("Keep added to Stache")
      },
      Share() {
        this.$store.dispatch("makePublic")
      },
      Edit() {
        this.$store.dispatch("EditKeep")
      },
      Delete() {
        this.$store.dispatch("DeleteKeep", this.keep.id)
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