<template>
  <div class="row">
    <div class="col-4">
      <img :src="recipe.img" :alt="recipe.title" class="img-fluid w-100">
    </div>
    <div class="col-8">
      <div class="row justify-content-center">
        <!-- Title & Category -->
        <div class="col-12 d-flex gap-2 align-items-center">
          <h1 class="spec-text">{{recipe.title}}</h1>
          <div class="rounded-pill bg-secondary py-spec px-spec">
            <p class="mt-1 mb-0 fw-bold spec-text">{{recipe.category}}</p>
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
            <div>

            </div>
          </div>
          <div class="col-5 bg-secondary rounded-3 p-0">
            <div class="bg-primary d-flex justify-content-center py-2 rounded-top-spec">
              <h3 class="mt-1 mb-0 fw-semibold text-light spec-text letters">Ingredients</h3>
            </div>
            <div class="p-2">
              <ul v-if="ingredients" class="my-1 ps-2">
                <Ingredient v-for="i in ingredients" :ingredient="i" />
              </ul>
              <!-- <p>TODO add ingredients here</p> -->
            </div>
            <div>
              
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
import Ingredient from './Ingredient.vue';

export default {
    props: {
        recipe: { type: Recipe, required: true },
    },
    setup() {
        return {
            ingredients: computed(() => AppState.ingredients)
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
</style>