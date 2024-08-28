<template>
  <ion-page>
    <ion-content class="flow-root">
      <div class="services-form">
        <p>Szczegóły usługi</p>
        <ServiceForm :serviceType="serviceTypeForm" />
      </div>
    </ion-content>
  </ion-page>
</template>

<script>
import { IonContent, IonPage } from "@ionic/vue";

import ServiceForm from "./ServiceForm.vue";

import { mapActions } from "pinia";
import { useServiceTypeStore } from "@/stores/serviceTypeStore";

export default {
  data() {
    return {
      serviceTypeForm: null,
    };
  },
  methods: {
    ...mapActions(useServiceTypeStore, ["getServiceTypeById"]),
  },
  async ionViewWillEnter() {
    const serviceTypeId = this.$route.params.id;
    const result = await this.getServiceTypeById(serviceTypeId);
    this.serviceTypeForm = result
    console.log(result);
  },
  components: {
    ServiceForm,
    IonContent,
    IonPage,
  },
};
</script>

<style scoped lang="scss">
.services-form {
  &-header {
    font-size: 1.25rem;
    font-weight: bolder;
  }
}
</style>
