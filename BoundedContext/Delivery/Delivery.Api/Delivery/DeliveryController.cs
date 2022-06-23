using Delivery.Contract.Command;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using Shared.Kernel.Abstractions;

namespace Delivery.Api.Delivery;

[ApiController]
[Route("delivery")]
public class DeliveryController : ControllerBase
{
    private readonly IMessageSession _messageSession;

    public DeliveryController(IMessageSession messageSession)
    {
        _messageSession = messageSession;
    }

    [HttpPost]
    [Route("complete")]
    public async Task Complete([FromBody] IdRequest request)
    {
        await _messageSession.Send(new CompleteDeliveryCommand()
        {
            DeliveryId = request.Id
        });
    }

    [HttpPost]
    [Route("cancel")]
    public async Task Cancel()
    {
        
    }
}