<template>
  <TheHeading />
  <GuestBook />
</template>

<script>
import TheHeading from "./components/TheHeading.vue";
import GuestBook from "./components/GuestBook.vue";

export default {
  name: "App",
  components: {
    TheHeading,
    GuestBook,
  },
};
</script>

<style lang="scss">
@import "./assets/_variables.scss";

body.body {
  background-color: tan;
}
</style>
