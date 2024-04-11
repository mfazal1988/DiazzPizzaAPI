using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<BaseResult<long>>
    {
        public long UserId { get; private set; }
        public string OrderNumber { get; private set; }
        public int OrderTypeId { get; private set; }
        public long OrderRecipientId { get; private set; }
        public int OrderStatusId { get; private set; }
        public string AdditionalInstruction { get; private set; }
        public string AdditionalNotes { get; private set; }
        public string LocationLink { get; private set; }
        public bool IsOrderForSelf { get; private set; }
        public int BranchId { get; private set; }
        public OrderRecipient OrderRecipient { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
