using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Application.Features.ProductPrice.Queries.GetPagedListProductPrice
{
    public class GetPagedListProductPriceQueryHandler(IProductPriceRepository productRepository) : IRequestHandler<GetPagedListProductPriceQuery, PagedResponse<ProductPriceDto>>
    {
        public async Task<PagedResponse<ProductPriceDto>> Handle(GetPagedListProductPriceQuery request, CancellationToken cancellationToken)
        {
            var result = await productRepository.GetPagedListAsync(request.PageNumber, request.PageSize, request.Name);
                         
            return new PagedResponse<ProductPriceDto>(result, request);

        }
    }
}
