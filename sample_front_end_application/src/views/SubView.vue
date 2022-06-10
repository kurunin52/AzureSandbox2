<template>
  <v-main>
    <h1 v-html="title" />
  </v-main>
</template>

<script>
export default {
  data() {
    return {
      title: '<span>タイトル<br>下見出し</span>',
    };
  },
};
</script>
