<template>
  <ion-page>
    <ion-content class="flow-root">
      <div class="settings">
        <div class="settings-header mb-2">Ustawienia</div>
        <UserSettings :userData="user" />
      </div>
    </ion-content>
  </ion-page>
</template>

<script>
import { IonContent, IonPage } from "@ionic/vue";

import { mapActions } from "pinia";
import { useUserStore } from "@/stores/userStore.js";

import UserSettings from "./UserSettings.vue";

export default {
  data() {
    return {
      user: {
        email: "",
        firstName: "",
        lastName: "",
        phoneNumber: ""
      }
    }
  },
  methods: {
    ...mapActions(useUserStore, ['getUserByEmail'])
  },
  async ionViewWillEnter() {
    const result = await this.getUserByEmail("test");
    this.user = result
  },
  components: {
    IonContent,
    IonPage,
    UserSettings
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
