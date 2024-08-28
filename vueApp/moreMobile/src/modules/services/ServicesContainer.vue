<template>
    <ion-page>
      <ion-content class="flow-root">
        <div class="calendar">
          <div class="calendar-header mb-2">Usługi</div>
          <ServicesList />
          <div>
            <ion-button fill="solid" shape="round" @click="onAddBtnClick">
                <ion-icon slot="icon-only" :icon="icons.icoAdd"></ion-icon>
            </ion-button>
          </div>
        </div>
      </ion-content>
    </ion-page>
  </template>
  
  <script>
  import { IonContent, IonPage, IonButton, IonIcon } from "@ionic/vue";
  import { add } from 'ionicons/icons';

  import ServicesList from "./ServicesList.vue";

  import { mapActions } from "pinia";
  import { useServiceTypeStore } from "@/stores/serviceTypeStore";

  export default {
    data()  {
      return {
        icons: {
          icoAdd: add
        }
      }
    },
    methods: {
      ...mapActions(useServiceTypeStore, [
        'getServiceTypes'
      ]),
      onAddBtnClick() {
        this.$router.push(`/service/${'new'}`);
      }
    },
    async ionViewWillEnter() {
      const result = await this.getServiceTypes();
      console.log(result) 
    },
    components: {
      IonContent,
      IonPage,
      ServicesList,
      IonButton,
      IonIcon
    },
  };
  </script>
  
  <style scoped lang="scss">
  .calendar {
    margin: 80px 1rem;
  
    &-header {
      font-size: 1.25rem;
      font-weight: bolder;
    }
  }
  </style>
  