using DPizza.Application.Helpers;
using DPizza.Application.Interfaces;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Application.Features.Payment.Commands.DeletePayment
{
    public class DeletePaymentCommandHandler(IPaymentRepository productRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<DeletePaymentCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);

            if (product is null)
            {
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            productRepository.Delete(product);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult();
        }
    }
}
