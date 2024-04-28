using DPizza.Application.Interfaces;
using FluentValidation;

namespace DPizza.Application.Features.Payment.Commands.UpdatePayment
{
    public class UpdatePaymentCommandValidator : AbstractValidator<UpdatePaymentCommand>
    {
        public UpdatePaymentCommandValidator(ITranslator translator)
        {
            RuleFor(p => p.OrderId)
                            .NotNull()
                            .NotEmpty()
                            .WithName(p => translator["OrderId"]);

            RuleFor(x => x.UserId)
                 .NotNull()
                .NotEmpty()
                .WithName(translator["UserId"]);
        }
    }

}
