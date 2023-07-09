<template>
  <div class="container-xl">
    <div class="row row-cols-1 g-1 justify-content-center">
      <GuestBookAddCommentForm />
      <GuestBookComment
        v-for="i in 6"
        :authorName="authorName"
        :publicationDate="publicationDate"
        :comment="comment"
      />
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

  data() {
    return {
      authorName: "Author",
      publicationDate: new Date(),
      comment:
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
    };
  },
};
</script>

<style scoped></style>
