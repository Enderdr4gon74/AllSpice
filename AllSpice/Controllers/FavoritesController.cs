namespace AllSpice.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{
  private readonly Auth0Provider _auth0provider;
  private readonly FavoritesService _fs;

  public FavoritesController(Auth0Provider auth0Provider, FavoritesService fs)
  {
    _auth0provider = auth0Provider;
    _fs = fs;
  }

  [HttpPost]
  public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite favoriteData)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      favoriteData.AccountId = userInfo.Id;
      Favorite newFavorite = _fs.CreateFavorite(favoriteData);
      return Ok(newFavorite);
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpDelete("{favoriteId}")]
  [Authorize]
  public async Task<ActionResult<Favorite>> DeleteFavorite(int favoriteId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      _fs.DeleteFavorite(favoriteId, userInfo.Id);
      return Ok("Successfully deleted Favorite");
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}