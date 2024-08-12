import { defineStore } from "pinia";
import serviceTypeApi from "@/api/serviceTypeApi.js";

export const useServiceTypeStore = defineStore("service-type-store", {
  state: () => ({
    
  }),
  actions: {
    async getServiceType() {

        try {
            const result = serviceTypeApi.getServiceType();
            if (result.data) {
                // todo
            }
        } catch (error) {
            console.log(error)
        }

    },
    async addServiceType(serviceTypeData) {

        try {
            const result = serviceTypeApi.addServiceType(serviceTypeData);
            if (result.data) {
                // todo
            }
        } catch (error) {
            console.log(error)
        }

    },
    async modifyServiceType(serviceTypeData) {

        try {
            const result = serviceTypeApi.modifyServiceType(serviceTypeData);
            if (result.data) {
                // todo
            }
        } catch (error) {
            console.log(error)
        }

    },
    async getServiceTypeById(serviceTypeId) {

        try {
            const result = serviceTypeApi.getServiceTypeById(serviceTypeId);
            if (result.data) {
                // todo
            }
        } catch (error) {
            console.log(error)
        }

    },
    async removeServiceType(serviceTypeId) {

        try {
            const result = serviceTypeApi.deleteServiceType(serviceTypeId);
            if (result.data) {
                // todo
            }
        } catch (error) {
            console.log(error)
        }

    },
  },
  getters: {},
});
