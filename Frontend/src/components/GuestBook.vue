<template>
  <div class="container-xl">
    <div class="row row-cols-1 g-1 justify-content-center">
      <GuestBookAddCommentForm />
      <GuestBookComment
        v-for="userComment in userComments"
        :authorName="userComment.userName"
        :publicationDate="userComment.publicationDate"
        :comment="userComment.comment"
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
      userComments: [],
    };
  },

  mounted() {
    this.getAllComments();
  },

  methods: {
    async getAllComments() {
      try {
        const response = await fetch("https://localhost:7023/api/guest-book/comments");
        if (!response.ok) {
          throw new Error("Error fetching comments.");
        }
        this.userComments = await response.json();
      } catch (error) {
        console.log(error);
      }
    },
  },
};
</script>

<style scoped></style>
