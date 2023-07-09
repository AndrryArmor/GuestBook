<template>
  <div class="comment rounded-3 col-xxl-10 p-2">
    <button v-if="!isAddCommentFormActive" @click="toggleAddCommentForm" class="btn btn-success">
      Add new comment
    </button>
    <template v-else>
      <h5 class="mb-2">New comment</h5>
      <form @submit="onCommentSubmit" @reset="onCommentReset" class="row g-2">
        <div class="col-12" style="max-width: 15rem">
          <label for="comment-name" class="form-label">Your name</label>
          <input type="text" v-model="authorName" class="form-control" id="comment-name" />
        </div>
        <div class="col-12">
          <label for="comment-text" class="form-label">Comment</label>
          <textarea v-model="comment" class="form-control" id="comment-text" rows="3"></textarea>
        </div>
        <div class="col-12">
          <div class="row row-cols-auto g-2">
            <div class="col">
              <button type="submit" class="btn btn-success">Add comment</button>
            </div>
            <div class="col">
              <button @click="toggleAddCommentForm" type="reset" class="btn btn-secondary">
                Cancel
              </button>
            </div>
          </div>
        </div>
      </form>
    </template>
  </div>
</template>

<script>
export default {
  name: "GuestBookAddCommentForm",

  data() {
    return {
      authorName: "",
      comment: "",
      isAddCommentFormActive: false,
    };
  },

  methods: {
    toggleAddCommentForm() {
      this.isAddCommentFormActive = !this.isAddCommentFormActive;
    },
    onCommentSubmit() {
      this.postComment();
    },
    onCommentReset() {
      this.authorName = "";
      this.comment = "";
    },
    async postComment() {
      try {
        const response = await fetch("https://localhost:7023/api/guest-book/comments", {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            userName: this.authorName,
            publicationDate: new Date(Date.now()),
            comment: this.comment,
          }),
        });
        if (!response.ok) {
          throw new Error("Error while posting comment.");
        }
      } catch (error) {
        console.log(error);
      }
    },
  },
};
</script>

<style scoped>
.comment {
  background-color: bisque;
}
</style>
