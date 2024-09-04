const MOCK_USERS = [
    {
        email: "test1@test.pl",
        firstName: "Tester1",
        lastName: "Testowy",
        phoneNumber: "123123123"
    },
    {
        email: "test2@test.pl",
        firstName: "Tester2",
        lastName: "Testowy2",
        phoneNumber: "123123123"
    },
    {
        email: "test3@test.pl",
        firstName: "Tester3",
        lastName: "Testowy3",
        phoneNumber: "123123123"
    },
    {
        email: "test4@test.pl",
        firstName: "Tester4",
        lastName: "Testowy4",
        phoneNumber: "123124123"
    },
]

import { defineStore } from "pinia";
import userApi from "@/api/userApi.js";

export const useUsersManagementStore = defineStore("users-management-store", {
  state: () => ({
    users: []
  }),
  actions: {
    async getUsers() {

        // try {
        //     const result = userApi.getUserData();
        //     if (result.data) {
        //         // todo
        //     }
        // } catch (error) {
        //     console.log(error)
        // }

        this.users = MOCK_USERS

    },
    async getUserByEmail(email) {

        // try {
        //     const result = userApi.getUserByEmail("test@mail.com");
        //     if (result.data) {
        //         console.log('todo')
        //     }
        // } catch (error) {
        //     console.log(error)
        // }
        return this.users.find(el => el.email === email)
    },
  },
  getters: {
    getAllUsers: (state) => { return state.users }
  },
});
