<template>
  <form @submit.prevent="handleSubmit()" class="text-dark">
    <div class="form-floating mb-3">
      <input type="text" class="form-control" id="Title" placeholder="Enter Recipe Name" v-model="editable.title" required>
      <label for="Title">Recipe Name</label>
    </div>
    <div class="form-floating mb-3">
      <input type="url" class="form-control" id="Img" placeholder="Image Link" v-model="editable.img" required>
      <label for="Img">Image Link</label>
    </div>
    <div class="form-floating mb-3">
      <select class="form-select" id="Category" v-model="editable.category" required>
        <option value="soup">Soup</option>
        <option value="Italian">Italian</option>
        <option value="mexican">Mexican</option>
        <option value="cheese">Cheese</option>
        <option value="specialty coffee">Specialty Coffee</option>
      </select>
      <label for="Category">Category</label>
    </div>
    <div class="form-floating mb-3">
      <textarea class="form-control" placeholder="Enter Your Instructions Here..." id="Instructions" v-model="editable.instructions" required  minlength="10"></textarea>
      <label for="Instructions">Instructions</label>
    </div>
    <div class="w-100 d-flex justify-content-end">
      <button type="submit" class="btn btn-success w-50"> Create Recipe </button>
    </div>
  </form>
</template>


<script>
import { ref } from 'vue'
import { recipesService } from '../services/RecipesService.js'
import Pop from '../utils/Pop.js'

export default {
  setup(){
    const editable = ref({})
    return {
      editable,
      async handleSubmit() {
        try {
          recipesService.createRecipe(editable.value)
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