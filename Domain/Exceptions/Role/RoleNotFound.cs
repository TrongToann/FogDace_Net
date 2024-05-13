namespace Domain.Exceptions.Role
{
    public class RoleNotFound : NotFoundException
    {
        public RoleNotFound(Guid Role_id) : 
            base($"Role with id {Role_id} was not found")
        {
        }
        public RoleNotFound() :
            base($"Not Found Any Roles")
        {
        }
    }
}
