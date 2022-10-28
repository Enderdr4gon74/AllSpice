namespace AllSpice.Repositories;

public class RecipesRepository : BaseRepository
{
  public RecipesRepository(IDbConnection db) : base(db)
  {
  }

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    string sql = @"
    INSERT INTO recipes(title, instructions, img, category, creatorId)
    VALUES(@Title, @Instructions, @Img, @Category, @CreatorId);
    SELECT LAST_INSERT_ID();";
    int recipeId = _db.ExecuteScalar<int>(sql, recipeData);
    recipeData.Id = recipeId;
    return recipeData;
  }
}