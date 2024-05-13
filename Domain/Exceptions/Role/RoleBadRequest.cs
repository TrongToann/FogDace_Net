namespace Domain.Exceptions.Role
{
    public class RoleBadRequest : BadRequestException
    {
        public RoleBadRequest(string message) : base(message)
        {
        }
    }
}
