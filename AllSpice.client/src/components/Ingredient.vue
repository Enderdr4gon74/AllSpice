<template>
  <li class="d-flex justify-content-between">
    <p class="m-0"> - {{ingredient.quantity}} {{ingredient.name}}</p>
    <button v-if="recipe.creatorId == account.id || recipe.creatorId == user.id" @click="deleteIngredient(ingredient.id)" class="btn btn-outline-danger"><i class="mdi mdi-delete-forever"></i></button>
  </li>
</template>


<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js"
import { Recipe } from "../models/Recipe.js";
import { ingredientsService } from "../services/IngredientsService.js";
import Pop from "../utils/Pop.js";

export default {
  props: {
    ingredient: { type: Ingredient, required: true},
    recipe: { type: Recipe, required: true }
  },
  setup(){
    return {
      user: computed(()=> AppState.user),
      account: computed(()=> AppState.account),
      async deleteIngredient(ingredientId) {
        try {
          await ingredientsService.deleteIngredient(ingredientId);
        } catch (error) {
          Pop.error(error, "[Deleting Ingredient]")
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
button {
  border-width: 0;
}
</style>