using DPizza.Application.Interfaces;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Application.Features.Payment.Commands.CreatePayment
{
    public class CreatePaymentCommandHandler(IPaymentRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreatePaymentCommand, BaseResult<long>>
    {
       
        public async Task<BaseResult<long>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var product = new Domain.Models.Entities.Payment(request.OrderId, request.UserId, request.PaymentTypeId, request.Amount, request.PaymentStatusId, 
                request.PaymentGatewayRequest, request.PaymentGatewayResponse, request.AdditionalInfo, request.TransactionId);

            await productRepository.AddAsync(product);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult<long>(product.Id);
        }
    }
}
