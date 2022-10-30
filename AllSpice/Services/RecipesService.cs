namespace AllSpice.Services;

public class RecipesService 
{
  private readonly RecipesRepository _repo;
  // TODO add Favorite Repo later?

  public RecipesService(RecipesRepository repo)
  {
    _repo = repo;
  }

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    return _repo.CreateRecipe(recipeData);
  }

  internal List<Recipe> GetAllRecipes()
  {
    return _repo.GetAllRecipes();
  }

  internal Recipe getRecipeById(int id)
  {
    return _repo.getRecipeById(id);
  }

  internal Recipe EditRecipe(Recipe recipeData, int recipeId, String userId)
  {
    Recipe recipe = getRecipeById(recipeId);
    if ( userId != recipe.CreatorId )
    {
      throw new Exception("Not Your Recipe!");
    }
    Recipe newRecipe = _repo.EditRecipe(recipeData, recipeId);
    return newRecipe;
  }

  internal void DeleteRecipe(int recipeId, String userId)
  {
    Recipe recipe = getRecipeById(recipeId);
    if ( userId != recipe.CreatorId )
    {
      throw new Exception("Not Your Recipe!");
    }
    _repo.DeleteRecipe(recipeId);
  }
}