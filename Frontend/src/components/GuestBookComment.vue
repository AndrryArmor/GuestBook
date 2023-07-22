<template>
  <div class="comment">
    <span class="username">{{ userName + " " }}</span>
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
      let time = dateTime.toLocaleTimeString([], { timeStyle: "short" });
      let date = dateTime.toLocaleDateString();
      return `${time} ${date}`;
    },
  },
};
</script>

<style scoped lang="scss">
@import "../assets/_variables.scss";

.comment {
  background-color: bisque;
  overflow-wrap: break-word;
  width: 100%;
  max-width: $width-container;
  border-radius: 0.5rem;
  padding: 0.5rem;
}

.comment .username {
   font-weight: 500;
}
</style>
