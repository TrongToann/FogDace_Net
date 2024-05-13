namespace Domain.Abstraction.Entitites
{
    public interface IAuditable : IDateTracking, IUserTracking, IStatusTracking
    {
        
    }
}
