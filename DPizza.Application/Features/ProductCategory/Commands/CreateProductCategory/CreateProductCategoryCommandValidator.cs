using DPizza.Application.Features.Products.Commands.CreateProduct;
using DPizza.Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.Features.ProductCategory.Commands.CreateProductCategory
{
    public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
    {
        public CreateProductCategoryCommandValidator(ITranslator translator)
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200)
                .WithName(p => translator["Name"]);

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithName(translator["Description"]);
        }
    }
}
