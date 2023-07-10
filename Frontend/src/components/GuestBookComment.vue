<template>
  <div class="comment rounded-3 col-xxl-10 p-2">
    <span class="h6">{{ userName + " " }}</span>
    <small>{{ publicationDateString }}</small>
    <br />
    <span> {{ comment }} </span>
  </div>
</template>

<script>
export default {
  name: "GuestBookComment",
  props: {
    userName: String,
    publicationDate: String,
    comment: String,
  },

  computed: {
    publicationDateString() {
      // Z specifies that the date is in UTC format
      let dateTime = new Date(this.publicationDate + "Z");
      // Time in HH:mm format
      let time = dateTime.toLocaleTimeString([], { timeStyle: "short"});
      let date = dateTime.toLocaleDateString();
      return `${time} ${date}`;
    },
  },
};
</script>

<style scoped>
.comment {
  background-color: bisque;
}
</style>
