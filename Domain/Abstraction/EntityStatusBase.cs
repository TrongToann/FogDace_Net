using Domain.Abstraction.Entitites;

namespace Domain.Abstraction
{
    public class EntityStatusBase<T> : EntityBase<T>, IStatusTracking
    {
        public int Is_published { get; set; } = 1;
        public int Is_draft { get; set; } = 0;
    }
}