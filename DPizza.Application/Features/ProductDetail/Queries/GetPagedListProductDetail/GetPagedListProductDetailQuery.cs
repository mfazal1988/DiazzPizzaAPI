using DPizza.Application.Parameters;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;

namespace DPizza.Application.Features.ProductDetail.Queries.GetPagedListProductDetail
{
    public class GetPagedListProductDetailQuery : PagenationRequestParameter, IRequest<PagedResponse<ProductDetailDto>>
    {
        public string Name { get; set; }
    }
}
