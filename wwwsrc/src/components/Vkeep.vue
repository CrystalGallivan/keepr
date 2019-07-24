<template>
  <div class="vkeep" id="cards">
    <div class="card " id="keeps-card" @click="Views">
      <!-- @click="SelectKeep" -->
      <div class="card-body">
        <img :src="vkeep.img" width="300px" alt="I'm not here">
      </div>
      <small id="icons">
        <img v-if="vkeep.isPrivate == true" src="../assets/icons8-secure-18.png" alt="">
        <img src="../assets/icons8-eye-18.png" alt="">{{vkeep.views}}
        <img src="../assets/icons8-english-mustache-18.png" alt="">{{vkeep.keeps}}</small>
      <h4><b>
          <div class="keep-title">{{vkeep.keeps}}</div>
        </b>
      </h4>
      <div class="card-footer">{{vkeep.description}}
        <!-- TODO Don't forget to remove this! -->

        <div class="status">{{vkeep.isPrivate}}</div>
        <div id="actions">
          <!-- TODO Figure out how to pass the keep id -->
          <!-- <div class="dropdown">
            <button class="btn rounded-circle btn-light dropdown-toggle" type="button" id="vaultDropDown"
              title="Add to My Stache" data-toggle="dropdown" aria-haspopup="true" arie-expanded="fasle">
              <img src="../assets/icons8-english-mustache-50.png" height="30px" alt="I'm not here">
            </button> -->
          <!-- <div class="dropdown-menu" aria-labelledby="vaultDropDown">
              <a class="dropdown-item" v-if="vault.userId == user.id" @click="Stache(vault.id)" :value="vault.id"
                v-for="vault in vaults" href="#">{{vault.name}}</a>

            </div> -->
          <!-- </div> -->
          <button class="btn rounded-circle btn-light" title="Share">
            <img src="../assets/icons8-share-30.png" alt="I'm not here">
          </button>
          <!-- <button class="btn rounded-circle btn-light" title="Edit">
            <img src="../assets/icons8-pencil-20.png" alt="I'm not here">
          </button> -->
          <button @click="Delete()" v-if="vkeep.isPrivate == true" class="btn rounded-circle btn-light" title="Delete">
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
    name: "vkeep",
    props: ["keep", "vkeep"],
    data() {
      return {
        vaultKeep: {
          userId: "",
          vaultId: 0,
          keepId: 0,
        }
      }
    },
    mounted() {
      return this.$store.dispatch("getAllVaults")
    },
    watch: {
      Keeps() {
        this.$store.dispatch("EditKeep", this.vkeep)
      }
    },
    computed: {
      vault() {
        return this.$store.state.vault
      },
      user() {
        return this.$store.state.user
      },
    },
    methods: {
      Views() {
        this.vkeep.views += 1
        this.$store.dispatch("EditKeep", this.keep)
      },
      // Stache(id) {
      //   this.vaultKeep.keepId = this.vkeep.id
      //   this.vaultKeep.userId = this.user.id
      //   this.vaultKeep.vaultId = id
      //   this.vkeep.keeps += 1
      //   this.$store.dispatch("AddKeepToVault", this.vaultKeep)
      //   alert('Keep added to Stache')
      //   // TODO add a sweetalert
      //   // Vue.swal('Keep added to Stache');
      // },
      Share() {
        this.$store.dispatch("makePublic")
      },
      Edit() {
        this.$store.dispatch("EditKeep")
      },
      Delete() {
        debugger
        this.vaultKeep.keepId = this.vkeep.id
        this.vaultKeep.userId = this.user.id
        this.vaultKeep.vaultId = this.vault
        this.$store.dispatch("RemoveKeepFromVault", this.vaultKeep)
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