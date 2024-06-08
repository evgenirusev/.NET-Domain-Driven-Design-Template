using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class ProductsController : ApiController
{
    [HttpGet]
    public async Task<ActionResult> Test()
    {
        return Ok();
    }
}