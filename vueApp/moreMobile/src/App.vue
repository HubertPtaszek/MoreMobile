<template>
  <ion-app>
    <div class="app-wrapper">
      <SideNav />
      <ion-header
        v-if="
          currentRouteName !== 'Auth' &&
          currentRouteName !== 'ForgotPassword' &&
          currentRouteName !== 'Register'
        "
      >
        <TopNav />
      </ion-header>
      <ion-router-outlet id="main-content"></ion-router-outlet>
    </div>
  </ion-app>
</template>

<script>
import { IonApp, IonRouterOutlet } from "@ionic/vue";

import SideNav from "@/modules/navigation/SideNav.vue";
import TopNav from "@/modules/navigation/TopNav.vue";

export default {
  computed: {
    currentRouteName() {
      return this.$route.name;
    },
  },
  components: {
    IonApp,
    IonRouterOutlet,
    SideNav,
    TopNav,
  },
};
</script>
<style scoped lang="scss">
.app-wrapper {
  width: 100%;
  height: 100%;
  background: var(--ion-color-primary);
}
</style>
