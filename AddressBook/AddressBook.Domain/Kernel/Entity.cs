using System;

namespace AddressBook.Domain.Kernel
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        public TId Id { get; protected set; }

        protected Entity(TId id)
        {
            ThrowIfDefault(id);
            Id = id;
        }

        public bool Equals(Entity<TId> other)
            => !IsNull(other) && object.Equals(this.Id, other.Id);

        public override bool Equals(object obj)
            => this.Equals(obj as Entity<TId>);

        public override int GetHashCode()
            => Id.GetHashCode();

        public static bool operator ==(Entity<TId> x, Entity<TId> y)
            => (IsNull(x) && IsNull(y)) || (!IsNull(x) && x.Equals(y));

        public static bool operator !=(Entity<TId> x, Entity<TId> y)
            => !(x == y);

        private static void ThrowIfDefault(TId id)
        {
            if (object.Equals(id, default(TId)))
                throw new ArgumentException("The ID cannot be the type's default value.", nameof(id));
        }

        private static bool IsNull(Entity<TId> entity)
            => ReferenceEquals(entity, null);
    }
}
