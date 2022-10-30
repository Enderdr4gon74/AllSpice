namespace AllSpice.Repositories;

public class IngredientsRepository : BaseRepository
{
  public IngredientsRepository(IDbConnection db) : base(db)
  {
  }

  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    string sql = @"
    INSERT INTO ingredients(name, quantity, recipeId, creatorId)
    VALUES(@Name, @Quantity, @RecipeId, @CreatorId);
    SELECT LAST_INSERT_ID();";
    int id = _db.ExecuteScalar<int>(sql, ingredientData);
    ingredientData.Id = id;
    return ingredientData;
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int RecipeId)
  {
    string sql = @"
    SELECT
      i.*,
      a.*
      FROM ingredients i
      JOIN accounts a ON a.id = i.creatorId
      WHERE i.recipeId = @RecipeId;";
    List<Ingredient> ingredients = _db.Query<Ingredient, Profile, Ingredient>(sql, (ingredient, profile) =>
      {
        ingredient.Creator = profile;
        return ingredient;
      }, 
      new { 
        RecipeId 
      }
    ).AsList();
    return ingredients;
  }

  internal Ingredient GetIngredientsById(int ingredientId)
  {
    string sql = "SELECT * FROM ingredients WHERE id = @ingredientId;";
    List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new {ingredientId}).AsList();
    Ingredient ingredient = ingredients[0];
    return ingredient;
  }

  internal void DeleteIngredient(int ingredientId)
  {
    string sql = "DELETE FROM ingredients WHERE id = @ingredientId;";
    int rowsAffected = _db.Execute(sql, new {ingredientId});
    if (rowsAffected == 0) {
      throw new Exception("Unable to delete Ingredient!");
    }
  }
}