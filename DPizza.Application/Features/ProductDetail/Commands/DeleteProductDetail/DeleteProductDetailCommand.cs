using DPizza.Application.Wrappers;
using MediatR;

namespace DPizza.Application.Features.ProductDetail.Commands.DeleteProductDetail
{
    public class DeleteProductDetailCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
    }
}
