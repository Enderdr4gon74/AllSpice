namespace AllSpice.Services;

public class FavoritesService
{
  private readonly FavoritesRepository _repo;

  public FavoritesService(FavoritesRepository repo)
  {
    _repo = repo;
  }

  internal Favorite CreateFavorite(Favorite favoriteData)
  {
    return _repo.CreateFavorite(favoriteData);
  }

  internal List<Favorite> getFavoritesByAccountId(string userId)
  {
    return _repo.getFavoritesByAccountId(userId);
  }

  internal Favorite getFavoriteById(int favoriteId)
  {
    return _repo.getFavoriteById(favoriteId);
  }

  internal void DeleteFavorite(int favoriteId, string userId)
  {
    Favorite favorite = getFavoriteById(favoriteId);
    if (favorite.AccountId != userId) {
      throw new Exception("Not your Favorite!");
    }
    _repo.DeleteFavorite(favoriteId);
  }
}