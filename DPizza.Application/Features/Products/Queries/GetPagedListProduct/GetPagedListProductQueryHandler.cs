using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Application.Features.Products.Queries.GetPagedListProduct
{
    public class GetPagedListProductQueryHandler(IProductRepository productRepository) : IRequestHandler<GetPagedListProductQuery, PagedResponse<ProductDto>>
    {
        public async Task<PagedResponse<ProductDto>> Handle(GetPagedListProductQuery request, CancellationToken cancellationToken)
        {
            var result = await productRepository.GetPagedListAsync(request.PageNumber, request.PageSize, request.Name);

            //PagedResponse<ProductDto> changedResult = new PagedResponse<ProductDto>();

            //foreach (var product in result)
            //{
            //    product.ProductDetails.FirstOrDefault().CrustType = result.ProductDetails.FirstOrDefault().CrustTypeId.ToString();
            //    product.ProductDetails.FirstOrDefault().ProductVariant = result.ProductDetails.FirstOrDefault().ProductVarientId.ToString();

            //    changedResult.add
            //}
            //return new PagedResponse<ProductDto>(result, request);

            var productDtos = result.Data.Select(product =>
            {
                if (product.ProductDetails.Count() > 0) {
                product.ProductDetails.FirstOrDefault().CrustType = product.ProductDetails?.FirstOrDefault()?.CrustTypeId.ToString();
                product.ProductDetails.FirstOrDefault().ProductVariant = product.ProductDetails?.FirstOrDefault()?.ProductVarientId.ToString();
               }
                return product;
            }).ToList();

            result.Data = productDtos;
             
            return new PagedResponse<ProductDto>(result, request);

        }
    }
}
