using Domain.Abstraction.Entitites;

namespace Domain.Abstraction
{
    public abstract class EntityAuditBase<T> : EntityBase<T>, IEntityAuditBase<T>
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int Is_published { get; set; } = 0;
        public int Is_draft { get; set; } = 1;
    }
}
