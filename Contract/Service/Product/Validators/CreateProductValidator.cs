using FluentValidation;
using static Contract.Service.Product.Command;

namespace Contract.Service.Product.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProduct>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.CreateProductDTO.Name).NotEmpty();
            RuleFor(x => x.CreateProductDTO.Image).NotEmpty();
            RuleFor(x => x.CreateProductDTO.Description).NotEmpty();
            RuleFor(x => x.CreateProductDTO.Price).NotEmpty();
            RuleFor(x => x.CreateProductDTO.Quantity).NotEmpty();
        }
    }
}
