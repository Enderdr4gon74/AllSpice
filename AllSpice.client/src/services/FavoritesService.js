import { AppState } from "../AppState.js";
import { Favorite } from "../models/Favorite.js";
import { api } from "./AxiosService.js";

class FavoritesService {
  async getFavorites() {
    const favorites = await api.get("/account/favorites")
    console.log(favorites)
    console.log(favorites.data)
    let newFavorites = favorites.data;
    // for (let x = 0; x < newFavorites.length; x++) {
    //   newFavorites[x].recipeId = favorites.data[x].recipeId
    //   console.log(favorites.data[x].recipeId)
    // }
    let newerFavorites = newFavorites.map(f => new Favorite(f));
    console.log(newFavorites)
    AppState.favorites = newFavorites;
  }
}

export const favoritesService = new FavoritesService();