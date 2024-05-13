using Domain.Abstraction.Entitites;

namespace Domain.Abstraction
{
    public abstract class EntityBase<T> : IEntityBase<T>
    {
        public T Id { get; set; }
    }
}
