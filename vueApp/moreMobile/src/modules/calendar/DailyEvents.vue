<template>
    <div class="daily-events-wrapper">
        <div class="daily-events-header">
            Zdarzenia dla danego dnia
        </div>
        <div>
            <ion-button fill="solid" shape="round" @click="onAddBtnClick">
                <ion-icon slot="icon-only" :icon="icons.icoAdd"></ion-icon>
            </ion-button>
        </div>
        
    </div>
  </template>
  
  <script>

import { add } from 'ionicons/icons';
import { IonButton, IonIcon } from "@ionic/vue";

  export default {
    data() {
      return {
        icons: {
            icoAdd: add
        }
      }
    },
    methods: {
        onAddBtnClick() {
            console.log('add event')
            this.$router.push('/visit')
        }
    },
    components: {
        IonButton,
        IonIcon
    },
  };
  </script>
  
  <style scoped lang="scss">
 .daily-events-wrapper {
    display: flex;
    align-items: center;
    justify-content: space-between;
 }
  
  </style>
  