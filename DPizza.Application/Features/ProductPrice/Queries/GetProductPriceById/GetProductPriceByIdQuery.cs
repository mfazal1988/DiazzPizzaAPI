using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;

namespace DPizza.Application.Features.Products.Queries.GetProductPriceById
{
    public class GetProductPriceByIdQuery : IRequest<BaseResult<ProductPriceDto>>
    {
        public long Id { get; set; }
    }
}
