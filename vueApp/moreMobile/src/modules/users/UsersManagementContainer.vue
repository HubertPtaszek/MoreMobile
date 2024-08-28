<template>
    <ion-page>
      <ion-content class="flow-root">
        <div class="settings">
          <div class="settings-header mb-2">Zarządzanie użytkownikami</div>
          <p>(admin)lista użytkowników/usuwanie</p>
        </div>
      </ion-content>
    </ion-page>
  </template>
  
  <script>
  import { IonContent, IonPage } from "@ionic/vue";
  
  export default {
    components: {
      IonContent,
      IonPage,
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
  