<template>
    <div class="services-list">
      <ion-list>
        <ion-item
          v-for="user of getAllUsers"
          :key="user.phoneNumber"
          button
          @click="onItemClick(user.email)"
        >
          <ion-label>
            <h3>{{ user.firstName }}</h3>
          </ion-label>
        </ion-item>
      </ion-list>
    </div>
  </template>
  
  <script>
  import { IonItem, IonLabel, IonList } from "@ionic/vue";
  
  import { mapState } from "pinia";
  import { useUsersManagementStore } from "@/stores/userManagementStore";
  
  export default {
    computed: {
      ...mapState(useUsersManagementStore, ["getAllUsers"]),
    },
    methods: {
      onItemClick(id) {
        this.$router.push(`/user/${id}`);
      },
    },
    components: {
      IonList,
      IonItem,
      IonLabel,
    },
  };
  </script>
  
  <style scoped lang="scss">
  .services-list {
    &-header {
      font-size: 1.25rem;
      font-weight: bolder;
    }
  }
  </style>
  