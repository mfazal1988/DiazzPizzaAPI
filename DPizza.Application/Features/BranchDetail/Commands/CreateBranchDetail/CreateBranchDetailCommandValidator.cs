using DPizza.Application.Features.BranchDetail.Commands.CreateBranchDetail;
using DPizza.Application.Interfaces;
using FluentValidation;

namespace DPizza.Application.Features.Products.Commands.CreateProduct
{
    public class CreateBranchDetailCommandValidator : AbstractValidator<CreateBranchDetailCommand>
    {
        public CreateBranchDetailCommandValidator(ITranslator translator)
        {

            RuleFor(p => p.Number)
                .NotNull()
                .NotEmpty()            
                .WithName(p => translator["Number"]);

            RuleFor(x => x.Address1)
                          .MaximumLength(200)
                          .WithName(p => translator["Address1"]);

            RuleFor(x => x.Address2)
                            .MaximumLength(200)
                            .WithName(p => translator["Address2"]); 
         
        }
    }
}
