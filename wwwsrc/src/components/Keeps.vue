<template>
  <div class="keeps" id="cards">
    <div class="grid" v-draggabilly v-packery='{itemSelector: ".packery-item", percentPosition: true}'>
      <div v-draggabilly v-packery-item class='packery-item'>


        <div class="card " id="keeps-card" style="padding: 20px;" @click="Views">
          <!-- @click="SelectKeep" -->
          <div class="card-body">
            <img :src="keep.img" width="300px" alt="I'm not here">
          </div>
          <small id="icons">
            <img v-if="keep.isPrivate == true" src="../assets/icons8-secure-18.png" alt="">
            <img src="../assets/icons8-eye-18.png" alt="">{{keep.views}}
            <img src="../assets/icons8-english-mustache-18.png" alt="">{{keep.keeps}}</small>
          <h4><b>
              <div class="keep-title">{{keep.name}}</div>
            </b>
          </h4>
          <div class="card-footer">{{keep.description}}
            <div id="actions">
              <div class="dropdown">
                <button class="btn rounded-circle btn-light dropdown-toggle" type="button" id="vaultDropDown"
                  title="Add to My Stache" data-toggle="dropdown" aria-haspopup="true" arie-expanded="fasle">
                  <img src="../assets/icons8-english-mustache-50.png" height="30px" alt="I'm not here">
                </button>
                <div class="dropdown-menu" aria-labelledby="vaultDropDown">
                  <a class="dropdown-item" v-if="vault.userId == user.id" @click="Stache(vault.id)" :value="vault.id"
                    v-for="vault in vaults" href="#">{{vault.name}}</a>
                </div>
              </div>
              <button class="btn rounded-circle btn-light" title="Share">
                <img src="../assets/icons8-share-30.png" alt="I'm not here">
              </button>
              <!-- <button class="btn rounded-circle btn-light" title="Edit">
              <img src="../assets/icons8-pencil-20.png" alt="I'm not here">
            </button> -->
              <button @click="Delete()" v-if="keep.isPrivate == true" class="btn rounded-circle btn-light"
                title="Delete">
                <img src="../assets/icons8-trash-can-30.png" alt="I'm not here">
              </button>
            </div>
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
    props: ["keep", "vault", "vkeep"],
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
        this.$store.dispatch("EditKeep", this.keep)
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
        this.$store.dispatch("EditKeep", this.keep)
      },
      Stache(id) {
        this.vaultKeep.keepId = this.keep.id
        this.vaultKeep.userId = this.user.id
        this.vaultKeep.vaultId = id
        this.keep.keeps += 1
        this.$store.dispatch("AddKeepToVault", this.vaultKeep)
        alert('Keep added to Stache')
        // TODO add a sweetalert
        Vue.Swal('Keep added to Stache');
      },
      // Share() {
      //   this.$store.dispatch("makePublic")
      // },
      // Edit() {
      //   this.$store.dispatch("EditKeep")
      // },
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

  .card-columns {
    display: inline-block;

    /* @include media-breakpoint-only(lg) {
      column-count: 4;
    }

    @include media-breakpoint-only(xl) {
      column-count: 5; */
    /* /* } */
  }

  /* #keeps-card {} */
</style>