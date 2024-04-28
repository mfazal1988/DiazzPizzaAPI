using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;

namespace DPizza.Application.Features.ProductDetail.Queries.GetProductDetailtById
{
    public class GetProductDetailByIdQuery : IRequest<BaseResult<ProductDetailDto>>
    {
        public long Id { get; set; }
    }
}
