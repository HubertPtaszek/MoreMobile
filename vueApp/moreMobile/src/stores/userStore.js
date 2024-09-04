import { defineStore } from "pinia";
import userApi from "@/api/userApi.js";

export const useUserStore = defineStore("user-store", {
  state: () => ({
    userData: {
        email: "test1@test.pl",
        firstName: "Tester1",
        lastName: "Testowy",
        phoneNumber: "123123123"
      }
  }),
  actions: {
    async getUserByEmail(email) {

        // try {
        //     const result = userApi.getUserByEmail("test@mail.com");
        //     if (result.data) {
        //         console.log('todo')
        //     }
        // } catch (error) {
        //     console.log(error)
        // }

        return this.userData;

    },
    async modifyUserData(newUserData) {

        // try {
        //     const result = userApi.modifyUserData(newUserData);
        //     if (result.data) {
        //         console.log('todo')
        //         // snackbar - handle response
        //     }
        // } catch (error) {
        //     console.log(error)
        // }

    },
    async deleteUser() {

        // try {
        //     const result = userApi.deleteUser("test@mail.com");
        //     if (result.data) {
        //         console.log('todo')
        //         // snackbar - handle response
        //     }
        // } catch (error) {
        //     console.log(error)
        // }

    },
  },
  getters: {
    getUserData: (state) => { return state.userData }
  },
});
