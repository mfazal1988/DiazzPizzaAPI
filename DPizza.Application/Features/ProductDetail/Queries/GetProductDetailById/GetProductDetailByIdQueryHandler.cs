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

namespace DPizza.Application.Features.ProductDetail.Queries.GetProductDetailById
{
    public class GetProductDetailByIdQueryHandler(IProductDetailRepository productRepository, ITranslator translator) : IRequestHandler<GetProductDetailByIdQuery, BaseResult<ProductDetailDto>>
    {
        public async Task<BaseResult<ProductDetailDto>> Handle(GetProductDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetProductDetailByIdAsync(request.Id);

            if (product is null)
            {
                return new BaseResult<ProductDetailDto>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            var result = new ProductDetailDto(product);
            //result.ProductDetails.FirstOrDefault().CrustType = result.ProductDetails.FirstOrDefault().CrustTypeId.ToString();
            //result.ProductDetails.FirstOrDefault().ProductVariant = result.ProductDetails.FirstOrDefault().ProductVarientId.ToString();

            //var result = EnumTranslator.CrustAndVarientTypeString(new ProductDto(product));

            return new BaseResult<ProductDetailDto>(result);
        }
    }
}
