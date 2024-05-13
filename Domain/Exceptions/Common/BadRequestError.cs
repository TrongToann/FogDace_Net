namespace Domain.Exceptions.Common
{
    public class BadRequestError : BadRequestException
    {
        public BadRequestError() : base("Bad Request!")
        {
        }
    }
}
