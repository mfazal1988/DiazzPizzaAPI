using DPizza.Application.Features.Order.Queries.GetPagedListOrder;
using DPizza.Application.Helpers;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Interfaces;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DPizza.Application.Features.Products.Queries.GetProductById;

namespace DPizza.Application.Features.Order.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler(IOrderRepository orderRepository, ITranslator translator) : IRequestHandler<GetOrderByIdQuery, BaseResult<OrderDto>>
    {
        public async Task<BaseResult<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await orderRepository.GetProductByIdAsync(request.Id);

            if (order is null)
            {
                return new BaseResult<OrderDto>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.ProductMessages.Product_notfound_with_id(request.Id)), nameof(request.Id)));
            }

            var result = new OrderDto(order);

            return new BaseResult<OrderDto>(result);
        }
    }
}
