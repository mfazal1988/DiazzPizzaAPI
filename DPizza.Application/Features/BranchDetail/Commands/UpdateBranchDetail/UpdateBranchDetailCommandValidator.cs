using DPizza.Application.Features.BranchDetail.Commands.UpdateBranchDetail;
using DPizza.Application.Interfaces;
using FluentValidation;

namespace DPizza.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateBranchDetailCommandValidator : AbstractValidator<UpdateBranchDetailCommand>
    {
        public UpdateBranchDetailCommandValidator(ITranslator translator)
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
