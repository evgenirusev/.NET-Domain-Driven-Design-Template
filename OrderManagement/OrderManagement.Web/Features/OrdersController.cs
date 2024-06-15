using Microsoft.AspNetCore.Mvc;

public class OrdersController : ApiController
{
    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<OrderResponse>> GetById([FromRoute] OrderDetailsQuery query)
        => await Send(query);

    [HttpPost]
    public async Task<ActionResult<CreateOrderResponse>> Create(CreateOrderCommand command)
        => await Send(command);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult> Update(UpdateOrderCommand command)
        => await Send(command);
}