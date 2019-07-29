<template>
  <div class="vkeep" id="cards">
    <div class="card " id="keeps-card" @click="Views">
      <div class="card-body">
        <img :src="vkeep.img" width="300px" alt="I'm not here">
      </div>
      <small id="icons">
        <img v-if="vkeep.isPrivate == true" src="../assets/icons8-secure-18.png" alt="">
        <img src="../assets/icons8-eye-18.png" alt="">{{vkeep.views}}
        <img src="../assets/icons8-english-mustache-18.png" alt="">{{vkeep.keeps}}</small>
      <div class="card-footer">{{vkeep.description}}
        <div id="actions">
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
      //TODO Create the option to share
      //     Share() {
      //   this.$store.dispatch("makePublic")
      // },
      Delete() {
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