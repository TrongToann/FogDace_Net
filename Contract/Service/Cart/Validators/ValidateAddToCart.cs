using FluentValidation;
using static Contract.Service.Cart.Command;

namespace Contract.Service.Cart.Validators
{
    public class ValidateAddToCart : AbstractValidator<AddToCart>
    {
        public ValidateAddToCart() 
        {
            RuleFor(x => x.addToCart.Account_id).NotEmpty();
            RuleFor(x => x.addToCart.InputProductDTO.Product_id).NotEmpty();
            RuleFor(x => x.addToCart.InputProductDTO.Total).NotEmpty();
        }
    }
}
