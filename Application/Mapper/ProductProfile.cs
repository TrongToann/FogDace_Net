using Contract.DTOs.ProductDTO;

namespace Application.Mapper
{
    public class ProductProfile : ServiceProfile
    {
        public ProductProfile()
        {
            //Product
            CreateMap<Domain.Entities.Product, ProductDTO>().ReverseMap();
            CreateMap<Domain.Entities.Product, Contract.Service.Product.Response>().ReverseMap();
            CreateMap<IEnumerable<Domain.Entities.Product>, List<Contract.Service.Product.Response>>().ReverseMap();
            CreateMap<Domain.Entities.Product, CreateProductDTO>().ReverseMap();
        }
    }
}
