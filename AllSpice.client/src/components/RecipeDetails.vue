<template>
  <div class="row">
    <div class="col-4">
      <img :src="recipe.img" :alt="recipe.title" class="img-fluid w-100">
    </div>
    <div class="col-8">
      <div class="row justify-content-center">
        <!-- Title & Category -->
        <div class="col-12">
          <div class="row justify-content-between align-items-center">
            <div class="col-7 d-flex gap-3 align-items-center">
              <h1 class="spec-text">{{recipe.title}}</h1>
              <div class="rounded-pill bg-secondary py-spec px-spec">
                <p class="mt-1 mb-0 fw-bold spec-text">{{recipe.category}}</p>
              </div>  
            </div>
            <div class="col-4 d-flex justify-content-end align-items-center gap-3">
              <div v-if="recipe.creatorId == user.id || recipe.creatorId == account.id">
                <button @click="deleteRecipe(recipe.id)" data-bs-dismiss="modal" class="btn btn-outline-danger spec-button"><i class="mdi mdi-delete-forever"></i></button>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="col-12">
        <div class="row justify-content-around p-2 gap-2 align-items-start">
          <div class="col-5 bg-secondary rounded-3 p-0">
            <div class="bg-primary d-flex justify-content-center py-2 rounded-top-spec">
              <h3 class="mt-1 mb-0 fw-semibold text-light spec-text letters">Recipe Steps</h3>
            </div>
            <div class="p-2">
              {{recipe.instructions}}
            </div>
            <div v-if="recipe.creatorId == user.id || recipe.creatorId == account.id" class="p-1" >
              <button data-bs-target="#instructionsModal" data-bs-toggle="modal" class="btn btn-success w-100"> Edit Instructions </button>
            </div>
          </div>
          <div class="col-5 bg-secondary rounded-3 p-0">
            <div class="bg-primary d-flex justify-content-center py-2 rounded-top-spec">
              <h3 class="mt-1 mb-0 fw-semibold text-light spec-text letters">Ingredients</h3>
            </div>
            <div class="p-2">
              <ul v-if="ingredients" class="my-1 ps-2">
                <Ingredient v-for="i in ingredients" :ingredient="i" :recipe="recipe" />
              </ul>
              <!-- <p>TODO add ingredients here</p> -->
            </div>
            <div v-if="recipe.creatorId == user.id || recipe.creatorId == account.id" class="p-1" >
              <form @submit.prevent="AddIngredient()">
                <div class="form-floating mb-1">
                  <input type="text" class="form-control" placeholder="Amount" v-model="newIngredient.quantity" id="amount">
                  <label for="amount">Ingredient Amount</label>
                </div>
                <div class="form-floating mb-1">
                  <input type="text" class="form-control" placeholder="Type" v-model="newIngredient.name" id="type">
                  <label for="type">Ingredient Type</label>
                </div>
                <button type="submit" class="btn btn-success"> Add Ingredient </button>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- {{recipe}} -->
</template>


<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';
import { Recipe } from '../models/Recipe.js';
import { ingredientsService } from '../services/IngredientsService.js';
import Ingredient from './Ingredient.vue';
import { ref } from 'vue'
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js';

export default {
  props: {
    recipe: { type: Recipe, required: true },
  },
  setup() {
    const newIngredient = ref({name: "", quantity: "", recipeId: 0})
    return {
      ingredients: computed(() => AppState.ingredients),
      user: computed(()=> AppState.user),
      account: computed(()=> AppState.account),
      newIngredient,
      async AddIngredient() {
        try {
          await ingredientsService.addIngredient(newIngredient);
        } catch (error) {
          Pop.error(error, "[Handling Submit]")
        }
      },
      async deleteRecipe(recipeId) {
        try {
          await recipesService.deleteRecipe(recipeId)
          Pop.success("Recipe Deleted");
        } catch (error) {
          Pop.error(error, "[Handling Submit]")
        }
      }
    };
  },
  components: { Ingredient }
}
</script>


<style lang="scss" scoped>
.py-spec {
  padding-top: 0.125rem;
  padding-bottom: 0.125rem;
}

.px-spec {
  padding-left: 0.75rem;
  padding-right: 0.75rem;
}

.spec-text {
  font-family: 'Gochi Hand', cursive;
}

.rounded-top-spec {
  border-top-left-radius: 0.5rem;
  border-top-right-radius: 0.5rem;
}

.letters {
  letter-spacing: 2px;
}

.spec-button {
  border-width: 0;
}
</style>