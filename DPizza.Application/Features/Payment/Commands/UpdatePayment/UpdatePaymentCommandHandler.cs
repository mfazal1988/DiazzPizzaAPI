using DPizza.Application.Helpers;
using DPizza.Application.Interfaces;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Application.Features.Payment.Commands.UpdatePayment
{
    public class UpdatePaymentCommandHandler(IPaymentRepository productRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<UpdatePaymentCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);

            if (product is null)
            {
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            product.Update(request.Id , request.OrderId, request.UserId, request.PaymentTypeId, request.Amount, request.PaymentStatusId,
                request.PaymentGatewayRequest, request.PaymentGatewayResponse, request.AdditionalInfo, request.TransactionId, request.IsDeleted);

            await unitOfWork.SaveChangesAsync();

            return new BaseResult();
        }
    }
}
