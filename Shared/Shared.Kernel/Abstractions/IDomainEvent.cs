using MediatR;
using NServiceBus;

namespace Shared.Kernel.Abstractions;

public interface IDomainEvent : INotification, IEvent
{
    
}