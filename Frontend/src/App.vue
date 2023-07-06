<template>
  <GuestBook />
</template>

<script>
import GuestBook from "./components/GuestBook.vue";

export default {
  name: "App",
  components: {
    GuestBook,
  },
};
</script>

<style>
body.body {
  background-color: tan;
}
</style>
