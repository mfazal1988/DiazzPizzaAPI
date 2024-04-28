using DPizza.Application.Wrappers;
using MediatR;

namespace DPizza.Application.Features.Payment.Commands.DeletePayment
{
    public class DeletePaymentCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
    }
}
