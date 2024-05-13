using AutoMapper;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Contract.Service.Product;
using Domain.Abstraction.Repositories;
using Domain.Exceptions.Product;
using static Contract.Service.Product.Query;

namespace Application.Features.V1.Queries.Product
{
    public class FindProductByIdQueryHandler : IQueryHandler<FindProductById, Response>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public FindProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper) =>
            (_productRepository, _mapper) = (productRepository, mapper);
        public async Task<Result<Response>> Handle(FindProductById request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindByIdAsync(request.Product_id);
            if (product is null) throw new ProductNotFound(request.Product_id);
            return _mapper.Map<Response>(product);
        }
    }
}
