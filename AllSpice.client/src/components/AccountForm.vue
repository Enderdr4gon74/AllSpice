<template>
  <form @submit.prevent="handleSubmit()">


  </form>
</template>


<script>
import { ref, watchEffect } from 'vue'
import { AppState } from '../AppState.js'
import Pop from '../utils/Pop.js'

export default {
  setup(){
    const editable = ref({})
    watchEffect(() => {
      editable.value = { ...AppState.___ }
    })
    return {
      editable,
      async handleSubmit() {
        try {

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