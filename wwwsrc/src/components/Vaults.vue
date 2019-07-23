<template>
  <div class="vaults" id="cards">
    <div class="card " id="vaults-card">
      <div class="card-body">
      </div>
      <h4><b>
          <div class="vault-title">{{vault.name}}</div>
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
  export default {
    name: "Vaults",
    props: ["vault"],
    data() {
      return {}
    },
    methods: {
      Delete() {
        this.$store.dispatch("DeleteKeep", vault.id)
      }
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

  #cards {
    display: flex;
    align-items: center;
    padding: 30px;
  }

  /* #vaults-card {} */
</style>