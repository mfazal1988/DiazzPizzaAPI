using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;

namespace DPizza.Application.Features.ProductDetail.Queries.GetProductDetailByVariety
{
    public class GetProductDetailByVarietyQuery : IRequest<BaseResult<ProductDetailDto>>
    {
        public long productId { get; set; }
        public int crustTypeId { get; set; }
        public int productVarientId { get; set; }
    }
}
