using AutoMapper;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Contract.Service.Product;
using Domain.Abstraction.Repositories;
using static Contract.Service.Product.Query;

namespace Application.Features.V1.Queries.Product
{
    public class GetProductsQueryHandler : IQueryHandler<GetProducts, ICollection<Response>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<ICollection<Response>>> Handle(GetProducts request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<List<Response>>(products);
        }
    }
}
