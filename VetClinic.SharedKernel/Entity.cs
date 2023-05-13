using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinic.SharedKernel;

public abstract class Entity<T> : IEquatable<Entity<T>> where T : notnull
{
    public T Id { get; private set; }

    [NotMapped] public IList<DomainEventBase> DomainEvent { get; } = new List<DomainEventBase>();

    protected Entity(T id)
    {
        Id = id;
    }

    protected Entity()
    {
        Id = default(T);
    }

    public static bool operator ==(Entity<T> a, Entity<T> b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(Entity<T> a, Entity<T> b)
    {
        return !(a == b);
    }

    public bool Equals(Entity<T>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return obj is Entity<T> entity && Equals(entity);
    }

    public override int GetHashCode()
    {
        return EqualityComparer<T>.Default.GetHashCode(Id);
    }
}