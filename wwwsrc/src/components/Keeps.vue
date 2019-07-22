<template>
  <div class="keeps" id="cards">
    <div class="card" id="keeps-card">
      <div class="card-body">
        <img src="keep.img" alt="I'm not here">
      </div>
      <div class="card-header">{{keep.name}}</div>
      <div class="card-footer">{{keep.description}}</div>
    </div>
  </div>
  </div>
</template>
<script>
  export default {
    name: "keeps",
    props: ["keep"],
    data() {
      return {}
    }
  }
</script>
<style>
  #cards {
    display: flex;
    align-items: center;
    padding: 50px;
  }

  #keeps-card {
    max-width: 200px;
    max-height: 300px;
  }
</style>