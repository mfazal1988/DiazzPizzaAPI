using DPizza.Application.Features.Products.Queries.GetProductPriceById;
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

namespace DPizza.Application.Features.ProductPrice.Queries.GetProductPriceById
{
    public class GetProductPriceByIdQueryHandler(IProductPriceRepository productRepository, ITranslator translator) : IRequestHandler<GetProductPriceByIdQuery, BaseResult<ProductPriceDto>>
    {
        public async Task<BaseResult<ProductPriceDto>> Handle(GetProductPriceByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetProductByIdAsync(request.Id);

            if (product is null)
            {
                return new BaseResult<ProductPriceDto>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            var result = new ProductPriceDto(product);
            //result.ProductDetails.FirstOrDefault().CrustType = result.ProductDetails.FirstOrDefault().CrustTypeId.ToString();
            //result.ProductDetails.FirstOrDefault().ProductVariant = result.ProductDetails.FirstOrDefault().ProductVarientId.ToString();

            //var result = EnumTranslator.CrustAndVarientTypeString(new ProductDto(product));

            return new BaseResult<ProductPriceDto>(result);
        }
    }
}
