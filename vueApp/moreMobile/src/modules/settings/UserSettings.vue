<template>
  <div class="user">
    <div class="user-header">Dane użytkownika</div>
    <div class="user-form">
      <p>(normal user)</p>
      <ion-list :inset="true">
      <ion-item>
        <ion-input
          v-model="userForm.email"
          label="E-mail"
        ></ion-input>
      </ion-item>
      <ion-item>
        <ion-input
          v-model="userForm.firstName"
          label="Imię"
        ></ion-input>
      </ion-item>
      <ion-item>
        <ion-input
          v-model="userForm.lastName"
          label="Nazwisko"
        ></ion-input>
      </ion-item>
      <ion-item>
        <ion-input
          v-model="userForm.phoneNumber"
          label="Numer telefonu"
        ></ion-input>
      </ion-item>
      <ion-item>
        <ion-button @click="onSaveBtnClick">Zapisz</ion-button>
      </ion-item>
      <ion-item>
        <ion-button
          @click="onDeleteBtnClick"
          color="danger"
          >Usuń</ion-button>
      </ion-item>
    </ion-list>
    </div>
  </div>
</template>

<script>

import { IonInput, IonItem, IonList, IonButton } from "@ionic/vue";

import { mapState, mapActions } from "pinia";
import { useUserStore } from "@/stores/userStore.js";

export default {
  props: {
    userData: {
      type: Object,
    },
  },
  data() {
    return {
      userForm: {
        email: "",
        firstName: "",
        lastName: "",
        phoneNumber: ""
      },
    };
  },
  watch: {
    userData(newVal) {
      this.userForm = newVal;
    },
  },
  computed: {
    ...mapState(useUserStore, ['getUserData'])
  },
  methods: {
    ...mapActions(useUserStore, [
      'modifyUserData',
      'deleteUser'
    ]),
    onSaveBtnClick() {
      console.log("modify");
      this.modifyUserData(this.userForm);
      this.$router.go(-1);
    },
    onDeleteBtnClick() {
      this.deleteUser(this.userForm.email);
      this.$router.go(-1);
    },
  },
  components: {
    IonInput,
    IonItem,
    IonList,
    IonButton,
  },
};
</script>

<style scoped lang="scss">
.user {
  &-header {
    font-size: 1rem;
    font-weight: bolder;
  }
}
</style>
