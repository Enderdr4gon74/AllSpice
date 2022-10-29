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
  }
}