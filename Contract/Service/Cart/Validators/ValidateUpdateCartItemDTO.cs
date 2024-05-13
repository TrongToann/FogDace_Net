using FluentValidation;
using static Contract.Service.Cart.Command;

namespace Contract.Service.Cart.Validators
{
    public class ValidateUpdateCartItemDTO : AbstractValidator<UpdateCartItem>
    {
        public ValidateUpdateCartItemDTO()
        {
            RuleFor(x => x.Cart_id).NotEmpty();
            RuleFor(x => x.UpdateCartItemDTO.Product_id).NotEmpty();
            RuleFor(x => x.UpdateCartItemDTO.Type).NotEmpty();
            RuleFor(x => x.UpdateCartItemDTO.Quantity).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
