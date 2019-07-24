<template>
  <div class="keeps-in-vault">
    <!-- <keeps :vkeep="vkeep" />
    {{vkeep.img}}
    {{vkeep.name}}
    {{vkeep.description}} -->
  </div>
</template>
<script>
  import Keeps from '@/components/Keeps.vue'
  export default {
    name: "KeepsInVault",
    props: ["vkeep"],
    data() {
      return {

      }
    },
    components: {
      Keeps
    }
  }
</script>
<style scoped>

</style>