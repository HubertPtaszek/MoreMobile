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
                            <h3 class="mb-2">Logowanie</h3>
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
                                <ion-input v-model="authFormFields.password"
                                    :placeholder="'Hasło'"
                                    :disabled="showSignInProgress"
                                    @ionInput="validateTextLength"
                                    :type="passwordInputType"
                                    ref="passwordRef"
                                    class="auth-input">
                                    <ion-icon slot="start"
                                        :icon="icons.passwordIcon"
                                        aria-hidden="true"></ion-icon>
                                    <ion-icon slot="end"
                                        :icon="passwordInputType == 'password' ? icons.eyeIcon : icons.eyeOffIcon"
                                        @click="togglePasswordInputType()"
                                        aria-hidden="true"></ion-icon>
                                </ion-input>
                            </form>
                            <ion-toast
                                :is-open="signInError.isVisible"
                                @didDismiss="closeToast()"
                                class="error-toast"
                                :message="signInError.message"
                                :duration="3000">
                            </ion-toast>
                            <ion-toast
                                :is-open="resendEmailToastVisible"
                                @click="resendConfirmationEmail()"
                                @didDismiss="closeResendToast()"
                                class="error-toast"
                                :message="resendEmailToastMessage"
                                :duration="10000">
                            </ion-toast>
                            <!-- <ion-toast :is-open="mainStore.tokenErrorVisible" @didDismiss="closeTokenErrorToast()" class="error-toast" :message="'Session expired. Please log in again.'" :duration="3000"></ion-toast> -->
                            <template v-if="!showSignInProgress">
                                <ion-button class="auth-signin-btn"
                                    expand="block"
                                    @click="onLoginBtnClick()">
                                    Zaloguj
                                </ion-button>
                            </template>
                            <div class="registration-link mt-2">
                                <RouterLink to="/register">Rejestracja</RouterLink>
                            </div>
                            <div class="forgot-password mt-2">
                                <RouterLink to="/forgot-password">Odświezanie hasła</RouterLink>
                            </div>
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

import { fingerPrintOutline, menu, personOutline, eyeOutline, eyeOffOutline, lockClosedOutline } from "ionicons/icons";

import { useAuthStore } from '@/stores/authStore';

const SIGNIN_ERROR_DEFAULT = {
    message: '',
    isVisible: false
}

export default {
    setup() {
        const authStore = useAuthStore()
        return { authStore }
    },
    data() {
        return {
            showSignInProgress: false,
            signInError: SIGNIN_ERROR_DEFAULT,
            passwordInputType: 'password',
            authFormFields: {
                email: '',
                password: ''
            },
            resendEmailToastVisible: false,
            resendEmailToastMessage: '',
            icons: {
                fingerIcon: fingerPrintOutline,
                faceIdIcon: menu,
                personIcon: personOutline,
                passwordIcon: lockClosedOutline,
                eyeIcon: eyeOutline,
                eyeOffIcon: eyeOffOutline
            }
        };
    },
    methods: {
        async onLoginBtnClick() {
            if (!this.validateFormInputs()) return;
            else {
                this.signInError = SIGNIN_ERROR_DEFAULT;
                this.showSignInProgress = true;
                const signInResult = await this.authStore.login(this.authFormFields);
                this.showSignInProgress = false;
                this.authFormFields = {
                    email: '',
                    password: ''
                }
                signInResult ? 
                    this.$router.push( { name: 'Calendar' } ) : 
                    this.signInError = { message: "Błąd autoryzacji", isVisible: true };

                // IF account not activated
                // this.resendEmailToastVisible = true;
                // this.resendEmailToastMessage = 'Konto nie zostało jeszcze aktywowane. Kliknij aby wysłać E-mail aktywacyjny ponownie.';
            }
        },
        validateTextLength(ev) {
            ev.target.classList.remove('ion-valid');
            ev.target.classList.remove('ion-invalid');
            const value = ev.target.value;
            if (value == '') {
                ev.target.classList.add('ion-invalid');
            }
        },
        validateFormInputs() {
            if (!(this.authFormFields.email) || (!this.authFormFields.password)) {
                if (!(this.authFormFields.email)) this.$refs.emailRef.$el.classList.add('ion-invalid');
                if (!(this.authFormFields.password)) this.$refs.passwordRef.$el.classList.add('ion-invalid');
                this.signInError = {
                    message: "Błąd walidacji",
                    isVisible: true
                }
                return false;
            } else return true;
        },
        closeToast() {
            this.signInError = SIGNIN_ERROR_DEFAULT;
        },
        closeTokenErrorToast() {
           // this.mainStore.tokenErrorVisible = false;
        },
        closeResendToast() {
            this.resendEmailToastVisible = false;
        },
        togglePasswordInputType() {
            this.passwordInputType === 'password' ? this.passwordInputType = 'text' : this.passwordInputType = 'password';
        },
        async resendConfirmationEmail() {
            const resendConfirmationEmailResult = await this.resendConfirmEmail.login(this.authFormFields);
            if (resendConfirmationEmailResult) {
                console.log("E-mail aktywacyjny został ponownie wysłany")
            }
        }
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
    },
};
</script>

<style scoped
    lang="scss">
    .flowspark-logo-container {
        height: 30%;
        max-width: 500px;
        margin: auto;
        padding: 0 1rem;
        display: flex;
        justify-content: center;

        img {
            object-fit: contain;
        }
    }

    .auth-container {
        border-radius: 50px;
        border-bottom-left-radius: 0;
        border-bottom-right-radius: 0;
        height: 64.665%;
        top: unset;
        width: 100%;
        position: absolute;
        bottom: 0;
        background: var(--ion-color-secondary);
        overflow: auto;

        h3 {
            font-weight: bolder;
            color: var(--ion-color-primary);
            letter-spacing: 0.03em;
            line-height: 36px;
            font-weight: 600;
            margin-left: 0.5rem;
        }

        .or-separator {
            margin-top: 2rem;
            font-size: 0.8rem;
            text-align: center;
        }

        .creditials-forget {
            font-size: 0.8rem;
            color: var(--ion-color-tertiary);
        }

        .icons-col {
            justify-content: center;
        }

        .auth-method-btn img {
            width: 40px;
            height: 40px;
        }
    }

    ion-toast.error-toast {
        --background: var(--ion-color-danger);
    }

    ion-input.auth-input {
        border: 2px solid var(--ion-color-step-100);
        color: black;
        border-radius: 10px;
        margin-bottom: 12px;

        ion-icon {
            color: var(--ion-color-step-700);
            padding: 0 8px;
            margin-inline-end: 0px !important;
        }
    }

    .ion-invalid {
        border: 2px solid var(--ion-color-danger) !important;
    }

    ion-button.auth-signin-btn {
        --background: var(--ion-color-primary);
        --padding-top: 18px;
        --padding-bottom: 18px;
        margin-top: 3rem;
    }

    ion-button.auth-method-btn {
        --color: var(--ion-color-dark);
        --padding-top: 18px;
        --padding-bottom: 18px;
    }

    ion-button.auth-signin-btn::part(native) {
        background: var(--ion-color-primary);
    }
</style>