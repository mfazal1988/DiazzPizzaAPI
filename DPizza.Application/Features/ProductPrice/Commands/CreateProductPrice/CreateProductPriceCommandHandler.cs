
using DPizza.Application.Interfaces;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Application.Features.ProductPrice.Commands.CreateProductPrice
{
    public class CreateProductPriceCommandHandler(IProductPriceRepository productDetailRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateProductPriceCommand, BaseResult<long>>
    {
        public async Task<BaseResult<long>> Handle(CreateProductPriceCommand request, CancellationToken cancellationToken)
        {
            var productDetail = new Domain.Models.Entities.ProductPrice(request.ProductDetailId, request.ValidFrom, request.ValidTo, request.Price, request.IsCurrent);

            await productDetailRepository.AddAsync(productDetail);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult<long>(productDetail.Id);
        }
    }
}
