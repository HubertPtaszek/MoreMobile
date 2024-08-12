<template>
    <ion-page>
        <ion-content class="flow-root">
            <ion-progress-bar type="indeterminate" v-if="showSignInProgress"></ion-progress-bar>
            <div class="flowspark-logo-container">
                Baner/Logo?
            </div>
            <div class="auth-container">
                <ion-grid class="ion-no-padding">
                    <ion-row class="ion-justify-content-center ion-padding-top">
                        <ion-col size="9">
                            <h3 class="mb-2">Odświeżanie hasła</h3>
                            <form>
                                <ion-input v-model="authFormFields.email"
                                    :placeholder="'Email'"
                                    :disabled="showSignInProgress"
                                    @ionInput="validateTextLength"
                                    ref="emailRef"
                                    class="auth-input">
                                    <ion-icon slot="start"
                                        :icon="icons.personIcon"
                                        aria-hidden="true"></ion-icon>
                                </ion-input>
                            </form>
                            <ion-toast
                                :is-open="error.isVisible"
                                @didDismiss="closeToast()"
                                class="error-toast"
                                :message="error.message"
                                :duration="3000">
                            </ion-toast>
                            <template v-if="!showSignInProgress">
                                <ion-button class="auth-signin-btn"
                                    expand="block"
                                    @click="onLoginBtnClick()">
                                    Odśwież hasło
                                </ion-button>
                            </template>
                        </ion-col>
                    </ion-row>
                </ion-grid>
            </div>
        </ion-content>
    </ion-page>
</template>

<script>
import {
    IonContent,
    IonPage,
    IonButton,
    IonGrid,
    IonCol,
    IonRow,
    IonInput,
    IonIcon,
    IonToast,
    IonProgressBar
} from "@ionic/vue";

import { useAuthStore } from '@/stores/authStore';

export default {
    setup() {
        const authStore = useAuthStore()
        return { authStore }
    },
    data() {
        return {
            authFormFields: {
                email: '',
            },
            error: {
                message: '',
                isVisible: false
            },
            showProcessingInProgress: false
        }
    },
    methods: {
        async onFormConfirm() {
            if (!this.validateFormInputs()) return;
            else {
                this.showProcessingInProgress = true;
                const forgotPasswordResult = await this.authStore.forgotPassword(this.authFormFields);
                this.showProcessingInProgress = false;
                this.authFormFields = {
                    email: '',
                }
                forgotPasswordResult ? 
                    this.$router.push( { name: 'Auth' } ) : 
                    this.error = { message: "Błąd", isVisible: true };
            }
        },
        validateFormInputs() {
            if (!(this.authFormFields.email)) {
                if (!(this.authFormFields.email)) this.$refs.emailRef.$el.classList.add('ion-invalid');
                this.error = {
                    message: "Błąd walidacji",
                    isVisible: true
                }
                return false;
            } else return true;
        },
        closeToast() {
            this.signInError = {
                message: '',
                isVisible: false
            };
        },
    },
    components: {
        IonContent,
        IonPage,
        IonButton,
        IonGrid,
        IonCol,
        IonRow,
        IonInput,
        IonIcon,
        IonToast,
        IonProgressBar
    }
}
</script>

<style>
</style>