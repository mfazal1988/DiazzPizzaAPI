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

namespace DPizza.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler(IProductRepository productRepository, ITranslator translator) : IRequestHandler<GetProductByIdQuery, BaseResult<ProductDto>>
    {
        public async Task<BaseResult<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetProductByIdAsync(request.Id);

            if (product is null)
            {
                return new BaseResult<ProductDto>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            var result = new ProductDto(product);
            result.ProductDetails.FirstOrDefault().CrustType = result.ProductDetails.FirstOrDefault().CrustTypeId.ToString();
            result.ProductDetails.FirstOrDefault().ProductVariant = result.ProductDetails.FirstOrDefault().ProductVarientId.ToString();

            //var result = EnumTranslator.CrustAndVarientTypeString(new ProductDto(product));

            return new BaseResult<ProductDto>(result);
        }
    }
}
