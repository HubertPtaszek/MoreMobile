<template>
    <ion-page>
      <ion-content class="flow-root">
        <div class="calendar">
          <div class="calendar-header mb-2">Nowa wizyta</div>
        </div>
      </ion-content>
    </ion-page>
  </template>
  
  <script>
  import { mapActions } from "pinia";
  import { useWarrantyStore } from "@/stores/warrantyStore.js";
  
  import { IonContent, IonPage } from "@ionic/vue";
  
  export default {
    data() {
        return {
            warrantyForm: {
                carModel: "",
                registrationNumber: "",
                vin: "",
                serviceTypeId: "",
                serviceDate: {
                    year: 0,
                    month: 0,
                    day: 0,
                    dayOfWeek: 0,
                    dayOfYear: 0,
                    dayNumber: 0
                },
                visitDates: [
                    {
                        id: "",
                        inspectionDate: "",
                        firstVisit: true,
                        inspectionDone: true
                    }
                ],
                userId: "",
                lostWarranty: true,
                lossWarrantyReason: ""
            },
            editMode: false
        }
    },
    methods: {
      ...mapActions(useWarrantyStore, ['addWarranty']),
      submitForm() {
        this.addWarranty(this.warrantyForm)
      }
    },
    async ionViewWillEnter() {
      if (this.editMode) {
        const result = await this.getWarrantyById(1);
      }
    },
    components: {
      IonContent,
      IonPage,
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
  