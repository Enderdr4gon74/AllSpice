<template>
  <div class="row">
    <div class="col-12 px-0">
      <NavFiller />
      <AccountInfo :account="new Account(account)" />
    </div>
  </div>
  
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import NavFiller from '../components/NavFiller.vue';
import AccountInfo from '../components/AccountInfo.vue';
import { Account } from '../models/Account.js';
export default {
  setup() {
    return {
      Account: Account,
      account: computed(() => AppState.account)
    };
  },
  components: { NavFiller, AccountInfo }
}
</script>

<style scoped>

</style>
