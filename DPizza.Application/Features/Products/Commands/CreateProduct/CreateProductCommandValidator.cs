using DPizza.Application.Interfaces;
using FluentValidation;

namespace DPizza.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator(ITranslator translator)
        {

            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200)
                .WithName(p => translator["Name"]);

            RuleFor(x => x.ImagePath)
                .MaximumLength(500)
                .WithName(translator["ImagePath"]);
        }
    }
}
