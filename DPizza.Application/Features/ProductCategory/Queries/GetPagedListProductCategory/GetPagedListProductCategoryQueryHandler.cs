using DPizza.Application.Features.Products.Queries.GetPagedListProduct;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Application.Features.ProductCategory.Queries.GetPagedListProductCategory
{
    public class GetPagedListProductCategoryQueryHandler(IProductCategoryRepository productCategoryRepository) : IRequestHandler<GetPagedListProductCategoryQuery, PagedResponse<ProductCategoryDto>>
    {
        public async Task<PagedResponse<ProductCategoryDto>> Handle(GetPagedListProductCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await productCategoryRepository.GetPagedListAsync(request.PageNumber, request.PageSize, request.Name);

            return new PagedResponse<ProductCategoryDto>(result, request);
        }
    }
}
