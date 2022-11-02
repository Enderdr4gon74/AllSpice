<template>
  <!-- <div v-if="account" class="about text-center">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
  </div> -->
</template>


<script>
import { Account } from '../models/Account.js';

export default {
  props: {
    account: { type: Account, required: true},
  },
  setup(){
    return {}
  }
}
</script>


<style lang="scss" scoped>
// img {
//   max-width: 100px;
// }
</style>