<template>
    <div class="toobar-bg">
      <ion-toolbar>
        <ion-buttons slot="end">
          <ion-button @click="openFirstMenu()"
            class="ico-menu">
            <ion-icon :icon="icons.menuIcon"></ion-icon>
          </ion-button>
        </ion-buttons>
        <div class="company-logo-container"
          @click="onBannerClick">
          Company
        </div>
      </ion-toolbar>
    </div>
  </template>
  
  <script>
  
  import {
    IonToolbar,
    IonButtons,
    menuController,
    IonIcon,
    IonButton,
  } from "@ionic/vue";
  import {
    notificationsOutline,
    menuOutline,
    qrCodeOutline,
  } from "ionicons/icons";
  
  export default {
    data() {
      return {
        icons: {
          notificationsIcon: notificationsOutline,
          menuIcon: menuOutline,
          scanIco: qrCodeOutline,
        },
      };
    },
    computed: {
      currentRouteName() {
        return this.$route.name;
      },
    },
    methods: {
      async openFirstMenu() {
        await menuController.open("first-menu");
      },
      onBannerClick() {
        this.$router.push({ name: "Calendar" });
      },
    },
    components: {
      IonToolbar,
      IonButtons,
      IonIcon,
      IonButton,
    },
  };
  </script>
  
  <style lang="scss"
    scoped>
    .toobar-bg {
      background: var(--ion-color-primary);
    }
  
    .company-logo-container {
      display: flex;
      align-items: center;
      justify-content: center;
  
      .company-logo {
        filter: invert(var(--percent-0));
        width: 70%;
        max-width: 250px;
      }
    }
  
    ion-button.btn-notifications {
      position: relative;
    }
  
    .notifications-count {
      position: absolute;
      top: 0;
      right: 0;
      background-color: var(--ion-color-primary);
      color: var(--ion-color-tertiary);
      padding: 4px;
      border-radius: 5px;
      font-size: 0.6rem;
    }
  
    ion-toolbar {
      border-radius: 50px;
      border-bottom-left-radius: 0;
      border-bottom-right-radius: 0;
      padding-left: 1rem;
      padding-right: 1rem;
    }
  
    ion-icon {
      font-size: 2rem;
      --ionicon-stroke-width: 24px;
    }
  
    @media screen and (orientation: landscape) {
      .company-logo {
        width: 30%;
      }
    }
  </style>
  