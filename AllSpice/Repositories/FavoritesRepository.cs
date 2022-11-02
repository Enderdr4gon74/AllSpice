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

  internal Favorite getFavoriteById(int favoriteId)
  {
    string sql = "SELECT * FROM favorites WHERE id = @favoriteId;";

    List<Favorite> favorites = _db.Query<Favorite>(sql, new {favoriteId}).AsList();
    Favorite favorite = favorites[0];
    return favorite;
  }
  internal List<Favorite> getFavoritesByRecipeId(int recipeId)
  {
    string sql = "SELECT * FROM favorites WHERE recipeId = @recipeId;";

    List<Favorite> favorites = _db.Query<Favorite>(sql, new {recipeId}).AsList();
    return favorites;
  }

  internal void DeleteFavorite(int favoriteId)
  {
    string sql = "DELETE FROM favorites WHERE id = @favoriteId;";
    int rowsAffected = _db.Execute(sql, new {favoriteId});
    if (rowsAffected == 0) {
      throw new Exception("Unable to delete Favorite!");
    }
  }
}