using DPizza.Application.Wrappers;
using MediatR;

namespace DPizza.Application.Features.ProductPrice.Commands.DeleteProductPrice
{
    public class DeleteProductPriceCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
    }
}
