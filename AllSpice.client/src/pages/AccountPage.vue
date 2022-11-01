<template>
  <NavFiller />
  <AccountForm />
  <!-- <div class="about text-center">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
  </div> -->
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import NavFiller from '../components/NavFiller.vue';
import AccountForm from '../components/AccountForm.vue';
export default {
    setup() {
        return {
            account: computed(() => AppState.account)
        };
    },
    components: { NavFiller, AccountForm }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
