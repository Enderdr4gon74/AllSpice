<template>
  <form @submit.prevent="handleSubmit()">

    <div class="form-floating">
      <textarea class="form-control" placeholder="Instructions" id="Instructions" v-model="editable.instructions"></textarea>
      <label for="Instructions">Instructions</label>
    </div>
    <button type="submit" data-bs-target="#recipeModal" data-bs-toggle="modal" class="btn btn-success"> Add Ingredient </button>
    <!-- <h1>test</h1> -->
  </form>
</template>


<script>
import { ref, watchEffect } from 'vue'
import { AppState } from '../AppState.js'
import Pop from '../utils/Pop.js'
import { instructionsService } from "../services/InstructionsService.js"

export default {
  setup(){
    const editable = ref({})
    watchEffect(() => {
      editable.value = { ...AppState.activeRecipe }
    })
    return {
      editable,
      async handleSubmit() {
        try {
          await instructionsService.editInstructions(editable.value.instructions);
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