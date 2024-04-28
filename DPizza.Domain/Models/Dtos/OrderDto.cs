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
            //OrderRecipientId = order.OrderRecipientId;
            OrderStatusId = (Enums.EnumOrderStatus)order.OrderStatusId;
            AdditionalInstruction = order.AdditionalInstruction;
            AdditionalNotes = order.AdditionalNotes;
            DeliveryPerson = order.DeliveryPerson;
            LocationLink = order.LocationLink;
            IsOrderForSelf = order.IsOrderForSelf;
            BranchId = order.BranchId;
            IsDeleted = order.IsDeleted;
            OrderRecipient = order.OrderRecipient;

            Enums.EnumOrderStatus orderStatus = (Enums.EnumOrderStatus)order.OrderStatusId;
            OrderStatus = Enum.GetName(typeof(Enums.EnumOrderStatus), orderStatus);

            Enums.EnumOrderType orderType = (Enums.EnumOrderType)order.OrderTypeId;
            OrderType = Enum.GetName(typeof(Enums.EnumOrderType), orderType);

            var objList = new OrderDetailDto();
            OrderDetails = objList.MapList(order.OrderDetails ?? new List<OrderDetail>());
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public string OrderNumber { get; set; }
        public Enums.EnumOrderType OrderTypeId { get; set; }
        public string OrderType { get; set; }
        //public long OrderRecipientId { get; set; }
 
        public Enums.EnumOrderStatus OrderStatusId { get; set; }
        public string OrderStatus { get; set; }
        public string AdditionalInstruction { get; set; }
        public string AdditionalNotes { get; set; }
        public string DeliveryPerson { get; set; }
        public string LocationLink { get; set; }
        public bool IsOrderForSelf { get; set; }
        public int BranchId { get; set; }
        public bool IsDeleted { get; set; }
        public OrderRecipient OrderRecipient { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
        public List<PaymentDto> Payments { get; set; }
    }
}