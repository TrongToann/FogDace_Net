namespace Domain.Exceptions.Product
{
    public class ProductNotFound : NotFoundException
    {
        public ProductNotFound(Guid Product_id) :
             base($"Product with id {Product_id} was not found!")
        {
        }
    }
}
