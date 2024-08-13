<template>
  <ion-page>
    <ion-content class="flow-root">
      <ion-progress-bar
        type="indeterminate"
        v-if="showSignUpProgress"
      ></ion-progress-bar>
      <div class="logo-container"></div>
      <div class="auth-container">
        <ion-grid class="ion-no-padding">
          <ion-row class="ion-justify-content-center ion-padding-top">
            <ion-col size="9">
              <h3 class="mb-4">Rejestracja</h3>
              <form>
                <ion-input
                  v-model="authFormFields.email"
                  :placeholder="'Email'"
                  :disabled="showSignUpProgress"
                  @ionInput="validateTextLength"
                  ref="emailRef"
                  class="auth-input"
                >
                  <ion-icon
                    slot="start"
                    :icon="icons.personIcon"
                    aria-hidden="true"
                  ></ion-icon>
                </ion-input>
                <ion-input
                  v-model="authFormFields.password"
                  :placeholder="'Hasło'"
                  :disabled="showSignUpProgress"
                  @ionInput="validateTextLength"
                  :type="passwordInputType"
                  ref="passwordRef"
                  class="auth-input"
                >
                  <ion-icon
                    slot="start"
                    :icon="icons.passwordIcon"
                    aria-hidden="true"
                  ></ion-icon>
                  <ion-icon
                    slot="end"
                    :icon="
                      passwordInputType == 'password'
                        ? icons.eyeIcon
                        : icons.eyeOffIcon
                    "
                    @click="togglePasswordInputType()"
                    aria-hidden="true"
                  ></ion-icon>
                </ion-input>
              </form>
              <ion-toast
                :is-open="signupError.isVisible"
                @didDismiss="closeToast()"
                class="error-toast"
                :message="signupError.message"
                :duration="3000"
              ></ion-toast>
              <!-- <ion-toast :is-open="mainStore.tokenErrorVisible" @didDismiss="closeTokenErrorToast()" class="error-toast" :message="'Session expired. Please log in again.'" :duration="3000"></ion-toast> -->
              <template v-if="!showSignUpProgress">
                <ion-button
                  class="auth-signin-btn"
                  expand="block"
                  @click="onLoginBtnClick()"
                >
                  Zarejestruj się
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
  IonProgressBar,
} from "@ionic/vue";

import {
  fingerPrintOutline,
  menu,
  personOutline,
  eyeOutline,
  eyeOffOutline,
  lockClosedOutline,
} from "ionicons/icons";

import { useAuthStore } from "@/stores/authStore";

const SIGNUP_ERROR_DEFAULT = {
  message: "",
  isVisible: false,
};

export default {
  setup() {
    const authStore = useAuthStore();
    return { authStore };
  },
  data() {
    return {
      showSignUpProgress: false,
      signupError: SIGNUP_ERROR_DEFAULT,
      passwordInputType: "password",
      authFormFields: {
        email: "",
        password: "",
      },
      icons: {
        fingerIcon: fingerPrintOutline,
        faceIdIcon: menu,
        personIcon: personOutline,
        passwordIcon: lockClosedOutline,
        eyeIcon: eyeOutline,
        eyeOffIcon: eyeOffOutline,
      },
    };
  },
  methods: {
    async onLoginBtnClick() {
      if (!this.validateFormInputs()) return;
      else {
        this.signupError = SIGNUP_ERROR_DEFAULT;
        this.showSignUpProgress = true;
        const signupResult = await this.authStore.register(this.authFormFields);
        this.showSignUpProgress = false;
        this.authFormFields = {
          email: "",
          password: "",
        };
        signupResult
          ? this.$router.push({ name: "Auth" })
          : (this.signInError = {
              message: "Błąd rejestracji",
              isVisible: true,
            });
      }
    },
    validateTextLength(ev) {
      ev.target.classList.remove("ion-valid");
      ev.target.classList.remove("ion-invalid");
      const value = ev.target.value;
      if (value == "") {
        ev.target.classList.add("ion-invalid");
      }
    },
    validateFormInputs() {
      if (!this.authFormFields.email || !this.authFormFields.password) {
        if (!this.authFormFields.email)
          this.$refs.emailRef.$el.classList.add("ion-invalid");
        if (!this.authFormFields.password)
          this.$refs.passwordRef.$el.classList.add("ion-invalid");
        this.signupError = {
          message: "Błąd walidacji",
          isVisible: true,
        };
        return false;
      } else return true;
    },
    closeToast() {
      this.signupError = SIGNUP_ERROR_DEFAULT;
    },
    closeTokenErrorToast() {
      // this.mainStore.tokenErrorVisible = false;
    },
    togglePasswordInputType() {
      this.passwordInputType === "password"
        ? (this.passwordInputType = "text")
        : (this.passwordInputType = "password");
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
    IonProgressBar,
  },
};
</script>

<style scoped lang="scss">
.logo-container {
  height: 20%;
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
  height: 74.665%;
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
  margin-top: 2rem;
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
