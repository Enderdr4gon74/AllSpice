<template>
  <div class="col-10 col-md-5 col-lg-3 card bg-dark spec-height my-auto px-0 rounded-2">
    <!-- <div class="row">
      <div class="col-5 d-flex p-2 justify-content-center align-items-center">
        <img :src="recipe.img" :alt="recipe.name" class="img-fluid w-75">
      </div>
      <div class="col-7 title-text text-secondary">
        <h1 class="m-0">{{recipe.title}}</h1>
        <p class="fs-5">{{recipe.category}}</p>
      </div>
    </div> -->
    <div class="position-relative row">
      <img :src="recipe.img" :alt="recipe.title" class="img-fluid w-100 rounded-2 selectable"  @click="setActiveRecipe(recipe.id)"  data-bs-toggle="modal" data-bs-target="#recipeModal">
      <div class="col-10 position-absolute bottom-0 start-50 translate-middle-x">
        <div class="pb-2">
          <div class="card bg-dark-tran p-1 d-flex text-center">
            <h4 class="m-0">{{recipe.title}}</h4>
          </div>
        </div>
      </div>
      <div class="col-6 position-absolute top-0 start-0">
        <div class="pt-1 ps-1">
          <div class="rounded-pill bg-primary py-spec px-spec text-center">
            <h5 class="mt-1 mb-0 fw-bold spec-text">{{recipe.category}}</h5>
          </div>
        </div>
      </div>
      <div class="col-2 position-absolute top-0 end-0">
        <div v-if="favorites.find(f => f.recipeId == recipe.id)" class="pt-1 pe-1 d-flex justify-content-end">
          <button @click="deleteFavorite(favorites.find(f => f.recipeId == recipe.id).id)" class="btn btn-outline-danger fs-3 py-1 px-2"><i class="mdi mdi-heart"></i></button>
        </div>
        <div v-else class="pt-1 pe-1 d-flex justify-content-end">
          <button @click="createFavorite(recipe.id)" v-if="user.id || account.id" class="btn btn-outline-primary fs-3 py-1 px-2"><i class="mdi mdi-heart-outline"></i></button>
          <button v-else disabled class="btn m-0 btn-outline-light fs-3 py-1 px-2"><i class="mdi mdi-heart-outline"></i></button>
        </div>
      </div>
    </div>
    <!-- <p>{{recipe}}</p> -->
  </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';
import { Recipe } from '../models/Recipe.js';
import { recipesService } from '../services/RecipesService.js';
import { favoritesService } from '../services/FavoritesService.js';

export default {
  props: {
    recipe: { type: Recipe, required: true },
  },
  setup() {
    return {
      favorites: computed(()=> AppState.favorites),
      account: computed(()=> AppState.account),
      user: computed(()=> AppState.user),
      async setActiveRecipe(recipeId) {
        await recipesService.setActiveRecipe(recipeId);
      },
      async deleteFavorite(favoriteId) {
        await favoritesService.deleteFavorite(favoriteId);
      },
      async createFavorite(recipeId) {
        await favoritesService.createFavorite(recipeId);
      },
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

.bg-dark-tran {
  background-color: rgba(12, 15, 22, 0.675);
}

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

button {
  border-width: 0;
}
</style>