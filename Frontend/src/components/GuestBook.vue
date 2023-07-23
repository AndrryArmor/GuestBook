<template>
  <div class="container">
    <GuestBookAddCommentForm />
    <GuestBookComment
      v-for="userComment in userComments"
      :userName="userComment.userName"
      :publicationDate="userComment.publicationDate"
      :comment="userComment.comment"
    />
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

<style scoped lang="scss">
@import "../assets/_variables.scss";

.container {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 0.25rem;
  padding: 0rem 0.5rem;
  margin-bottom: 0.25rem;
}
</style>
