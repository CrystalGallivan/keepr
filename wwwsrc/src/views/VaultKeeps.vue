<template>
  <div class="vault-keeps container-fluid" id="vault-style">
    <div class="row">
      <vaults v-if="vault.userId == user.id" v-for="vault in vaults" :vault="vault" />
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
      },
      user() {
        return this.$store.state.user
      }
    },
    components: {
      Vaults
    }
  }
</script>
<style>
  #vault-style {
    display: flex;
    justify-content: center;
    padding: 75px;
  }
</style>