import { defineStore } from "pinia";
import userApi from "@/api/userApi.js";

export const useUserStore = defineStore("user-store", {
  state: () => ({
    userData: {
        email: "",
        firstName: "",
        lastName: "",
        phoneNumber: ""
      }
  }),
  actions: {
    async getUserData() {

        try {
            const result = userApi.getUserData();
            if (result.data) {
                console.log('todo')
                this.userData = result.data;
            }
        } catch (error) {
            console.log(error)
        }

    },
    async modifyUserData(newUserData) {

        try {
            const result = userApi.modifyUserData(newUserData);
            if (result.data) {
                console.log('todo')
                // snackbar - handle response
            }
        } catch (error) {
            console.log(error)
        }

    },
    async getUserByEmail() {

        try {
            const result = userApi.getUserByEmail("test@mail.com");
            if (result.data) {
                console.log('todo')
            }
        } catch (error) {
            console.log(error)
        }

    },
    async deleteUser() {

        try {
            const result = userApi.deleteUser("test@mail.com");
            if (result.data) {
                console.log('todo')
                // snackbar - handle response
            }
        } catch (error) {
            console.log(error)
        }

    },
  },
  getters: {},
});
