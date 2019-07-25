<template>
  <div class="vaults" id="cards">
    <div class="card " id="vaults-card">
      <div class="card-body">
      </div>

      
      <h4><b>
          <div @click="openVault" class="vault-title">{{vault.name}}</div>
        </b></h4>
      <div class="card-footer">{{vault.description}}
        <div id="actions">
          <!-- TODO Figure out how to pass the vault id -->
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
  import Stache from '@/views/Stache.vue'
  export default {
    name: "Vaults",
    props: ["vault"],
    data() {
      return {}
    },
    computed: {
      vaultKeeps() {
        return this.$store.state.vaultKeeps;
      }
    },
    methods: {
      Delete() {
        this.$store.dispatch("DeleteVault", this.vault.id)
      },
      openVault() {
        this.$store.dispatch("getKeepsByVault", this.vault.id)
      }
    },
    components: {
      Stache
    }
  }
</script>
<style scoped>
  body {
    margin: 100px;
  }

  .vault-title {
    /* font-family: 'Asap', sans-serif; */
    font-family: 'Abril Fatface', cursive;
  }

  #actions {
    display: flex;
    justify-content: space-evenly;
  }

  .card {
    height: 400px;
    width: 500px;
  }

  #cards {
    display: flex;
    align-items: center;
    padding: 30px;

  }

  /* #vaults-card {} */
</style>