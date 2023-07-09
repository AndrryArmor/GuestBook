<template>
  <div class="comment rounded-3 col-xxl-10 p-2">
    <span class="h6">{{ authorName + " " }}</span>
    <small>{{ publicationDateString }}</small>
    <br />
    <span> {{ comment }} </span>
  </div>
</template>

<script>
export default {
  name: "GuestBookComment",
  props: {
    authorName: String,
    publicationDate: Date,
    comment: String,
  },

  computed: {
    publicationDateString() {
      let time = this.publicationDate.toLocaleTimeString([], {timeStyle: "short"});
      let date = this.publicationDate.toLocaleDateString();
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
