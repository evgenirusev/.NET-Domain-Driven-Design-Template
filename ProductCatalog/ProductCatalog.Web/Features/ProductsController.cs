using Microsoft.AspNetCore.Mvc;

public class ProductsController : ApiController
{
    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<ProductResponse>> GetById([FromRoute] ProductDetailsQuery query)
        => await Send(query);
    
    [HttpPost]
    public async Task<ActionResult<CreateProductResponse>> Create(CreateProductCommand command)
        => await Send(command);
    
    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult> Update(UpdateProductCommand command)
        => await Send(command);
}