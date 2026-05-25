using Microsoft.AspNetCore.Mvc;

public class OrdersController : ApiController
{
    [HttpGet]
    public async Task<ActionResult<List<OrderListItem>>> GetAll()
        => await Send(new GetAllOrdersQuery());

    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<OrderResponse>> GetById([FromRoute] OrderDetailsQuery query)
        => await Send(query);

    [HttpPost]
    public async Task<ActionResult<CreateOrderResponse>> Create(CreateOrderCommand command)
        => await Send(command);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult> Update([FromRoute] Guid id, UpdateOrderCommand command)
    {
        command.Id = id;
        return await Send(command);
    }
}