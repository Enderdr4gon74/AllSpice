<template>
  <div class="col-5 card bg-dark spec-height my-auto">
    <div class="row">
      <div class="col-6 d-flex p-2 justify-content-center align-items-center">
        <img :src="recipe.img" :alt="recipe.name" class="img-fluid w-75">
      </div>
      <div class="col-6">
        <h3>{{recipe.title}}</h3>
      </div>
    </div>
    <!-- <p>{{recipe}}</p> -->
  </div>
</template>


<script>
import { Recipe } from '../models/Recipe.js';

export default {
  props: {
    recipe: { type: Recipe, required: true},
  },
  setup(){
    return {}
  }
}
</script>


<style lang="scss" scoped>
.spec-height {
  height: fit-content;
}
</style>