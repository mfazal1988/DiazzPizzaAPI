using DPizza.Application.Features.Order.Commands.CreateOrder;
using DPizza.Application.Features.Order.Commands.DeleteOrder;
using DPizza.Application.Features.Order.Commands.UpdateOrder;
using DPizza.Application.Features.Order.Queries.GetOrderById;
using DPizza.Application.Features.Order.Queries.GetPagedListOrder;
using DPizza.Application.Features.Products.Commands.CreateProduct;
using DPizza.Application.Features.Products.Commands.DeleteProduct;
using DPizza.Application.Features.Products.Commands.UpdateProduct;
using DPizza.Application.Features.Products.Queries.GetPagedListProduct;
using DPizza.Application.Features.Products.Queries.GetProductById;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DPizza.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class OrderController : BaseApiController
    {
        [HttpGet]
        public async Task<PagedResponse<OrderDto>> GetPagedListOrder([FromQuery] GetPagedListOrderQuery model)
                    => await Mediator.Send(model);

        [HttpGet]
        public async Task<BaseResult<OrderDto>> GetOrderById([FromQuery] GetOrderByIdQuery model)
            => await Mediator.Send(model);

        [HttpPost]
        public async Task<BaseResult<long>> CreateOrder(CreateOrderCommand model)
           => await Mediator.Send(model);

        [HttpPut]
        public async Task<BaseResult> UpdateOrder(UpdateOrderCommand model)
            => await Mediator.Send(model);

        [HttpDelete]
        public async Task<BaseResult> DeleteOrder([FromQuery] DeleteOrderCommand model)
            => await Mediator.Send(model);
    }
}
