using DPizza.Application.Interfaces;
using FluentValidation;

namespace DPizza.Application.Features.ProductPrice.Commands.UpdateProductPrice
{
    public class UpdateProductPriceCommandValidator : AbstractValidator<UpdateProductPriceCommand>
    {
        public UpdateProductPriceCommandValidator(ITranslator translator)
        {

            RuleFor(p => p.ProductDetailId )
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.ValidFrom)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.ValidTo)
               .NotNull()
               .NotEmpty();

            RuleFor(p => p.IsCurrent)
               .NotNull()
               .NotEmpty();
        }
    }

}
