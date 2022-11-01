import { AppState } from "../AppState.js";
import { Favorite } from "../models/Favorite.js";
import { api } from "./AxiosService.js";

class FavoritesService {
  async getFavorites() {
    const favorites = await api.get("/account/favorites")
    AppState.favorites = favorites.data.map(f=>new Favorite(f))
  }

  async createFavorite(recipeId) {
    console.log(recipeId, "creating favorite using recipe id")
    const newFavorite = await api.post("/api/favorites", {recipeId})
    AppState.favorites.push(new Favorite(newFavorite.data))
  }
  
  async deleteFavorite(favoriteId) {
    console.log(favoriteId, "deleting favorite using favorite id")
    await api.delete(`/api/favorites/${favoriteId}`)
    const favIndex = AppState.favorites.findIndex(f => f.id == favoriteId)
    AppState.favorites.splice(favIndex, 1)
  }
}

export const favoritesService = new FavoritesService();