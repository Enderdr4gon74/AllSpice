<template>
  <div class="card bg-secondary p-3 rounded-3">
    <form @submit.prevent="handleSubmit()">
      <div class="form-floating mb-3">
        <input type="text" class="form-control" id="Name" placeholder="Account Name" v-model="editable.name">
        <label for="Name">Name</label>
      </div>
      <div class="form-floating mb-3">
        <input type="text" class="form-control" id="Image" placeholder="Account Image" v-model="editable.picture">
        <label for="Image">Image</label>
      </div>
      <div class="w-100 d-flex justify-content-end">
        <button type="submit" class="btn btn-success w-25"> Edit Account </button>
      </div>
    </form>
  </div>
</template>


<script>
import { ref, watchEffect } from 'vue'
import { AppState } from '../AppState.js'
import { accountService } from '../services/AccountService.js'
import Pop from '../utils/Pop.js'

export default {
  setup(){
    const editable = ref({})
    watchEffect(() => {
      editable.value = { ...AppState.account }
    })
    return {
      editable,
      async handleSubmit() {
        try {
          accountService.editAccount(editable.value)
        } catch (error) {
          Pop.error(error, "[Handling Submit]")
        }
      }
    }
  }
}
</script>
<style lang="scss" scoped>

</style>