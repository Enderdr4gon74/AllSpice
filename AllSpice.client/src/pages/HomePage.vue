<template>
  <div class="row">
    <div class="col-12 bg-image">
      <div class="row h-100 justify-content-center align-items-center">
        <div class="col-10 col-sm-8 col-md-6 col-lg-4 card bg-spec p-3 rounded-3 text-spec text-center">
          <h1>All spice</h1>
          <p class="m-0 text-uppercase fs-4">Cherish your family</p>
          <p class="m-0 text-uppercase fs-4">and their cooking</p>
        </div>
      </div>
    </div>
    <div class="col-12 bg-spec-2">
      <div class="row justify-content-center">
        <div class="col-8 p-2">
          <div class="row">
            <div class="col-2 bg-info rounded-pill p-2">
              
            </div>
          </div>
        </div>
        <div class="col-12">
          <div v-if="recipes" class="row justify-content-around gap-2 py-3">
            <Recipe v-for="r in recipes" :recipe="r" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { recipesService } from "../services/RecipesService.js"
import { favoritesService } from "../services/FavoritesService.js"
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';
import Recipe from "../components/Recipe.vue"

export default {
  setup() {
    async function GetRecipes() {
      try {
        await recipesService.getRecipes();
      } catch (error) {
        Pop.error(error, "[Getting recipes]")
      }
    }
    onMounted(() => {
      GetRecipes()
    })
    return {
      recipes: computed(() => AppState.recipes)
    }
  },
  components: { Recipe }
}
</script>

<style scoped lang="scss">
.bg-image {
  background-image: url("../assets/img/AllSpiceBG.png");
  min-height: 25rem;
  background-size: cover;
}

.bg-spec {
  background: rgba(15, 15, 22, 0.75);
  background: radial-gradient(circle, rgba(15, 15, 22, 0.9) 0%, rgba(15, 15, 22, 0.3) 100%);
  border: 0.01cm rgba(15, 15, 22, 0.9);
  color: rgb(228, 228, 224);
}

.bg-spec-2 {
  background: rgb(230, 230, 230);
  background: url("../assets/img/gradient.png");
  background-size: contain;
  background-repeat: repeat-y;
}

.text-spec {
  font-family: 'Kaushan Script', cursive;
}
</style>
