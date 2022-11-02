namespace AllSpice.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class RecipesController : ControllerBase
  {
    private readonly Auth0Provider _auth0provider;
    private readonly RecipesService _rs;
    private readonly IngredientsService _is;
    private readonly FavoritesService _fs;

    public RecipesController(Auth0Provider auth0Provider, RecipesService rs, IngredientsService @is, FavoritesService fs)
    {
      _auth0provider = auth0Provider;
      _rs = rs;
      _is = @is;
      _fs = fs;
    }



    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
    {
      try
      {
        Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
        recipeData.CreatorId = userInfo.Id;
        Recipe createdRecipe = _rs.CreateRecipe(recipeData);
        createdRecipe.Creator = userInfo;
        return Ok(createdRecipe);
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    public ActionResult<List<Recipe>> GetRecipes()
    {
      try
      {
        List<Recipe> recipes = _rs.GetAllRecipes();
        return Ok(recipes);
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Recipe> GetRecipeById(int id)
    {
      try
      {
        Recipe recipe = _rs.getRecipeById(id);
        return Ok(recipe);
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("{recipeId}/ingredients")]
    public ActionResult<List<Recipe>> GetIngredientsByRecipeId(int recipeId)
    {
      try
      {
        List<Ingredient> ingredients = _is.GetIngredientsByRecipeId(recipeId);
        return Ok(ingredients);
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Recipe>> EditRecipe([FromBody] Recipe recipeData, int id)
    {
      try
      {
        Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
        Recipe recipe = _rs.EditRecipe(recipeData, id, userInfo.Id);
        return Ok(recipe);
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Recipe>> DeleteRecipe(int id)
    {
      try
      {
        Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
        List<Favorite> favorites = _fs.getFavoritesByRecipeId(id);
        favorites.ForEach(f => _fs.DeleteFavoriteWhenRecipeDelete(f.Id));
        List<Ingredient> ingredients = _is.GetIngredientsByRecipeId(id);
        ingredients.ForEach(i => _is.DeleteIngredientWhenRecipeDelete(i.Id));
        _rs.DeleteRecipe(id, userInfo.Id);
        return Ok("Recipe Has been deleted!");
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}