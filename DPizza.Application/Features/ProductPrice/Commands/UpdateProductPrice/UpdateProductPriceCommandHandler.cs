using DPizza.Application.Helpers;
using DPizza.Application.Interfaces;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Application.Features.ProductPrice.Commands.UpdateProductPrice
{
    public class UpdateProductsPriceCommandHandler(IProductPriceRepository productRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<UpdateProductPriceCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(UpdateProductPriceCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);

            if (product is null)
            {
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            product.Update(request.Id, request.ProductDetailId,request.ValidFrom, request.ValidTo, request.Price,request.IsCurrent, request.IsDeleted);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult();
        }
    }
}
