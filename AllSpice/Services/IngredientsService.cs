namespace AllSpice.Services;

public class IngredientsService
{
  private readonly IngredientsRepository _repo;

  public IngredientsService(IngredientsRepository repo)
  {
    _repo = repo;
  }

  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    return _repo.CreateIngredient(ingredientData);
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    return _repo.GetIngredientsByRecipeId(recipeId);
  }

  internal Ingredient GetIngredientById(int ingredientId)
  {
    return _repo.GetIngredientsById(ingredientId);
  }

  internal void DeleteIngredient(int recipeId, string userId)
  {
    Ingredient ingredient = GetIngredientById(recipeId);
    if (ingredient.CreatorId != userId) {
      throw new Exception("Not your Ingredient");
    }
    _repo.DeleteIngredient(recipeId);
  }
}