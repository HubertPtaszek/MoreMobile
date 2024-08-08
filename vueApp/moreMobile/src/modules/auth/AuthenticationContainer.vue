<template>
    <ion-page>
        <ion-content class="flow-root">
test
        </ion-content>
    </ion-page>
</template>

<script>
import {
    IonContent,
    IonPage,
} from "@ionic/vue";


import { useAuthStore } from '@/stores/authStore';

export default {
    setup() {
        const mainStore = useAuthStore()
        return { mainStore }
    },
    data() {
        return {
        };
    },
    methods: {
    },
    components: {
        IonContent,
        IonPage,
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
        border-radius: 10px;
        margin-bottom: 12px;

        ion-icon {
            color: var(--ion-color-step-700);
            padding: 0 8px;
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