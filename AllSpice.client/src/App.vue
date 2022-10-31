<template>
  <header class="sticky-top position-absolute top-0 w-100">
    <Navbar />
  </header>
  <main class="container-fluid">
    <router-view />
  </main>
  <div class="modal modal-xl fade" id="recipeModal" tabindex="-1" aria-labelledby="recipeModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-fullscreen">
    <div class="modal-content bg-dark">
      <div class="modal-header text-light">
        <h1 class="modal-title fs-5" id="recipeModalLabel">Modal title</h1>
        <button type="button" class="btn btn-outline-light" data-bs-dismiss="modal" aria-label="Close"><i class="mdi mdi-close"></i></button>
      </div>
      <div class="modal-body" v-if="activeRecipe">
        <RecipeDetails :recipe="activeRecipe" />
      </div>
    </div>
  </div>
</div>
  <!-- <footer class="bg-dark text-light">
    Made with <i class="mdi mdi-heart"></i> by DreamTeam: T
  </footer> -->
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import RecipeDetails from './components/RecipeDetails.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState),
      activeRecipe: computed(() => AppState.activeRecipe)
    }
  },
  components: { Navbar, RecipeDetails }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root{
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
