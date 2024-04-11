using DPizza.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.Features.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
    }
}
