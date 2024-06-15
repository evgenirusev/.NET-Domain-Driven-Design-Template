using Microsoft.AspNetCore.Mvc;

// [Authorize]
public class OrdersController : ApiController
{
    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<int>> OrdersEndpoint()
        => Ok();
}