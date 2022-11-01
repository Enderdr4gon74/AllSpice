import { AppState } from "../AppState.js";
import { api } from "./AxiosService.js";
import { Recipe } from "../models/Recipe.js"

class InstructionsService {
  
  async editInstructions(newInstructions) {
    const recipeId = AppState.activeRecipe.id
    const newerInstructions = { instructions: newInstructions }
    // console.log(newerInstructions);
    const newRecipe = await api.put(`/api/recipes/${recipeId}`, newerInstructions);
    const recipeIndex = AppState.recipes.findIndex(r => r.id == recipeId);
    const newerRecipe = new Recipe(newRecipe.data);
    AppState.activeRecipe = newerRecipe;
    AppState.recipes[recipeIndex] = newerRecipe;
  }

}

export const instructionsService = new InstructionsService();