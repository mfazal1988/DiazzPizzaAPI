using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Application.Features.Payment.Queries.GetPagedListPayment
{
    public class GetPagedListPaymentQueryHandler(IPaymentRepository productRepository) : IRequestHandler<GetPagedListPaymentQuery, PagedResponse<PaymentDto>>
    {
        public async Task<PagedResponse<PaymentDto>> Handle(GetPagedListPaymentQuery request, CancellationToken cancellationToken)
        {
            var result = await productRepository.GetPagedListAsync(request.PageNumber, request.PageSize, request.Name);
             
            return new PagedResponse<PaymentDto>(result, request);

        }
    }
}
