namespace Domain.Exceptions.Product
{
    public class ProductBadRequest : BadRequestException
    {
        public ProductBadRequest(Guid Product_id) :
            base($"Product with id {Product_id} was not enough!")
        {
        }
    }
}
