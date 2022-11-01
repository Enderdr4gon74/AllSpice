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
  }

  unFilterRecipes() {
    // console.log("unfiltered recipes?")
    AppState.recipes = AppState.hiddenRecipes.filter(f => f);
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
  }

  showYourOwn() {
    console.log("showing your own")
    AppState.recipes = AppState.hiddenRecipes.filter(r => r.creatorId == AppState.user.id)
  }
}

export const recipesService = new RecipesService();