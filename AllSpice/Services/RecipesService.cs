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

}