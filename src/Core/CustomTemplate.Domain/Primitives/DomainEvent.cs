
namespace CustomTemplate.Domain.Primitives;

public abstract class DomainEvent : IDomainEvent
{
    protected DomainEvent()
    {
        DomainEventId = Guid.NewGuid();
        OccuredDate = DateTime.Now;
    }

    public Guid DomainEventId { get; private init; }

    public DateTime OccuredDate { get;  private init; }
}
