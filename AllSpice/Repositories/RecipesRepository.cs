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

  internal Recipe EditRecipe(Recipe recipeData, int id)
  {
    string sql = "UPDATE recipes SET ";
    if (recipeData.Title != null) {
      sql += "title = @Title";
      if (recipeData.Instructions != null) {
        sql += ", ";
      }
    } if (recipeData.Instructions != null) {
      sql += "instructions = @Instructions";
      if (recipeData.Img != null) {
        sql += ", ";
      }
    } if (recipeData.Img != null) {
      sql += "img = @Img";
      if (recipeData.Category != null) {
        sql += ", ";
      }
    } if (recipeData.Category != null) {
      sql += "category = @Category";
    }
    sql += " WHERE id = @Id;";
    _db.ExecuteScalar<Recipe>(sql, new {
      Title = recipeData.Title,
      Instructions = recipeData.Instructions,
      Img = recipeData.Img,
      Category = recipeData.Category,
      Id = id
    });
    return getRecipeById(id);
  }

  internal void DeleteRecipe(int recipeId)
  {
    string sql = "DELETE FROM recipes WHERE id = @Id;";
    int rowsAffected = _db.Execute(sql, new {Id = recipeId});
    if (rowsAffected == 0) {
      throw new Exception("Unable to delete recipe!");
    }
  }
}
