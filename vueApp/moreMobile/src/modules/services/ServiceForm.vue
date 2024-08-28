<template>
  <div>
    <ion-list :inset="true">
      <ion-item>
        <ion-input
          v-model="serviceTypeForm.name"
          label="Nazwa usugi"
        ></ion-input>
      </ion-item>
      <ion-item>
        <ion-input
          v-model="serviceTypeForm.warrantyLengthInMonths"
          type="number"
          label="Dugość trwania"
        ></ion-input>
      </ion-item>
      <ion-item>
        <ion-input
          v-model="serviceTypeForm.grossPrice"
          type="number"
          label="Cena brutto"
        ></ion-input>
      </ion-item>
      <ion-item>
        <ion-input
          v-model="serviceTypeForm.netPrice"
          type="number"
          label="Cena netto"
        ></ion-input>
      </ion-item>
      <ion-item>
        <ion-input
          v-model="serviceTypeForm.vatRate"
          type="number"
          label="Wartość VAT"
        ></ion-input>
      </ion-item>
      <ion-item>
        <ion-button @click="onSaveBtnClick">Zapisz</ion-button>
      </ion-item>
      <ion-item v-if="editMode">
        <ion-button
          @click="onDeleteBtnClick"
          color="danger"
          >Usuń</ion-button
        >
      </ion-item>
    </ion-list>
  </div>
</template>

<script>
import { IonInput, IonItem, IonList, IonButton } from "@ionic/vue";

import { mapActions } from "pinia";
import { useServiceTypeStore } from "@/stores/serviceTypeStore";

export default {
  props: {
    serviceType: {
      type: Object,
    },
  },
  watch: {
    serviceType(newVal) {
      console.log(newVal);
      if (newVal) {
        this.serviceTypeForm = newVal;
        this.editMode = true;
      } else {
        this.editMode = false;
      }
    },
  },
  data() {
    return {
      editMode: false,
      serviceTypeForm: {
        id: "0",
        name: "",
        warrantyLengthInMonths: 0,
        grossPrice: 0,
        netPrice: 0,
        vatRate: 0,
      },
    };
  },
  methods: {
    ...mapActions(useServiceTypeStore, [
      "addServiceType",
      "modifyServiceType",
      "removeServiceType",
    ]),
    onSaveBtnClick() {
      if (this.editMode) {
        console.log("modify");
        this.modifyServiceType(this.serviceTypeForm);
      } else {
        console.log("add");
        this.addServiceType(this.serviceTypeForm);
      }
      this.$router.go(-1);
    },
    onDeleteBtnClick() {
      this.removeServiceType(this.serviceTypeForm.id);
      this.$router.go(-1);
    },
  },
  components: {
    IonInput,
    IonItem,
    IonList,
    IonButton,
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
