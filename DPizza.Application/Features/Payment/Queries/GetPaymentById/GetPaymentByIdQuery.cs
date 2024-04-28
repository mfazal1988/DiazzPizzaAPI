using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;

namespace DPizza.Application.Features.Payment.Queries.GetPaymentById
{
    public class GetPaymentByIdQuery : IRequest<BaseResult<PaymentDto>>
    {
        public long Id { get; set; }
    }
}
