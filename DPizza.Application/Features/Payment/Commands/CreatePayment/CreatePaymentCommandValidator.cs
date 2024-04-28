using DPizza.Application.Interfaces;
using FluentValidation;

namespace DPizza.Application.Features.Payment.Commands.CreatePayment
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator(ITranslator translator)
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
