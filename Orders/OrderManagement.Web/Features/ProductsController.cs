using Microsoft.AspNetCore.Mvc;

// [Authorize]
public class ProductsController : ApiController
{
    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<OrderResponse>> GetById([FromRoute] ProductDetailsQuery query)
        => await Send(query);
    
    [HttpPost]
    public async Task<ActionResult<CreateProductResponse>> Create(CreateOrderCommand command)
        => await Send(command);
    
    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult> Update(UpdateOrderCommand command)
        => await Send(command);
}