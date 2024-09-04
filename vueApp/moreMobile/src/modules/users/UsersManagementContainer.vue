<template>
    <ion-page>
      <ion-content class="flow-root">
        <div class="settings">
          <div class="settings-header mb-2">Zarządzanie użytkownikami</div>
          <p>(admin)</p>
          <UsersList />
        </div>
      </ion-content>
    </ion-page>
  </template>
  
  <script>
  import { IonContent, IonPage } from "@ionic/vue";

  import UsersList from "./UsersList.vue";

  import { mapActions } from "pinia";
  import { useUsersManagementStore } from "@/stores/userManagementStore";
  
  export default {
    methods: {
        ...mapActions(useUsersManagementStore, [
        'getUsers'
      ]),
    },
    async ionViewWillEnter() {
      const result = await this.getUsers();
      console.log(result) 
    },
    components: {
      IonContent,
      IonPage,
      UsersList
    },
  };
  </script>
  
  <style scoped lang="scss">
  .settings {
    margin: 80px 1rem;
  
    &-header {
      font-size: 1.25rem;
      font-weight: bolder;
    }
  }
  </style>
  