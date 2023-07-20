<template>
  <div class="heading-container">
    <div class="heading">
      <h1>Guest Book</h1>
    </div>
  </div>
</template>

<script>
export default {
  name: "TheHeading",
};
</script>

<style scoped lang="scss">
@import "../assets/_variables.scss";

.heading-container {
  display: flex;
  justify-content: center;
}

.heading-container .heading {
  display: flex;
  justify-content: center;
  width: $width-container;
  padding: 0.5rem 0rem;
}
</style>
