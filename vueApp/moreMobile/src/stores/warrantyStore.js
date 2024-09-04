import { defineStore } from "pinia";
import warrantyApi from "@/api/warrantyApi.js";

const MOCK_USER_WARRANTIES = [
    {
      id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      carModel: "BMW",
      registrationNumber: "TT1113",
      vin: "ASD123123123129",
      serviceTypeId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      serviceDate: {
        year: 2024,
        month: 9,
        day: 22,
        dayOfWeek: 3,
        dayOfYear: 322,
        dayNumber: 2
      },
      visitDates: [
        {
          id: "3fa85f64-5717-4562-b3ec-2c963f66afa6",
          inspectionDate: "2024-09-06T10:57:06.566Z",
          firstVisit: true,
          inspectionDone: true
        },
        {
            id: "3fa85f64-5717-4562-b3ec-2c963n66afa6",
            inspectionDate: "2024-09-06T10:57:06.566Z",
            firstVisit: true,
            inspectionDone: true
          }
      ],
      userId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      lostWarranty: true,
      lossWarrantyReason: "x"
    },
    {
        id: "32a85f64-5717-4562-b3fc-2c963f66afa6",
        carModel: "KIA",
        registrationNumber: "TT1112",
        vin: "ASD123123123125",
        serviceTypeId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        serviceDate: {
            year: 2024,
            month: 9,
            day: 23,
            dayOfWeek: 3,
            dayOfYear: 322,
            dayNumber: 2
        },
        visitDates: [
          {
            id: "3fa85f64-5717-4562-b3fc-2c968f66afa6",
            inspectionDate: "2024-09-07T10:57:06.566Z",
            firstVisit: true,
            inspectionDone: true
          }
        ],
        userId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        lostWarranty: false,
        lossWarrantyReason: "string"
      },
      {
        id: "3fa83f64-5717-4562-b3fc-2c963f66afa6",
        carModel: "OPEL",
        registrationNumber: "TT1111",
        vin: "ASD123123123128",
        serviceTypeId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        serviceDate: {
            year: 2024,
            month: 9,
            day: 24,
            dayOfWeek: 3,
            dayOfYear: 322,
            dayNumber: 2
        },
        visitDates: [
          {
            id: "3fa83f64-5717-4562-b3fc-2c963f66afa6",
            inspectionDate: "2024-09-08T10:57:06.566Z",
            firstVisit: true,
            inspectionDone: true
          }
        ],
        userId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        lostWarranty: false,
        lossWarrantyReason: "string"
      },
  ]

export const useWarrantyStore = defineStore("warranty-store", {
  state: () => ({
    userWarranties: []
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

        // try {
        //     const result = warrantyApi.getUserWarranties();
        //     if (result.data) {
        //         // todo
        //     }
        // } catch (error) {
        //     console.log(error)
        // }

        this.userWarranties = MOCK_USER_WARRANTIES;

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
