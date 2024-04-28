using DPizza.Application.Parameters;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;

namespace DPizza.Application.Features.Payment.Queries.GetPagedListPayment
{
    public class GetPagedListPaymentQuery : PagenationRequestParameter, IRequest<PagedResponse<PaymentDto>>
    {
        public string Name { get; set; }
    }
}
