<template>
  <v-app>
    <!-- <v-app-bar
      app
      color="primary"
      dark
    >
      
       <v-toolbar-title style="width: 400px" class="ml-0 pl-4">
        <span class="hidden-sm-and-down">RS.GE</span>
      </v-toolbar-title>

      <v-spacer></v-spacer>
     სისტემაში შემოსულია :
      {{currentUser.id}}
      {{currentUser.name}}
      
    </v-app-bar> -->

    <v-content>
     <router-view />
    </v-content>
  </v-app>
</template>

<script>

export default {
  name: 'App',

  data: () => ({
    //
    currentUser: {
      id: null,
      name: null
    }
  }),
  async created() {
    this.currentUser = await this.$http.getTin();
     console.log('this.currentUser----------------------------------',this.currentUser);
  },
};
</script>
