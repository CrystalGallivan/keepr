<template>
  <div class="vault-keeps container-fluid">
    <div class="row">
      <vaults v-for="vault in vaults" :vault="vault" />
    </div>
  </div>
</template>
<script>
  import Vaults from "@/components/Vaults.vue"
  export default {
    name: "VaultKeeps",
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch("getAllVaults")
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }
    },
    components: {
      Vaults
    }
  }
</script>
<style>
</style>