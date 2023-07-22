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

*, ::after, ::before {
    box-sizing: border-box;
}

body {
  margin: 0;
  font-family: system-ui, "Segoe UI", Arial, sans-serif;
  font-size: 1rem;
  line-height: 1.5;
  color: black;
  background-color: tan;
}
</style>
