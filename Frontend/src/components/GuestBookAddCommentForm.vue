<template>
  <div class="row mx-0 justify-content-center">
    <div class="col-auto p-1">
      <h3 class="mb-3">New comment</h3>
      <form class="row g-3">
        <div class="col-6">
          <label for="comment-name" class="form-label">Your name</label>
          <input type="text" class="form-control" id="comment-name" />
        </div>
        <div class="col-12">
          <label for="comment-text" class="form-label">Comment</label>
          <textarea class="form-control" id="comment-text" rows="5"></textarea>
        </div>
        <div class="col">
          <button type="submit" class="btn btn-primary">Add comment</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  name: "GuestBook",
  components: {},
};
</script>

<style scoped></style>
