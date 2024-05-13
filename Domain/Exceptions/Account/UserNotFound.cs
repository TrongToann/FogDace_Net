namespace Domain.Exceptions.Account
{
    public class UserNotFound : NotFoundException
    {
        public UserNotFound(Guid Account_id) :
            base($"Account with username {Account_id} was not found")
        {
        }
    }
}
