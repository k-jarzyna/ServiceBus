using MediatR;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using Order.Application.PlaceOrder;
using Order.Message;


namespace Order.Api.Order;

[ApiController]
[Route("orders")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMessageSession _messageSession;

    public OrderController(IMediator mediator, IMessageSession messageSession)
    {
        _mediator = mediator;
        _messageSession = messageSession;
    }

    [HttpPost]
    public async Task<Guid> PlaceOrder([FromBody] PlaceOrderRequest placeOrderRequest)
    {
        var orderId = await _mediator.Send(new PlaceOrderCommand()
        {
            Products = placeOrderRequest.Products,
            CustomerId = placeOrderRequest.CustomerId
        });

        return orderId;
    }
    
    [HttpPost]
    [Route("async")]
    public async Task<Guid> PlaceOrderAsync([FromBody] PlaceOrderRequest placeOrderRequest)
    {
        var result = await _messageSession.Request<OrderPlacedResponse>(new Message.PlaceOrderRequest()
        {
            Products = placeOrderRequest.Products,
            CustomerId = placeOrderRequest.CustomerId
        });
        
        return result.OrderId;
    }
}