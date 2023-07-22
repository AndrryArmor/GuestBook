<template>
  <div class="comment">
    <button v-if="!isFormActive" @click="isFormActive = true" class="button button-success">
      Add new comment
    </button>
    <template v-else>
      <h5>New comment</h5>
      <form @submit.prevent="submitForm" @reset="resetForm" class="form" novalidate>
        <fieldset>
          <label for="comment-username" class="form-label">Your name</label>
          <input
            type="text"
            v-model="userName"
            class="form-control"
            :class="applyValidityClass(v$.userName)"
            id="comment-username"
            maxlength="100"
            style="max-width: 15rem"
            :readonly="isPostingComment"
          />
          <div class="invalid-feedback">
            <div v-for="error of v$.userName.$errors" :key="error.$uid">
              <small>{{ error.$message }}</small>
            </div>
          </div>
        </fieldset>
        <fieldset>
          <label for="comment-text" class="form-label">Comment</label>
          <textarea
            v-model="comment"
            class="form-control"
            :class="applyValidityClass(v$.comment)"
            id="comment-text"
            rows="3"
            maxlength="4000"
            :readonly="isPostingComment"
          ></textarea>
          <div class="invalid-feedback">
            <div v-for="error of v$.comment.$errors" :key="error.$uid">
              <small>{{ error.$message }}</small>
            </div>
          </div>
        </fieldset>
        <fieldset :disabled="isPostingComment" class="form-buttons">
          <button type="submit" class="button button-success">
            <template v-if="!isPostingComment">Add comment</template>
            <template v-else>
              <span class="spinner-border spinner-border-sm" role="status"></span>
              Loading...
            </template>
          </button>
          <button type="reset" class="button button-secondary">Cancel</button>
        </fieldset>
      </form>
    </template>
  </div>
</template>

<script>
import { useVuelidate } from "@vuelidate/core";
import { helpers, required, minLength } from "@vuelidate/validators";

export default {
  name: "GuestBookAddCommentForm",

  setup() {
    return { v$: useVuelidate() };
  },
  data() {
    return {
      userName: "",
      comment: "",
      isFormActive: false,
      isPostingComment: false,
    };
  },
  validations() {
    return {
      userName: {
        required: helpers.withMessage("Your name must not be empty.", required),
        minLength: helpers.withMessage(
          ({ $params }) => `Your name must be at least ${$params.min} characters long.`,
          minLength(3)
        ),
      },
      comment: {
        required: helpers.withMessage("Comment must not be empty.", required),
        minLength: helpers.withMessage(
          ({ $params }) => `Comment must be at least ${$params.min} characters long.`,
          minLength(10)
        ),
      },
    };
  },

  methods: {
    async submitForm() {
      this.v$.$touch();
      if (this.v$.$invalid) return;

      this.isPostingComment = true;
      let errorMessage = await this.postComment();
      this.isPostingComment = false;
      if (errorMessage) {
        setTimeout(() => {
          alert(errorMessage);
        }, 100);
      }
    },
    async postComment() {
      let errorMessage = "";
      try {
        const response = await fetch("https://localhost:7023/api/guest-book/comments", {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({
            userName: this.userName,
            comment: this.comment,
          }),
        });
        if (response.status == 400) {
          let errorResponse = await response.json();
          let errors = [];
          for (const key in errorResponse.errors) {
            if (Object.hasOwnProperty.call(errorResponse.errors, key)) {
              const element = errorResponse.errors[key];
              errors.push(element);
            }
          }
          throw new Error(
            `One or more validation errors occured.\n\nErrors:\n${errors.join("\n")}`
          );
        } else if (!response.ok) {
          throw new Error("Comment was not sent due to some network error.");
        }
        window.location.reload();
      } catch (error) {
        console.log(error);
        errorMessage = error.message;
      }
      return errorMessage;
    },
    resetForm() {
      this.userName = "";
      this.comment = "";
      this.isFormActive = false;
      this.v$.$reset();
    },
    applyValidityClass(vElement) {
      return {
        "is-valid": this.v$.$dirty && !vElement.$error,
        "is-invalid": this.v$.$dirty && vElement.$error,
      };
    },
  },
};
</script>

<style scoped lang="scss">
@import "../assets/_variables.scss";

$green-button: #198754;
$grey-button: #6c757d;

.comment {
  background-color: bisque;
  max-width: $width-container;
  width: 100%;
  border-radius: 0.5rem;
  padding: 0.5rem;
}

.comment .form {
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
}

.comment .form .form-label {
  margin-bottom: 0.5rem;
}

.comment .form .form-control {
    width: 100%;
    padding: 0.375rem 0.75rem;
    margin-bottom: 0.5rem;
    border-radius: 0.375rem;
  }

.comment .form .form-buttons {
  display: flex;
  flex-wrap: wrap;
  gap: 0.5rem;
}
.comment .button {
  border: 1px solid;
  border-radius: 0.375rem;
  padding: 0.375rem 0.75rem;
}

.comment .button.button-success {
  color: white;
  background-color: $green-button;
  border-color: $green-button;
}

.comment .button.button-secondary {
  color: white;
  background-color: $grey-button;
  border-color: $grey-button;
}
</style>
