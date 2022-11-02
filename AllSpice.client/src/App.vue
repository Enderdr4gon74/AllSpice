<template>
  <header class="sticky-top position-absolute top-0 w-100 p-0">
    <Navbar />
  </header>
  <main class="container-fluid">
    <router-view />
  </main>
  <div class="modal modal-xl fade" id="recipeModal" tabindex="-1" aria-labelledby="recipeModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-fullscreen">
      <div class="modal-content bg-dark">
        <div class="modal-header text-light">
          <h1 class="modal-title fs-5" id="recipeModalLabel">Recipe</h1>
          <button type="button" class="btn btn-outline-light" data-bs-dismiss="modal" aria-label="Close">X</button>
        </div>
        <div class="modal-body" v-if="activeRecipe">
          <RecipeDetails :recipe="activeRecipe" />
        </div>
      </div>
    </div>
  </div>
  <div class="modal modal-xl fade" id="instructionsModal" tabindex="-1" aria-labelledby="instructionsModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-fullscreen">
      <div class="modal-content bg-dark">
        <div class="modal-header text-light">
          <h1 class="modal-title fs-5" id="instructionsModalLabel">Edit Instructions</h1>
          <button type="button" class="btn btn-outline-light" data-bs-dismiss="modal" aria-label="Close">X</button>
        </div>
        <div class="modal-body" v-if="true">
          <InstructionsForm />
          <!-- <RecipeDetails :recipe="activeRecipe" /> -->
        </div>
        <div class="modal-footer">
          <button class="btn btn-primary" data-bs-target="#recipeModal" data-bs-toggle="modal">Back to Recipe</button>
        </div>
      </div>
    </div>
  </div>
  <div class="offcanvas offcanvas-end text-bg-dark" tabindex="-1" id="CreateRecipe" aria-labelledby="CreateRecipeLabel">
    <div class="offcanvas-header">
      <h5 class="offcanvas-title" id="CreateRecipeLabel">Create Recipe</h5>
      <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
    </div>
    <div class="offcanvas-body">
      <CreateRecipeForm />
    </div>
  </div>
  <div v-if="account.id || user.id" class="position-absolute bottom-0 end-0 pb-2 pe-2">
    <button data-bs-toggle="offcanvas" data-bs-target="#CreateRecipe" class="btn btn-primary rounded-circle spec-button"> <i class="mdi mdi-plus-thick"></i> </button>
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
import InstructionsForm from './components/InstructionsForm.vue'
import CreateRecipeForm from './components/CreateRecipeForm.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState),
      account: computed(() => AppState.account),
      user: computed(() => AppState.user),
      activeRecipe: computed(() => AppState.activeRecipe)
    }
  },
  components: { Navbar, RecipeDetails, InstructionsForm, CreateRecipeForm }
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
