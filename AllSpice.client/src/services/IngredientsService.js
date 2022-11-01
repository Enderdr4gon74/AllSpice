import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js";
import { api } from "./AxiosService.js";

class IngredientsService {
  async getIngredients(recipeId) {
    AppState.ingredients = null
    const ingredients = await api.get(`/api/recipes/${recipeId}/ingredients`)
    AppState.ingredients = ingredients.data.map(i => new Ingredient(i))
  }

  async addIngredient(newIngredient){
    const newerIngredient = {
      quantity: newIngredient.value.quantity,
      name: newIngredient.value.name,
      recipeId: AppState.activeRecipe.id,
    }
    console.log(newerIngredient)
    const newestIngredient = await api.post('/api/ingredients', newerIngredient);
    // console.log(newestIngredient.data)
    const newestestIngredient = new Ingredient(newestIngredient.data);
    // console.log(newestestIngredient)
    AppState.ingredients.push(newestestIngredient)
  }
}

export const ingredientsService = new IngredientsService();