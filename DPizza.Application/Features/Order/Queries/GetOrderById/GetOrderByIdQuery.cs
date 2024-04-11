using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.Features.Order.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<BaseResult<OrderDto>>
    {
        public long Id { get; set; }
    }
}
