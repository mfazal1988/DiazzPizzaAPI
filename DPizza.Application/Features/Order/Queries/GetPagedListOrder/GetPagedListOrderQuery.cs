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
using DPizza.Application.Parameters;

namespace DPizza.Application.Features.Order.Queries.GetPagedListOrder
{
    public class GetPagedListOrderQuery : PagenationRequestParameter, IRequest<PagedResponse<OrderDto>>
    {
        public string OrderNumber { get; set; }
    }
    
}
