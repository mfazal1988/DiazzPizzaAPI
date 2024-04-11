using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.Features.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public int OrderTypeId { get; set; }
        public long OrderRecipientId { get; set; }
        public int OrderStatusId { get; set; }
        public string AdditionalInstruction { get; set; }
        public string AdditionalNotes { get; set; }
        public string LocationLink { get; set; }
        public bool IsOrderForSelf { get; set; }
        public int BranchId { get; set; }
        public bool IsDeleted { get; set; }
        public OrderRecipient OrderRecipient { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
