import { defineStore } from "pinia";

export const useAuthStore = defineStore("auth-store", {
  state: () => ({
    userData: {
      username: "",
    },
  }),
  actions: {
    async login() {
    },
    async logout() {
    },
    async makeTest() {
    },
    getConfig() {
    },
    setErrorMessage() {
    }
  },
  getters: {},
});
