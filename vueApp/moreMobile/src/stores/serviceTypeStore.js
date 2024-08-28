import { defineStore } from "pinia";
import serviceTypeApi from "@/api/serviceTypeApi.js";

const MOCK_SERVICE_TYPES = [
    {
      id: "1",
      name: "service 1",
      warrantyLengthInMonths: 3,
      grossPrice: 33,
      netPrice: 22,
      vatRate: 9
    },
    {
        id: "2",
        name: "service 2",
        warrantyLengthInMonths: 4,
        grossPrice: 90,
        netPrice: 80,
        vatRate: 11
      },
      {
        id: "3",
        name: "service 3",
        warrantyLengthInMonths: 7,
        grossPrice: 90,
        netPrice: 96,
        vatRate: 4
      },
  ]

export const useServiceTypeStore = defineStore("service-type-store", {
  state: () => ({
    serviceTypes: []
  }),
  actions: {
    async getServiceTypes() {

        // try {
        //     const result = serviceTypeApi.getServiceType();
        //     if (result.data) {
        //         // todo
        //     }
        // } catch (error) {
        //     console.log(error)
        // }

        this.serviceTypes = MOCK_SERVICE_TYPES

    },
    async addServiceType(serviceTypeData) {

        // try {
        //     const result = serviceTypeApi.addServiceType(serviceTypeData);
        //     if (result.data) {
        //         // todo
        //     }
        // } catch (error) {
        //     console.log(error)
        // }

        this.serviceTypes = [ ...this.serviceTypes, serviceTypeData ]

    },
    async modifyServiceType(serviceTypeData) {

        // try {
        //     const result = serviceTypeApi.modifyServiceType(serviceTypeData);
        //     if (result.data) {
        //         // todo
        //     }
        // } catch (error) {
        //     console.log(error)
        // }

        console.log('modif', serviceTypeData)

    },
    async getServiceTypeById(serviceTypeId) {

        // try {
        //     const result = serviceTypeApi.getServiceTypeById(serviceTypeId);
        //     if (result.data) {
        //         // todo
        //     }
        // } catch (error) {
        //     console.log(error)
        // }
        console.log(serviceTypeId)
        return this.serviceTypes.find(el => el.id === serviceTypeId)

    },
    async removeServiceType(serviceTypeId) {

        // try {
        //     const result = serviceTypeApi.deleteServiceType(serviceTypeId);
        //     if (result.data) {
        //         // todo
        //     }
        // } catch (error) {
        //     console.log(error)
        // }

        console.log('remove', serviceTypeId)
    },
  },
  getters: {
    getServiceTypesList: (state) => {
        return state.serviceTypes
    }
  },
});
