namespace AllSpice.Repositories;

public class FavoritesRepository : BaseRepository
{
  public FavoritesRepository(IDbConnection db) : base(db)
  {
  }

  internal Favorite CreateFavorite(Favorite favoriteData)
  {
    string sql = @"
    INSERT INTO favorites(recipeId, accountId)
      VALUES(@RecipeId, @AccountId);
      SELECT LAST_INSERT_ID();";
    int id = _db.ExecuteScalar<int>(sql, favoriteData);
    favoriteData.Id = id;
    return favoriteData;
  }

  internal List<Favorite> getFavoritesByAccountId(string userId)
  {
    string sql = "SELECT * FROM favorites fav WHERE fav.accountId = @userId;";
    List<Favorite> favorites = _db.Query<Favorite>(sql, new {userId}).AsList();
    return favorites;
  }
}