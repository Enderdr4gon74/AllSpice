<template>
  <!-- <div v-if="account" class="about text-center">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
  </div> -->
  <div class="card p-3 bg-secondary m-3 rounded-4">
    <div class="row">
      <div class="col-4">
        <img :src="account.picture" :alt="account.name" class="img-fluid w-100 rounded-4">
      </div>
      <div class="col-8">
        <div class="row">
          <div class="col-12">
            <h1><span class="text-success">Name:</span> {{account.name}}</h1>
            <h4 class="mb-3"><span class="text-success">Email:</span> {{account.email}}</h4>
          </div>
          <div class="col-12">
            <AccountForm />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { Account } from '../models/Account.js';
import AccountForm from '../components/AccountForm.vue';

export default {
  props: {
    account: { type: Account, required: true},
  },
  setup(){
    return {}
  },
  components: { AccountForm }
}
</script>


<style lang="scss" scoped>
// img {
//   max-width: 100px;
// }
</style>