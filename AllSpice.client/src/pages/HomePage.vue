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
        <div class="col-8 p-2 d-flex">
          <button @click="unFilterRecipes()" class="btn btn-outline-danger w-1-5">Reset <i class="mdi mdi-restore"></i></button>
          <form class="d-flex w-4-5" @submit.prevent="filterRecipes()">
            <div class="form-floating w-75">
              <input type="text" class="form-control" id="category" placeholder="Category" v-model="editable.category">
              <label for="category">Category</label>
            </div>
            <button class="btn btn-outline-success w-25" type="submit">Search <i class="mdi mdi-magnify"></i></button>
          </form>
        </div>
        <div v-if="account.id || user.id" class="col-10">
          <div class="row justify-content-between">
            <div @click="showAll()" class="col-3 bg-secondary p-2 rounded-pill d-flex justify-content-center align-items-center selectable">
              <h3 class="m-0">All</h3>
            </div>
            <div @click="showYourFavorites()" class="col-3 bg-secondary p-2 rounded-pill d-flex justify-content-center align-items-center selectable">
              <h3 class="m-0">Favorites</h3>
            </div>
            <div @click="showYourOwn()" class="col-3 bg-secondary p-2 rounded-pill d-flex justify-content-center align-items-center selectable">
              <h3 class="m-0">Your Own</h3>
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
import { ref } from 'vue'

export default {
  setup() {
    const editable = ref({})
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
      editable,
      recipes: computed(() => AppState.recipes),
      account: computed(() => AppState.account),
      user: computed(() => AppState.user),
      filterRecipes() {
        try {
          recipesService.filterRecipes(editable.value)
        } catch (error) {
          Pop.error(error, "[Filtering Recipes]")
        }
      },
      unFilterRecipes() {
        try {
          recipesService.unFilterRecipes()
        } catch (error) {
          Pop.error(error, "[Un-Filtering Recipes]")
        }
      },
      showAll() {
        try {
          recipesService.showAll()
        } catch (error) {
          Pop.error(error, "[Showing All]")
        }
      },
      showYourFavorites() {
        try {
          recipesService.showYourFavorites()
        } catch (error) {
          Pop.error(error, "[Showing Your Favorites]")
        }
      },
      showYourOwn() {
        try {
          recipesService.showYourOwn()
        } catch (error) {
          Pop.error(error, "[Showing Your Own]")
        }
      },
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

.spec-col {
  width: 14.28571429%;
}

.w-1-5 {
  width: 20%;
}

.w-4-5 {
  width: 80%;
}

h3 {
  font-family: 'Kaushan Script', cursive;
}
</style>
