using DPizza.Application.Parameters;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;

namespace DPizza.Application.Features.Products.Queries.GetPagedListProduct
{
    public class GetPagedListProductQuery : PagenationRequestParameter, IRequest<PagedResponse<ProductDto>>
    {
        public string Name { get; set; }
    }
}
