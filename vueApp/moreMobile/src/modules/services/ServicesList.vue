<template>
  <div class="services-list">
    <ion-list>
      <ion-item
        v-for="serviceType of getServiceTypesList"
        :key="serviceType.id"
        button
        @click="onItemClick(serviceType.id)"
      >
        <ion-label>
          <h3>{{ serviceType.name }}</h3>
        </ion-label>
      </ion-item>
    </ion-list>
  </div>
</template>

<script>
import { IonItem, IonLabel, IonList } from "@ionic/vue";

import { mapState } from "pinia";
import { useServiceTypeStore } from "@/stores/serviceTypeStore";

export default {
  computed: {
    ...mapState(useServiceTypeStore, ["getServiceTypesList"]),
  },
  methods: {
    onItemClick(id) {
      this.$router.push(`/service/${id}`);
    },
  },
  components: {
    IonList,
    IonItem,
    IonLabel,
  },
};
</script>

<style scoped lang="scss">
.services-list {
  &-header {
    font-size: 1.25rem;
    font-weight: bolder;
  }
}
</style>
