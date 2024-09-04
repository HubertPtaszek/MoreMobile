<template>
  <ion-page>
    <ion-content class="flow-root">
      <div class="calendar">
        <div class="user-warranties">
          <UserWarrantiesList />
        </div>
        <div class="calendar-header mb-2">Kalendarz</div>
        <Calendar />
        <DailyEvents />
      </div>
    </ion-content>
  </ion-page>
</template>

<script>
import { mapActions } from "pinia";
import { useWarrantyStore } from "@/stores/warrantyStore.js";

import { IonContent, IonPage } from "@ionic/vue";

import Calendar from "./Calendar.vue";
import DailyEvents from "./DailyEvents.vue";
import UserWarrantiesList from "./UserWarrantiesList.vue";

export default {
  methods: {
    ...mapActions(useWarrantyStore, ['getUserWarranties'])
  },
  async ionViewWillEnter() {
    const result = await this.getUserWarranties();
  },
  components: {
    IonContent,
    IonPage,
    DailyEvents,
    Calendar,
    UserWarrantiesList,
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
