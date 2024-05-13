using Contract.Abstraction.Message;

namespace Contract.Service.PetHealthProfile
{
    public static class Query
    {
        public record FindPetHealthByPetId(Guid Pet_id) : IQuery<Response> { };
    }
}
