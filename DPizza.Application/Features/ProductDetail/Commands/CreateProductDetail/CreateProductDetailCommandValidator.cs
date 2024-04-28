using DPizza.Application.Interfaces;
using FluentValidation;

namespace DPizza.Application.Features.ProductDetail.Commands.CreateProductDetail
{
    public class CreateProductPriceCommandValidator : AbstractValidator<CreateProductDetailCommand>
    {
        public CreateProductPriceCommandValidator(ITranslator translator)
        {

            //RuleFor(p => p.Name)
            //    .NotNull()
            //    .NotEmpty()
            //    .MaximumLength(200)
            //    .WithName(p => translator["Name"]);

            RuleFor(x => x.ProductId)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.CrustTypeId)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.ProductVarientId)
                .NotNull()
                .NotEmpty();
        }
    }
}
