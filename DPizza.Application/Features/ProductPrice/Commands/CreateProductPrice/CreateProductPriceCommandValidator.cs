using DPizza.Application.Interfaces;
using FluentValidation;

namespace DPizza.Application.Features.ProductPrice.Commands.CreateProductPrice
{
    public class CreateProductPriceCommandValidator : AbstractValidator<CreateProductPriceCommand>
    {
        public CreateProductPriceCommandValidator(ITranslator translator)
        {

            RuleFor(x => x.ProductDetailId)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.ValidFrom)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.ValidTo)
                .NotNull()
                .NotEmpty();
        }
    }
}
