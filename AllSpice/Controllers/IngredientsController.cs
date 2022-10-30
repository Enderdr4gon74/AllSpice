namespace AllSpice.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
  private readonly Auth0Provider _auth0provider;
  private readonly IngredientsService _is;

  public IngredientsController(Auth0Provider auth0Provider, IngredientsService ingredientsService)
  {
    _auth0provider = auth0Provider;
    _is = ingredientsService;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Ingredient>> CreateIngredients([FromBody] Ingredient ingredientData)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      ingredientData.CreatorId = userInfo.Id;
      Ingredient createdIngredient = _is.CreateIngredient(ingredientData);
      createdIngredient.Creator = userInfo;
      return Ok(createdIngredient);
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpDelete("{id}")]
  [Authorize]
  public async Task<ActionResult<Ingredient>> DeleteIngredient(int id)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      _is.DeleteIngredient(id, userInfo.Id);
      return Ok();
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}