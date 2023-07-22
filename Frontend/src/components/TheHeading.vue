<template>
  <div class="heading">
    <h1>Guest Book</h1>
  </div>
</template>

<script>
export default {
  name: "TheHeading",
};
</script>

<style scoped lang="scss">
@import "../assets/_variables.scss";

.heading {
  display: flex;
  justify-content: center;
}

.heading h1 {
  margin: 0.5rem;
  font-weight: 500;
}
</style>
