using DPizza.Application.Features.Products.Commands.CreateProduct;
using DPizza.Application.Interfaces;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Application.Features.ProductDetail.Commands.CreateProductDetail
{
    public class CreateProductPriceCommandHandler(IProductDetailRepository productDetailRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateProductDetailCommand, BaseResult<long>>
    {
        public async Task<BaseResult<long>> Handle(CreateProductDetailCommand request, CancellationToken cancellationToken)
        {
            var productDetail = new Domain.Models.Entities.ProductDetail(request.ProductId, request.CrustTypeId, request.ProductVarientId, request.ProductPrice);

            await productDetailRepository.AddAsync(productDetail);
            await unitOfWork.SaveChangesAsync();

            return new BaseResult<long>(productDetail.Id);
        }
    }
}
