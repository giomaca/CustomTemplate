namespace CustomTemplate.Domain.Primitives;

public abstract class Entity(Guid id) : IEquatable<Entity>
{
    public Guid Id { get; private init; } = id;

    public static bool operator ==(Entity? first, Entity? second) => first is not null && second is not null && first.Equals(second);

    public static bool operator !=(Entity? first, Entity? second) => !(first == second);

    public bool Equals(Entity? other)
    {
        if (other is null || other.GetType() != GetType())
            return false;
        return Id == other.Id;
    }

    public override bool Equals(object? obj) => obj is Entity entity && Equals(entity);
    
    public override int GetHashCode() => Id.GetHashCode();
}
