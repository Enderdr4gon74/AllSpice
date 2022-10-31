import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js";
import { api } from "./AxiosService.js";

class IngredientsService {
  async getIngredients(recipeId) {
    AppState.ingredients = null
    const ingredients = await api.get(`/api/recipes/${recipeId}/ingredients`)
    AppState.ingredients = ingredients.data.map(i => new Ingredient(i))
  }
}

export const ingredientsService = new IngredientsService();