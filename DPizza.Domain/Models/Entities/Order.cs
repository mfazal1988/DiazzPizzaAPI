using DPizza.Domain.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace DPizza.Domain.Models.Entities
{
    public class Order : AuditableBaseEntity
    {
        private Order()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Order(long userId, string orderNumber, int orderTypeId,
                        int orderStatusId, string additionalInstruction, string additionalNotes,  string deliveryPerson,
                        string locationLink, bool isOrderForSelf, int branchId,
                         OrderRecipient orderRecipient, List<OrderDetail> orderDetails)
        {
            UserId = userId;  
            OrderNumber = orderNumber;
            OrderTypeId = orderTypeId;
            //OrderRecipientId = orderRecipientId;
            OrderStatusId = orderStatusId;
            AdditionalInstruction = additionalInstruction;
            AdditionalNotes = additionalNotes;
            DeliveryPerson = deliveryPerson;
            LocationLink = locationLink;
            IsOrderForSelf = isOrderForSelf;
            BranchId = branchId;
            OrderRecipient = orderRecipient;
            OrderDetails = orderDetails;
        }

        public long UserId { get;  set; }
        public string OrderNumber { get; set; }
        public int OrderTypeId { get;  set; }
        //public long OrderRecipientId { get; private set; }
        public int OrderStatusId { get;  set; }
        public string AdditionalInstruction { get;  set; }
        public string AdditionalNotes { get;  set; }
        public string DeliveryPerson { get;  set; }
        public string LocationLink { get;  set; }
        public bool IsOrderForSelf { get;  set; }
        public int BranchId { get;  set; }

        //public virtual Payment Payment { get; set; }
        public virtual OrderRecipient OrderRecipient { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } //= new List<OrderDetail>();

        public void Update(long id, long userId,  int orderTypeId,
                        int orderStatusId, string additionalInstruction, string additionalNotes, string deliveryPerson, string locationLink, 
                        bool isOrderForSelf, int branchId, bool isDeleted, OrderRecipient orderRecipient, List<OrderDetail> orderDetails)
        {
            Id = id;
            UserId = userId;     
            OrderTypeId = orderTypeId;
            OrderStatusId = orderStatusId;
            AdditionalInstruction = additionalInstruction;
            AdditionalNotes = additionalNotes;
            DeliveryPerson = deliveryPerson;
            LocationLink = locationLink;
            IsOrderForSelf = isOrderForSelf;
            BranchId = branchId;
            IsDeleted = isDeleted;
            OrderRecipient = orderRecipient;
            OrderDetails = orderDetails;            
        }

        public void UpdateOrderType(long id, int orderTypeId)
        {
            Id = id;           
            OrderTypeId = orderTypeId;            
        }

        public void UpdateOrderStatus(long id, int orderStatusId)
        {
            Id = id;
            OrderStatusId = orderStatusId;
        }

        public void UpdateOrderDeliveryPerson(long id, string deliveryPerson)
        {
            Id = id;
            DeliveryPerson = deliveryPerson;
        }
    }
}
