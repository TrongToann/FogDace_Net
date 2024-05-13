using Contract.Abstraction.Message;

namespace Contract.Service.Pet
{
    public static class Query
    {
        public record FindPetById(Guid Pet_id) : IQuery<Response> { };
        public record GetPublishedPetsByAccount(Guid Account_id) : IQuery<ICollection<Response>> { };
        public record GetDraftPetsByAccount(Guid Account_id) : IQuery<ICollection<Response>> { };
    }
}
