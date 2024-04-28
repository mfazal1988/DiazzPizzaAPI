using DPizza.Application.Features.ProductDetail.Commands.DeleteProductDetail;
using DPizza.Application.Helpers;
using DPizza.Application.Interfaces;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Application.Features.ProductPrice.Commands.DeleteProductPrice
{
    public class DeleteProductDetailCommandHandler(IProductDetailRepository productDetailRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<DeleteProductDetailCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(DeleteProductDetailCommand request, CancellationToken cancellationToken)
        {
            var productDetail = await productDetailRepository.GetByIdAsync(request.Id);

            if (productDetail is null)
            {
                return new BaseResult(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            productDetailRepository.Delete(productDetail);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult();
        }
    }
}
