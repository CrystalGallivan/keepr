<template>
  <div class="user-keeps container-fluid">
    <div class="row">
      <keeps v-for="keep in keeps" :keep="keep" />
    </div>
  </div>
</template>
<script>
  import Keeps from "@/components/Keeps.vue"
  export default {
    name: "UserKeeps",
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch("getByUser")
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      }
    },
    components: {
      Keeps
    }
  }
</script>
<style>
</style>