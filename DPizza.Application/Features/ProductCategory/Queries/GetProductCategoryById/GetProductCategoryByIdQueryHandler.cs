using DPizza.Application.Features.Products.Queries.GetProductById;
using DPizza.Application.Helpers;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Interfaces;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Application.Features.ProductCategory.Queries.GetProductCategoryById
{
    public class GetProductCategoryByIdQueryHandler(IProductCategoryRepository productCategoryRepository, ITranslator translator) : IRequestHandler<GetProductCategoryByIdQuery, BaseResult<ProductCategoryDto>>
    {
            public async Task<BaseResult<ProductCategoryDto>> Handle(GetProductCategoryByIdQuery request, CancellationToken cancellationToken)
            {
                var productCategory = await productCategoryRepository.GetProductByIdAsync(request.Id);

                if (productCategory is null)
                {
                    return new BaseResult<ProductCategoryDto>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
                }

                var result = new ProductCategoryDto(productCategory);

                return new BaseResult<ProductCategoryDto>(result);
            }
     
    }
}
