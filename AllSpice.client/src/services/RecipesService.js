import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { api } from "./AxiosService.js";
import { ingredientsService } from "./IngredientsService.js";

class RecipesService {
  async getRecipes() {
    const recipes = await api.get('/api/recipes');
    AppState.recipes = recipes.data.map(r => new Recipe(r))
    AppState.hiddenRecipes = recipes.data.map(r => new Recipe(r))
    
  }

  async setActiveRecipe(recipeId) {
    AppState.activeRecipe = null;
    let recipeIndex = AppState.recipes.findIndex(r => r.id == recipeId);
    AppState.activeRecipe = AppState.recipes[recipeIndex]

    await ingredientsService.getIngredients(recipeId)
  }

  filterRecipes(wordData) {
    // console.log(wordData.category)
    AppState.recipes = AppState.hiddenRecipes.filter(f => f.category.toLowerCase() == wordData.category.toLowerCase())
    AppState.currentFilter = 1;
    AppState.filterName = wordData.category
  }

  unFilterRecipes() {
    // console.log("unfiltered recipes?")
    AppState.recipes = AppState.hiddenRecipes.filter(f => f);
    AppState.currentFilter = 0;
  }

  showAll() {
    this.unFilterRecipes()
  }

  showYourFavorites() {
    let recipes = []
    AppState.favorites.forEach(f=>{
      recipes = [ ...recipes, new Recipe(AppState.hiddenRecipes.filter(r => r.id == f.recipeId)[0]) ]
    })
    // recipes = recipes.map(r => new Recipe(r.target))
    console.log(recipes)
    AppState.recipes = recipes
    AppState.currentFilter = 2
  }

  showYourOwn() {
    console.log("showing your own")
    AppState.recipes = AppState.hiddenRecipes.filter(r => r.creatorId == AppState.user.id)
    AppState.currentFilter = 3
  }

  async deleteRecipe(recipeId) {
    const message = await api.delete(`/api/recipes/${recipeId}`)
    const recipeIndex = AppState.hiddenRecipes.findIndex(r => r.id == recipeId)
    AppState.hiddenRecipes.splice(recipeIndex, 1)
    this.refilter()
  }

  async createRecipe(recipeData) {
    console.log(recipeData)
    const newRecipe = await api.post("/api/recipes", recipeData);
    AppState.hiddenRecipes.push(new Recipe(newRecipe.data))
    this.refilter()
    // con
  }

  refilter() {
    if (AppState.currentFilter == 0) {
      this.unFilterRecipes()
    } else if (AppState.currentFilter == 1) {
      this.filterRecipes(AppState.currentFilter)
    } else if (AppState.currentFilter == 2) {
      this.showYourFavorites()
    } else if (AppState.currentFilter == 3) {
      this.showYourOwn()
    }
  }
}

export const recipesService = new RecipesService();