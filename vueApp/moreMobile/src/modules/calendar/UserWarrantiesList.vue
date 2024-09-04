<template>
    <div class="calendar-header mb-2">Moje gwarancje</div>
  <ion-card
    v-for="warranty of userWarranties"
    :key="warranty.id"
  >
    <UserWarrantyItem :warrantyData="warranty" />
  </ion-card>
</template>

<script>
import { mapActions, mapState } from "pinia";
import { useWarrantyStore } from "@/stores/warrantyStore.js";

import {
  IonCard,
  IonCardContent,
  IonCardHeader,
  IonCardTitle,
} from "@ionic/vue";
import UserWarrantyItem from "./UserWarrantyItem.vue";

export default {
  data() {
    return {
      warranties: [],
    };
  },
  computed: {
    ...mapState(useWarrantyStore, ["userWarranties"]),
  },
  components: {
    IonCard,
    IonCardContent,
    IonCardHeader,
    IonCardTitle,
    UserWarrantyItem,
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
