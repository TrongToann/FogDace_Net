using Application.Data;
using AutoMapper;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Domain.Abstraction.Repositories;
using static Contract.Service.Product.Command;

namespace Application.Features.V1.Command.Product
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProduct>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Result> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Domain.Entities.Product>(request.CreateProductDTO);
            product.Rating = 4;
            product.Sold_Quantity = 0;
            _productRepository.Add(product);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
    }
}
