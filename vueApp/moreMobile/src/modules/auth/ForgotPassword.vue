<template>
  <ion-page>
    <ion-content class="flow-root">
      <ion-progress-bar
        type="indeterminate"
        v-if="showSignInProgress"
      ></ion-progress-bar>
      <div class="logo-container"></div>
      <div class="auth-container">
        <ion-grid class="ion-no-padding">
          <ion-row class="ion-justify-content-center ion-padding-top">
            <ion-col size="9">
              <h3 class="mb-4">Odświeżanie hasła</h3>
              <form>
                <ion-input
                  v-model="authFormFields.email"
                  :placeholder="'Email'"
                  :disabled="showSignInProgress"
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
              </form>
              <ion-toast
                :is-open="error.isVisible"
                @didDismiss="closeToast()"
                class="error-toast"
                :message="error.message"
                :duration="3000"
              >
              </ion-toast>
              <template v-if="!showSignInProgress">
                <ion-button
                  class="auth-signin-btn"
                  expand="block"
                  @click="onLoginBtnClick()"
                >
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
  IonProgressBar,
} from "@ionic/vue";

import {
  fingerPrintOutline,
  menu,
  personOutline,
  eyeOutline,
  eyeOffOutline,
  lockClosedOutline,
  personAddOutline,
  refreshOutline,
} from "ionicons/icons";

import { useAuthStore } from "@/stores/authStore";

const SIGNIN_ERROR_DEFAULT = {
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
      showSignInProgress: false,
      signInError: SIGNIN_ERROR_DEFAULT,
      passwordInputType: "password",
      authFormFields: {
        email: "",
      },
      error: {
        message: "",
        isVisible: false,
      },
      showProcessingInProgress: false,
      icons: {
        fingerIcon: fingerPrintOutline,
        faceIdIcon: menu,
        personIcon: personOutline,
        passwordIcon: lockClosedOutline,
        eyeIcon: eyeOutline,
        eyeOffIcon: eyeOffOutline,
        personAdd: personAddOutline,
        refreshIcon: refreshOutline,
      },
    };
  },
  methods: {
    async onFormConfirm() {
      if (!this.validateFormInputs()) return;
      else {
        this.showProcessingInProgress = true;
        const forgotPasswordResult = await this.authStore.forgotPassword(
          this.authFormFields
        );
        this.showProcessingInProgress = false;
        this.authFormFields = {
          email: "",
        };
        forgotPasswordResult
          ? this.$router.push({ name: "Auth" })
          : (this.error = { message: "Błąd", isVisible: true });
      }
    },
    validateFormInputs() {
      if (!this.authFormFields.email) {
        if (!this.authFormFields.email)
          this.$refs.emailRef.$el.classList.add("ion-invalid");
        this.error = {
          message: "Błąd walidacji",
          isVisible: true,
        };
        return false;
      } else return true;
    },
    validateTextLength(ev) {
      ev.target.classList.remove("ion-valid");
      ev.target.classList.remove("ion-invalid");
      const value = ev.target.value;
      if (value == "") {
        ev.target.classList.add("ion-invalid");
      }
    },
    closeToast() {
      this.signInError = {
        message: "",
        isVisible: false,
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

  .registration-link, .forgot-password {
    font-size: 16px;

    a {
        text-decoration: none;
        display: flex;
        align-items: center;
        gap: 0.5rem;
    }
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

