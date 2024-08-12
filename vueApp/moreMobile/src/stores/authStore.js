import { defineStore } from "pinia";
import authApi from "@/api/authApi.js";

export const useAuthStore = defineStore("auth-store", {
  state: () => ({
    userData: {
      email: "",
      tokenType: "",
      accessToken: "",
      expiresIn: 0,
      refreshToken: ""
    },
  }),
  actions: {
    setUser(signInResponseData, requestFormData) {
        localStorage.setItem("auth-token", signInResponseData)
        this.userData = {
            email: requestFormData.email,
            ...signInResponseData
        }
    },
    async login(formData) {

        const TEMP_2FA_REQUEST = {
            email: formData.email,
            password: formData.password,
            twoFactorCode: "todo",
            twoFactorRecoveryCode: "todo"
        }

        // try {
        //     const result = authApi.login(TEMP_2FA_REQUEST);
        //     if (result.data) {
        //         this.setUser(result.data, TEMP_2FA_REQUEST)
        //         // redirect to home
        //     }
        // } catch (error) {
        //     console.log(error)
        // }

        return true;

    },
    async register(formData) {

        // try {
        //     let result = authApi.register(formData);
        //     if (result) {
        //         console.log('todo')
        //         // redirect to login
        //         // snackbar - show status
        //         // snackbar - confirm email info
        //     }
        // } catch (error) {
        //     console.log(error)
        // }

        return true;

    },
    async refreshToken() {

        try {
            let result = authApi.refreshToken(this.userData.refreshToken);
            if (result) {
                console.log('todo')
                // show status snackbar
            }
        } catch (error) {
            console.log(error)
        }

    },

    async resendConfirmEmail() {

        try {
            let result = authApi.resendConfirmEmail(this.userData.email);
            if (result) {
                console.log('todo')
                // snackbar - show status
            }
        } catch (error) {
            console.log(error)
        }

    },

    async forgotPassword() {

        try {
            let result = authApi.forgotPassword(this.userData.email);
            if (result) {
                console.log('todo')
                // snackbar - show status
                // route to login
            }
        } catch (error) {
            console.log(error)
        }

    },
    async getUserInfo() {
        try {
            let result = authApi.getInfo();
            if (result) {
                console.log('todo:', result.data)
            }
        } catch (error) {
            console.log(error)
        }
    },
    async setUserInfo(userInformationForm) {
        try {
            let result = authApi.postInfo(userInformationForm);
            if (result) {
                console.log('todo')
                // snackbar - show status
            }
        } catch (error) {
            console.log(error)
        }
    },
    async resetPassword(resetPasswordForm) {
        try {
            let result = authApi.resetPassword(resetPasswordForm);
            if (result) {
                console.log('todo')
                // snackbar - show status
            }
        } catch (error) {
            console.log(error)
        }
    },
    async set2FA(twoFactorAuthForm) {
        try {
            let result = authApi.set2FA(twoFactorAuthForm);
            if (result) {
                console.log('todo')
                // snackbar - show status
            }
        } catch (error) {
            console.log(error)
        }
    },
    async logout() {
        localStorage.removeItem("userData")
    },
    getConfig() {
    },
    setErrorMessage() {
    }
  },
  getters: {},
});
