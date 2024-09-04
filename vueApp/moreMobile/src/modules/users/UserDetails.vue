<template>
    <ion-page>
      <ion-content class="flow-root">
        <div class="services-form mt-8">
          <p>Szczegóły użytkownika</p>
          <p>{{ userForm.firstName }}</p>
          <p>{{ userForm.lastName }}</p>
          <p>{{ userForm.email }}</p>
          <p>{{ userForm.phoneNumber }}</p>
        </div>
        <ion-button
          @click="onDeleteBtnClick"
          color="danger"
          >Usuń</ion-button
        >
      </ion-content>
    </ion-page>
  </template>
  
  <script>
  import { IonContent, IonPage, IonButton } from "@ionic/vue";
  
  
  import { mapActions } from "pinia";
  import { useUsersManagementStore } from "@/stores/userManagementStore";
  
  export default {
    data() {
      return {
        userForm: {
            email: "",
            firstName: "",
            lastName: "",
            phoneNumber: ""
        },
      };
    },
    methods: {
      ...mapActions(useUsersManagementStore, ["getUserByEmail"]),
    },
    async ionViewWillEnter() {
      const userEmail = this.$route.params.email;
      const result = await this.getUserByEmail(userEmail);
      this.userForm = result
      console.log(result);
    },
    components: {
      IonContent,
      IonPage,
      IonButton
    },
  };
  </script>
  
  <style scoped lang="scss">
  .services-form {
    &-header {
      font-size: 1.25rem;
      font-weight: bolder;
    }
  }
  </style>
  