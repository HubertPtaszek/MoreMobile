<template>
  <div class="visit-calendar">
    <VCalendar
      :attributes='calendarAttributes'
      title-position="left"
      :is-dark="false"
      timezone="Europe/Warsaw"
      :locale="{ id: 'pl', firstDayOfWeek: 2, masks: { weekdays: 'WWW' } }"
      transparent borderless expanded :day-names-short="true" 
      @dayclick="onDayClick"
    />
  </div>
</template>

<script>
export default {
  data() {
    return {
      calendarAttributes: [{
        key: 'today',
        highlight: true,
        dates: new Date(),
      }]
    }
  },
  methods: {
    onDayClick(e) {
      console.log(e)
    }
  },
  components: {},
};
</script>

<style scoped lang="scss">
.visit-calendar {
  &-header {
    font-size: 1.25rem;
    font-weight: bolder;
  }
}

</style>
<style>
.vc-header .vc-title {
  background: transparent;
}

.vc-header .vc-arrow {
  background: transparent;
}
</style>