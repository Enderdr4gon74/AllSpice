<template>
  <div class="col-5 card bg-dark spec-height my-auto selectable" @click="setActiveRecipe(recipe.id)"  data-bs-toggle="modal" data-bs-target="#recipeModal">
    <div class="row">
      <div class="col-5 d-flex p-2 justify-content-center align-items-center">
        <img :src="recipe.img" :alt="recipe.name" class="img-fluid w-75">
      </div>
      <div class="col-7 title-text text-secondary">
        <h1 class="m-0">{{recipe.title}}</h1>
        <p class="fs-5">{{recipe.category}}</p>
      </div>
    </div>
    <!-- <p>{{recipe}}</p> -->
  </div>
</template>


<script>
import { Recipe } from '../models/Recipe.js';
import { recipesService } from '../services/RecipesService.js';

export default {
  props: {
    recipe: { type: Recipe, required: true },
  },
  setup() {
    return {
      async setActiveRecipe(recipeId) {
        await recipesService.setActiveRecipe(recipeId);
      }
    };
  },
}
</script>


<style lang="scss" scoped>
.spec-height {
  height: fit-content;
}

.title-text{
  font-family: 'Gochi Hand', cursive;
}
</style>