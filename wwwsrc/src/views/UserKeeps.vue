<template>
  <div class="user-keeps container-fluid">
    <div class="row" id="user-keeps" style="margin-top: 100px">
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
        return this.$store.state.userKeeps
      }
    },
    components: {
      Keeps
    }
  }
</script>
<style>
  #user-keeps {
    display: flex;
    justify-content: center;
    align-content: center;
  }
</style>