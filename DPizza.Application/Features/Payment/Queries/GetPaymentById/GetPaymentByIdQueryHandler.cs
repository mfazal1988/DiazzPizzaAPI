using DPizza.Application.Helpers;
using DPizza.Application.Interfaces;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
 
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Application.Features.Payment.Queries.GetPaymentById
{
    public class GetPaymentByIdQueryHandler(IPaymentRepository productRepository, ITranslator translator) : IRequestHandler<GetPaymentByIdQuery, BaseResult<PaymentDto>>
    {
        public async Task<BaseResult<PaymentDto>> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetPaymentByIdAsync(request.Id);

            if (product is null)
            {
                return new BaseResult<PaymentDto>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            var result = new PaymentDto(product);         

            return new BaseResult<PaymentDto>(result);
        }
    }
}
