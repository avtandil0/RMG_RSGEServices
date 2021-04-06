<template>
  <div class="home">
     <v-app-bar
      app
      color="primary"
      dark
    >
      
       <v-toolbar-title style="width: 400px" class="ml-0 pl-4">
        <span class="hidden-sm-and-down">RS.GE</span>
      </v-toolbar-title>

      <v-spacer></v-spacer>
     სისტემაში შემოსულია :
      <!-- {{currentUser.fullName}}
      {{currentUser.persNo}}
      {{currentUser.payerTypeName}} -->
      
      <v-tooltip bottom>
        <template v-slot:activator="{ on }">
          <v-btn v-on="on" icon @click="logOut()">
            <v-icon>mdi-logout</v-icon>
          </v-btn>
        </template>
        <span>გასვლა</span>
      </v-tooltip>
    </v-app-bar>

    <v-content>
     <router-view />
    </v-content>
  </div>
</template>

<script>
// @ is an alias to /src

export default {
  name: 'Home',
  data() {
    return {
       currentUser: {
      fullName: "",
      payerTypeName: "",
      persNo: ""
    }
    };
  },
  created() {
    // this.currentUser = JSON.parse(localStorage.getItem("currentUser"));
    console.log('00000000000',this.currentUser)

  },
  methods: {
    logOut(){
      
      localStorage.clear();
      window.location.replace("#/Login");
      location.reload();
    }
  }

 
}
</script>
