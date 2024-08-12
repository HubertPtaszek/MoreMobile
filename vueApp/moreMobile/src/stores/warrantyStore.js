import { defineStore } from "pinia";
import warrantyApi from "@/api/warrantyApi.js";

export const useWarrantyStore = defineStore("warranty-store", {
  state: () => ({

  }),
  actions: {
    async getWarranty() {

        try {
            const result = warrantyApi.getWarranty();
            if (result.data) {
                // todo
            }
        } catch (error) {
            console.log(error)
        }

    },
    async addWarranty(warrantyData) {

        try {
            const result = warrantyApi.addWarranty(warrantyData);
            if (result.data) {
                // todo
            }
        } catch (error) {
            console.log(error)
        }

    },
    async modifyWarranty(warrantyData) {

        try {
            const result = warrantyApi.modifyWarranty(warrantyData);
            if (result.data) {
                // todo
            }
        } catch (error) {
            console.log(error)
        }

    },
    async getUserWarranties() {

        try {
            const result = warrantyApi.getUserWarranties();
            if (result.data) {
                // todo
            }
        } catch (error) {
            console.log(error)
        }

    },
    async getWarrantyById(warrantyId) {

        try {
            const result = warrantyApi.getWarrantyById(warrantyId);
            if (result.data) {
                // todo
            }
        } catch (error) {
            console.log(error)
        }

    },
    async removeWarranty(warrantyId) {

        try {
            const result = warrantyApi.deleteWarranty(warrantyId);
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
