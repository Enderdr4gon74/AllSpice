import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { api } from "./AxiosService.js";
import { ingredientsService } from "./IngredientsService.js";

class RecipesService {
  async getRecipes() {
    const recipes = await api.get('/api/recipes');
    AppState.recipes = recipes.data.map(r => new Recipe(r))
    AppState.shownRecipes = recipes.data.map(r => new Recipe(r))
  }

  async setActiveRecipe(recipeId) {
    AppState.activeRecipe = null;
    let recipeIndex = AppState.recipes.findIndex(r => r.id == recipeId);
    AppState.activeRecipe = AppState.recipes[recipeIndex]

    await ingredientsService.getIngredients(recipeId)
  }
}

export const recipesService = new RecipesService();