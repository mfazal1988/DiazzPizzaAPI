using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;

namespace DPizza.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<BaseResult<ProductDto>>
    {
        public long Id { get; set; }
    }
}
