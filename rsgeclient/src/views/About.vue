<template>
  <div class="about">
    <h1>This is an about page</h1>
  </div>
</template>
<script>
// @ is an alias to /src

export default {
  name: 'About',
  async created() {
    console.log(this.$route);

    var test  = await this.$http.getTest();
    console.log(test)
  }
}
</script>