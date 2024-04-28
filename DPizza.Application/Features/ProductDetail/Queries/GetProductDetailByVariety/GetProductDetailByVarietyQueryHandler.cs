using DPizza.Application.Features.ProductDetail.Queries.GetProductDetailtById;
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

namespace DPizza.Application.Features.ProductDetail.Queries.GetProductDetailByVariety
{
    public class GetProductDetailByVarietyQueryHandler(IProductDetailRepository productRepository, ITranslator translator) : IRequestHandler<GetProductDetailByVarietyQuery, BaseResult<ProductDetailDto>>
    {
        public async Task<BaseResult<ProductDetailDto>> Handle(GetProductDetailByVarietyQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetProductDetailByVarietyAsync(request.productId, request.crustTypeId, request.productVarientId);

            if (product is null)
            {
                return new BaseResult<ProductDetailDto>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.productId)), nameof(request.productId)));
            }

            var result = new ProductDetailDto(product);
           
            return new BaseResult<ProductDetailDto>(result);
        }
    }
}
