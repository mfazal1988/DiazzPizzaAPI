using DPizza.Application.Helpers;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Interfaces;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DPizza.Application.Features.Products.Queries.GetPagedListProduct;

namespace DPizza.Application.Features.Order.Queries.GetPagedListOrder
{
    public class GetPagedListOrderQueryHandler(IOrderRepository orderRepository) : IRequestHandler<GetPagedListOrderQuery, PagedResponse<OrderDto>>
    {
        public async Task<PagedResponse<OrderDto>> Handle(GetPagedListOrderQuery request, CancellationToken cancellationToken)
        {
            var result = await orderRepository.GetPagedListAsync(request.PageNumber, request.PageSize, request.OrderNumber);

            return new PagedResponse<OrderDto>(result, request);
        }
    }
}
