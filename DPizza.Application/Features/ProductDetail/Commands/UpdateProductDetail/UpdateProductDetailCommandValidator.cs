using DPizza.Application.Interfaces;
using FluentValidation;

namespace DPizza.Application.Features.ProductDetail.Commands.UpdateProductDetail
{
    public class UpdateProductDetailCommandValidator : AbstractValidator<UpdateProductDetailCommand>
    {
        public UpdateProductDetailCommandValidator(ITranslator translator)
        {

            RuleFor(p => p.ProductId)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.CrustTypeId)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.ProductVarientId)
               .NotNull()
               .NotEmpty();
        }
    }

}
