<template>
  <div>
   
    <v-layout align-center justify-center style="padding-top:200px">
      <!-- <v-flex xs12 sm12>
      ეკონომიკური საქმიანობების განმახორციელებელმა დაწესებულებებმა
      განაცხადის ელექტრონულად შესავსვებად ავტორიზაცია უნდა
      გაიარონ შემოსავლების სამსახურის (RS.ge)- ის მომხმარებლითა და პაროლით
      </v-flex>-->
      <v-flex xs12 sm8 md4>
        <v-card class="elevation-12" id="test">
          <form>
            <v-toolbar color="primary" dark flat>
              <v-toolbar-title>ავტორიზაცია</v-toolbar-title>
              <v-spacer></v-spacer>
              <!-- <v-tooltip bottom>
                  <template v-slot:activator="{ on }">
                    <v-btn
                      :href="source"
                      icon
                      large
                      target="_blank"
                      v-on="on"
                    >
                      <v-icon>mdi-code-tags</v-icon>
                    </v-btn>
                  </template>
                  <span>Source</span>
                </v-tooltip>
                <v-tooltip right>
                  <template v-slot:activator="{ on }">
                    <v-btn
                      icon
                      large
                      href="https://codepen.io/johnjleider/pen/pMvGQO"
                      target="_blank"
                      v-on="on"
                    >
                      <v-icon>mdi-codepen</v-icon>
                    </v-btn>
                  </template>
                  <span>Codepen</span>
              </v-tooltip>-->
            </v-toolbar>
            <v-card-text>
              <v-form>
                <v-text-field disabled="" label="მომხმარებელი" v-model="userName" type="text"></v-text-field>

                <v-text-field
                disabled=""
                  v-if="!newPassBoxVisible"
                  label="პაროლი"
                  v-model="password"
                  type="password"
                  v-on:keyup.13="onLogin"
                ></v-text-field>
                <v-text-field
                  disabled
                  v-if="newPassBoxVisible"
                  label="ახალი პაროლი"
                  v-model="newPassword"
                  prepend-icon="lock"
                  type="password"
                  v-on:keyup.13="onLogin"
                ></v-text-field>
                <v-text-field
                  disabled
                  v-if="newPassBoxVisible"
                  label="გაიმეორეთ ახალი პაროლი"
                  v-model="newPasswordAgain"
                  prepend-icon="lock"
                  type="password"
                  v-on:keyup.13="onLogin"
                ></v-text-field>
                <span>სისტემაში უნდა შეხვიდეთ RS.GE-ს მომხარებელი/პაროლი-თ</span>
              </v-form>
            </v-card-text>
            <v-card-actions>
              <rs-login callback="onCallBack" publickey="9377ef2e-9cbf-5b5b-5035-81bc81efa3b9"></rs-login>
              <v-spacer></v-spacer>
              <v-btn
              disabled=""
                :loading="loginLoading"
                v-if="!newPassBoxVisible"
                @click="onLogin"
                color="primary"
              >შესვლა</v-btn>
              <v-btn disabled="" v-if="newPassBoxVisible" @click="onChangePassword" color="primary">შესვლა</v-btn>
            </v-card-actions>
          </form>
        </v-card>
      </v-flex>
    </v-layout>
  </div>
</template>
<script>
// import constants from '../constants'
// import store from "../store.js";

export default {
  name: "Login",
  data() {
    return {
      newPassBoxVisible: false,
      loginLoading: false,
      snackbar: false,
      text: "მომხმარებელი ან პაროლი არასწორია",
      userName: null,
      password: null,
      newPassword: null,
      newPasswordAgain: null
    };
  },

  async created() {
    // var that = this;
    //     setTimeout(function(){
    //       // let recaptchaScript = document.createElement('script')
    //       var btn = document.createElement("rs-login");
    // //<rs-login callback="onCallBack" publickey="eb6c39d6-486a-5999-548e-039953a805ae"></rs-login>
    //       btn.callback = that.callback();
    //       btn.publickey = "eb6c39d6-486a-5999-548e-039953a805ae"
    //       // document.body.appendChild(btn);               // Append <button> to <body>
    //       // document.head.appendChild(recaptchaScript)
    //     console.log('2121',document.getElementsByClassName("elevation-12")[0])
    //      document.getElementsByClassName("elevation-12")[0].appendChild(btn)
    //      }, 1000);
  },

  methods: {
    onCallBack: function(data) {
      console.log("data", data);
    },
    callback() {
      console.log("aaaaaaaa");
    },
    async onLogin() {
      localStorage.clear();
      this.loginLoading = true;
      var result = await this.$http.login(this.userName, this.password);
      console.log("login", result);

      if (result.isSuccess) {
        localStorage.setItem("user-token", result.message);
        localStorage.setItem("currentUser", JSON.stringify(result.data));

        var that = this;
        setTimeout(function() {
          that.loginLoading = false;
          that.$router.push("home");
        }, 100);
      } else {
        this.loginLoading = false;
        this.$toast(result.message, {
          dismissable: true
        });
        return;
      }
      // this.$router.push("home");
    }
    // async onLogin() {
    //   var result;
    //   var oldPass = "Resetpass1";
    //   if (this.password == oldPass) {
    //     result = await this.$http.login(this.userName, this.password);
    //     console.log("resultresult", result);
    //     if (!result.isSuccess) {
    //       this.$toast(result.message, {
    //         dismissable: true
    //       });
    //       return;
    //     }
    //     store.store.setAuthTokenAction(result.message);
    //     this.password = "";
    //     this.newPassBoxVisible = true;
    //     this.$toast("შეცვალეთ პაროლი", {
    //       dismissable: true
    //     });
    //     return;
    //   }
    //   if (this.newPassBoxVisible) {
    //     console.log(111111111111111111111111111);
    //     if (this.userName && this.newPassword && this.newPasswordAgain) {
    //       console.log(22222222222);
    //       //store.store.clearAuthTokenAction();
    //       var changePass = await this.$http.changePassword(
    //         oldPass,
    //         this.newPassword,
    //         this.newPasswordAgain
    //       );
    //       if (changePass.isSuccess) {
    //         this.$toast("პაროლი წარმატებით შეიცვალა, შედით სისტემაში", {
    //           color: "green",
    //           dismissable: true
    //         });
    //         console.log(changePass);

    //         store.store.setAuthTokenAction(changePass.message);
    //          var us = await this.$http.getCurrentUser();
    //         console.log('===============',us)
    //         store.store.setCurrentUser({...us});
    //         this.$router.push("home");
    //         return;
    //       }
    //       this.$toast(changePass.message, {
    //         color: "red",
    //         dismissable: true
    //       });

    //       return;
    //     }
    //   }

    //   result = await this.$http.login(this.userName, this.password);

    //   console.log("result", result);
    //   if (result.isSuccess) {
    //     store.store.setAuthTokenAction(result.message);
    //     var user = await this.$http.getCurrentUser();
    //     console.log('===============',user)
    //     store.store.setCurrentUser({...user});
    //     if(user.roles.addEditViewConfiguration){
    //       console.log("*******************************************")
    //       this.$router.push("References");
    //     }
    //     this.$router.push("home");
    //   } else {
    //     this.$toast(result.message, {
    //       color: "red",
    //       dismissable: true
    //     });
    //   }

    //   // this.$router.push('home')
    //   // const result = this.$http.login(this.userName, this.password)
    //   // if (result.isSuccess) {
    //   //    window.location.replace('' + constants.API_PREFIX + '/login')
    //   // }

    //   // console.log(result)
    // }
  }
};
</script>