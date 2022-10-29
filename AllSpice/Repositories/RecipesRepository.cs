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

  internal List<Recipe> GetAllRecipes()
  {
    string sql = @"
    SELECT
    rec.*,
    a.*
    FROM recipes rec
    JOIN accounts a ON a.id = rec.creatorId;";
    List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
    {
      recipe.Creator = profile;
      return recipe;
    }).AsList();
    return recipes;
  }

  internal Recipe getRecipeById(int recipeId)
  {
    string sql = @"
    SELECT
      rec.*,
      a.*
      FROM recipes rec
      JOIN accounts a ON a.id = rec.creatorId
      WHERE rec.id = @recipeId;";
    List<Recipe> recipe = _db.Query<Recipe, Profile, Recipe>(
      sql, 
      (recipe, profile) => {
        recipe.Creator = profile;
        return recipe;
      }, 
      new { recipeId }
    ).AsList();
    return recipe[0];
  }

  internal Recipe EditRecipe(Recipe recipeData)
  {
    string sql = @"
      UPDATE recipes SET title = @Title WHERE id = @Id;
      UPDATE recipes SET instructions = @Instructions WHERE id = @Id;
      UPDATE recipes SET img = @Img WHERE id = @Id;
      UPDATE recipes SET category = @Category WHERE id = @Id;";
    Recipe newRecipe = _db.ExecuteScalar<Recipe>(sql, recipeData);
    return newRecipe;
  }
}
