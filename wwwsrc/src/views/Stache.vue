<template>
  <div class="stache">
    <div>
      <div style="margin-top: 100px">
        <p id="header"> Personal Stache</p>
        <p id="header-2">{{this.vault.name}}</p>
      </div>
      <div class="row" id="vault-keeps">
        <vkeep v-for="vkeep in vaultKeeps" :vkeep="vkeep" />
      </div>
      <div>

      </div>
    </div>
  </div>
</template>

<script>
  import vkeep from '@/components/Vkeep.vue'
  export default {
    name: "Stache",
    data() {
      return {

      }
    },
    computed: {
      vaultKeeps() {
        return this.$store.state.vaultKeeps
      },
      vault() {
        return this.$store.state.vault
      }
    },
    components: {
      vkeep
    }

  }
</script>
<style scoped>
  #header {
    font-family: 'Lobster', cursive;
    color: whitesmoke;
    font-size: 75px;
  }

  #header-2 {
    font-family: 'Lobster', cursive;
    color: whitesmoke;
    font-size: 55px;
  }

  #vault-keeps {
    display: flex;
    justify-content: center;
  }
</style>