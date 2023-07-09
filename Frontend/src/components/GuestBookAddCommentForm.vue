<template>
  <div class="comment rounded-3 col-xxl-10 p-2">
    <button v-if="!isFormActive" @click="isFormActive = true" class="btn btn-success">
      Add new comment
    </button>
    <template v-else>
      <h5 class="mb-2">New comment</h5>
      <form @submit.prevent="submitForm" @reset="resetForm" class="row g-2">
        <fieldset class="col-12" style="max-width: 15rem">
          <label for="comment-name" class="form-label">Your name</label>
          <input
            type="text"
            v-model="authorName"
            id="comment-name"
            class="form-control"
            :readonly="isPostingComment"
          />
        </fieldset>
        <fieldset class="col-12">
          <label for="comment-text" class="form-label">Comment</label>
          <textarea
            v-model="comment"
            id="comment-text" 
            class="form-control"
            rows="3"
            :readonly="isPostingComment"
          ></textarea>
        </fieldset>
        <fieldset :disabled="isPostingComment" class="col-12">
          <div class="row row-cols-auto g-2">
            <div class="col">
              <button type="submit" class="btn btn-success">
                <template v-if="!isPostingComment">Add comment</template>
                <template v-else>
                  <span class="spinner-border spinner-border-sm" role="status"></span>
                  Loading...
                </template>
              </button>
            </div>
            <div class="col">
              <button type="reset" class="btn btn-secondary">Cancel</button>
            </div>
          </div>
        </fieldset>
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
      isFormActive: false,
      isPostingComment: false,
    };
  },

  methods: {
    async submitForm() {
      this.isPostingComment = true;
      let isSucceded = await this.postComment();
      this.isPostingComment = false;
      if (!isSucceded) {
        setTimeout(() => {
          alert("Comment was not sent due to some error.");
        }, 100);
      }
    },
    async postComment() {
      let isSucceded = true;
      try {
        const response = await fetch("https://localhost:7023/api/guest-book/comments", {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({ userName: this.authorName, comment: this.comment }),
        });
        if (!response.ok) {
          throw new Error("Error while posting comment.");
        }
        window.location.reload();
      } catch (error) {
        console.log(error);
        isSucceded = false;
      }
      return isSucceded;
    },
    resetForm() {
      this.authorName = "";
      this.comment = "";
      this.isFormActive = false;
    },
  },
};
</script>

<style scoped>
.comment {
  background-color: bisque;
}
</style>
