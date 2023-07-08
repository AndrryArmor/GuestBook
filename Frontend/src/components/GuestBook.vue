<template>
  <div class="container-xl">
    <div class="row row-cols-1 g-1 justify-content-center">
      <GuestBookAddCommentForm />
      <GuestBookComment />
      <GuestBookComment />
      <GuestBookComment />
      <GuestBookComment />
      <GuestBookComment />
      <GuestBookComment />
      <GuestBookComment />
    </div>
  </div>
</template>

<script>
import GuestBookComment from "./GuestBookComment.vue";
import GuestBookAddCommentForm from "./GuestBookAddCommentForm.vue";

export default {
  name: "GuestBook",
  components: {
    GuestBookComment,
    GuestBookAddCommentForm,
  },
};
</script>

<style scoped></style>
