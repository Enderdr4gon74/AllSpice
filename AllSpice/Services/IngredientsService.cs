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

  internal void DeleteIngredient(int ingredientId, string userId)
  {
    Ingredient ingredient = GetIngredientById(ingredientId);
    if (ingredient.CreatorId != userId) {
      throw new Exception("Not your Ingredient");
    }
    _repo.DeleteIngredient(ingredientId);
  }

  internal void DeleteIngredientWhenRecipeDelete(int ingredientId)
  {
    _repo.DeleteIngredient(ingredientId);
  }
}