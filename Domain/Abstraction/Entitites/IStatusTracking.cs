namespace Domain.Abstraction.Entitites
{
    public interface IStatusTracking
    {
        public int Is_published {  get; set; }
        public int Is_draft { get; set; }
    }
}
