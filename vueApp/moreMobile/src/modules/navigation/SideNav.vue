<template>
  <ion-menu
    side="end"
    menu-id="first-menu"
    content-id="main-content"
  >
    <ion-content :scrollY="false">
      <div class="sidebar-wrapper">
        <ion-grid>
          <ion-row class="ion-padding-bottom">
            <ion-col>
              <div class="ion-text-end">
                <ion-button
                  @click="onHideSidebarBtnClick()"
                  class="ico-menu"
                >
                  <ion-icon
                    :icon="icons.sidebarHideIcon"
                    size="large"
                  />
                </ion-button>
              </div>
            </ion-col>
          </ion-row>
          <ion-row
            class="fs-default-top-border ion-padding-top process-tree-wrapper"
          >
            <ion-col>  </ion-col>
          </ion-row>
          <ion-row
            class="menu-bottom-row fs-default-top-border ion-padding ion-justify-content-between"
          >
            <ion-col size="6">
              <ion-button
                @click="onLogoutBtnClick()"
                color="tertiary"
              >
                <ion-icon
                  :icon="icons.logoutIcon"
                  size="large"
                >
                </ion-icon>
              </ion-button>
            </ion-col>
            <ion-col
              size="6"
              class="ion-text-end"
            >
              <ion-button @click="onSettingsBtnClick()">
                <ion-icon
                  :icon="icons.settingsIcon"
                  size="large"
                >
                </ion-icon>
              </ion-button>
            </ion-col>
          </ion-row>
        </ion-grid>
      </div>
    </ion-content>
  </ion-menu>
</template>

<script>
import {
  IonMenu,
  IonContent,
  IonGrid,
  IonCol,
  IonRow,
  IonIcon,
  IonButton,
  menuController,
} from "@ionic/vue";
import {
  qrCodeOutline,
  menuOutline,
  logOutOutline,
  settingsOutline,
} from "ionicons/icons";

export default {
  data() {
    return {
      icons: {
        scanIcon: qrCodeOutline,
        sidebarHideIcon: menuOutline,
        logoutIcon: logOutOutline,
        settingsIcon: settingsOutline,
      },
    };
  },
  methods: {
    async onHideSidebarBtnClick() {
      await menuController.close("first-menu");
    },
    async onLogoutBtnClick() {
      await menuController.close("first-menu");
      this.$router.push({ name: "Auth" });
    },
    async onSettingsBtnClick() {
      await menuController.close("first-menu");
      this.$router.push({ name: "Settings" });
    },
  },
  components: {
    IonMenu,
    IonContent,
    IonGrid,
    IonCol,
    IonRow,
    IonIcon,
    IonButton,
  },
};
</script>
<style lang="scss" scoped>
ion-grid {
  display: flex;
  flex-direction: column;
}
.process-tree-wrapper {
  overflow: auto;
}
.menu-bottom-row {
  position: absolute;
  bottom: 0;
  width: calc(100% - 10px);
}

ion-menu {
  --width: 100%;
}

.ico-menu {
  rotate: 90deg;
}
</style>
