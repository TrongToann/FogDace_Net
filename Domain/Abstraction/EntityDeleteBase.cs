using Domain.Abstraction.Entitites;

namespace Domain.Abstraction
{
    public abstract class EntityDeleteBase<T> : EntityBase<T>, IDeleteTracking
    {
        public int Is_Deleted { get; set; } = 0;
    }
}
