namespace AllSpice.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class RecipesController : ControllerBase
  {
    private readonly Auth0Provider _auth0provider;
    private readonly RecipesService _rs;
    // TODO add ingredients service?

    public RecipesController(Auth0Provider auth0Provider, RecipesService rs)
    {
      _auth0provider = auth0Provider;
      _rs = rs;
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
  }
}