using Microsoft.AspNetCore.Mvc;

// [Authorize]
public class ProductsController : ApiController
{
    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<ProductResponse>> GetById(
        [FromRoute] ProductDetailsQuery query)
        => await Send(query);
}