using DPizza.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPizza.Domain.Models.Dtos
{
    public class OrderDto
    {
        public OrderDto() { }

        public OrderDto(Order order)
        {
            Id = order.Id;
            UserId = order.UserId;
            OrderNumber = order.OrderNumber;
            OrderTypeId = (Enums.EnumOrderType)order.OrderTypeId;
            OrderRecipientId = order.OrderRecipientId;
            OrderStatusId = (Enums.EnumOrderStatus)order.OrderStatusId;
            AdditionalInstruction = order.AdditionalInstruction;
            AdditionalNotes = order.AdditionalNotes;
            LocationLink = order.LocationLink;
            IsOrderForSelf = order.IsOrderForSelf;
            BranchId = order.BranchId;
            IsDeleted = order.IsDeleted;
            OrderRecipient = order.OrderRecipient;
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public string OrderNumber { get; set; }
        public Enums.EnumOrderType OrderTypeId { get; set; }
        public long OrderRecipientId { get; set; }
        public Enums.EnumOrderStatus OrderStatusId { get; set; }
        public string AdditionalInstruction { get; set; }
        public string AdditionalNotes { get; set; }
        public string LocationLink { get; set; }
        public bool IsOrderForSelf { get; set; }
        public int BranchId { get; set; }
        public bool IsDeleted { get; set; }

        public OrderRecipient OrderRecipient { get; set; }
    }
}