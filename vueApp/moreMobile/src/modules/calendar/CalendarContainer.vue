<template>
  <ion-page>
    <ion-content class="flow-root">
      <div class="calendar">
        <div class="calendar-header mb-2">Kalendarz</div>
        <Calendar />
        <DailyEvents />
      </div>
    </ion-content>
  </ion-page>
</template>

<script>
import { IonContent, IonPage } from "@ionic/vue";

import Calendar from "./Calendar.vue";
import DailyEvents from "./DailyEvents.vue";

export default {
  components: {
    IonContent,
    IonPage,
    DailyEvents,
    Calendar,
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
