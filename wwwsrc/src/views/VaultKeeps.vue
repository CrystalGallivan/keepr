<template>
  <div class="vault-keeps container-fluid" id="vault-style">
    <div class="row" style="margin-top: 100px;">
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
      setTimeout(() => {
        this.getVault1();
        this.getVault2();
        this.getVault3();
      }, 1000);


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
    },
    methods: {
      getVault1() {
        if (this.$store.state.vault1) {
          this.$store.dispatch("getKeepsByVault1", this.$store.state.vault1.id)
        }
      },
      getVault2() {
        if (this.$store.state.vault2) {
          this.$store.dispatch("getKeepsByVault2", this.$store.state.vault2.id)
        }
      },
      getVault3() {
        if (this.$store.state.vault3) {
          this.$store.dispatch("getKeepsByVault3", this.$store.state.vault3.id)
        }
      }
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