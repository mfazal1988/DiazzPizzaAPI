using DPizza.Application.Parameters;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;

namespace DPizza.Application.Features.ProductPrice.Queries.GetPagedListProductPrice
{
    public class GetPagedListProductPriceQuery : PagenationRequestParameter, IRequest<PagedResponse<ProductPriceDto>>
    {
        public string Name { get; set; }
    }
}
