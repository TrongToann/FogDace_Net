using Contract.Abstraction.Message;
using Contract.DTOs.ProductDTO;

namespace Contract.Service.Product
{
    public static class Command
    {
        public record CreateProduct(CreateProductDTO CreateProductDTO) : ICommand { }
    }
}
