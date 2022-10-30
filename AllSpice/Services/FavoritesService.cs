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
}