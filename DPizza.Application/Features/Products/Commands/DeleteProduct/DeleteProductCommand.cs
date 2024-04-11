using DPizza.Application.Wrappers;
using MediatR;

namespace DPizza.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
    }
}
