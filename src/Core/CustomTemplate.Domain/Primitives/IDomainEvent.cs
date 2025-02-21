using MediatR;

namespace CustomTemplate.Domain.Primitives;

public interface IDomainEvent : INotification
{
    Guid DomainEventId { get; }
    DateTime OccuredDate { get; }
}
