<template>
  <ion-card-content>
    <ion-list>
      <ion-item>
        <ion-icon
          aria-hidden="true"
          :icon="icons.infoIco"
          slot="start"
        ></ion-icon>
        <ion-label>Informacje na temat gwarancji</ion-label>
      </ion-item>
      <div class="flex mt-2">
        <div>Typ gwarancji</div>
        <div>Mycie</div>
      </div>
      <div class="flex mt-2">
        <div>Czy aktywna</div>
        <div>{{ warrantyData.lostWarranty ? "Nie" : "Tak" }}</div>
      </div>
      <div
        class="flex mt-1 mb-2"
        v-if="warrantyData.lostWarranty"
      >
        <div>Powód utracenia gwarancji</div>
        <div>{{ warrantyData.lossWarrantyReason }}</div>
      </div>
      <div class="flex mt-2">
        <div>Termin gwarancji</div>
        <div>{{ formatDate(warrantyData.serviceDate) }}</div>
      </div>
      <ion-item>
        <ion-icon
          aria-hidden="true"
          :icon="icons.carIco"
          slot="start"
        ></ion-icon>
        <ion-label>Dane o pojeździe</ion-label>
      </ion-item>
      <div class="flex mt-2">
        <div>Model</div>
        <div>{{ warrantyData.carModel }}</div>
      </div>
      <div class="flex mt-1">
        <div>Nr. rejestracyjny</div>
        <div>{{ warrantyData.registrationNumber }}</div>
      </div>
      <div class="flex mt-1 mb-2">
        <div>VIN</div>
        <div>{{ warrantyData.vin }}</div>
      </div>
      <ion-item>
        <ion-icon
          aria-hidden="true"
          :icon="icons.calendarIco"
          slot="start"
        ></ion-icon>
        <ion-label>Wizyty</ion-label>
      </ion-item>
      <div
        v-for="visit of warrantyData.visitDates"
        :key="visit.id"
        class="mt-2 mb-2"
      >
        <div class="flex">
          <div>Termin</div>
          <div>{{ visit.inspectionDate }}</div>
        </div>
        <div class="flex">
          <div>Pierwsza wizyta?</div>
          <div>{{ visit.firstVisit ? "Tak" : "Nie" }}</div>
        </div>
        <div class="flex">
          <div>Wizyta skończona?</div>
          <div>{{ visit.inspectionDone ? "Tak" : "Nie" }}</div>
        </div>
      </div>
    </ion-list>
  </ion-card-content>
</template>

<script>
import {
  IonCardContent,
  IonCardHeader,
  IonCardTitle,
  IonItem,
  IonLabel,
  IonList,
  IonIcon,
} from "@ionic/vue";
import {
  carSportOutline,
  calendarOutline,
  informationCircleOutline,
} from "ionicons/icons";

export default {
  props: {
    warrantyData: {
      type: Object,
      required: true,
    },
  },
  data() {
    return {
      icons: {
        carIco: carSportOutline,
        calendarIco: calendarOutline,
        infoIco: informationCircleOutline,
      },
    };
  },
  methods: {
    formatDate(date) {
        return `${date.day}:${date.month}:${date.year}`;
    }
  },
  components: {
    IonCardContent,
    IonCardHeader,
    IonCardTitle,
    IonItem,
    IonLabel,
    IonIcon,
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

.flex {
  display: flex;
  justify-content: space-between;
  margin-left: 1rem;
  margin-right: 1rem;
}
</style>
