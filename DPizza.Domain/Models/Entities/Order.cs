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
                        long orderRecipientId,int orderStatusId, string additionalInstruction, string additionalNotes, 
                        string locationLink, bool isOrderForSelf, int branchId,
                         OrderRecipient orderRecipient, List<OrderDetail> orderDetails)
        {
            UserId = userId;  
            OrderNumber = orderNumber;
            OrderTypeId = orderTypeId;
            OrderRecipientId = orderRecipientId;
            OrderStatusId = orderStatusId;
            AdditionalInstruction = additionalInstruction;
            AdditionalNotes = additionalNotes;
            LocationLink = locationLink;
            IsOrderForSelf = isOrderForSelf;
            BranchId = branchId;
            OrderRecipient = orderRecipient;
            OrderDetails = orderDetails;
        }

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

        //public virtual Payment Payment { get; set; }
        public virtual OrderRecipient OrderRecipient { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public void Update(long Id, long userId,  int orderTypeId, long orderRecipientId, 
                        int orderStatusId, string additionalInstruction, string additionalNotes, string locationLink, 
                        bool isOrderForSelf, int branchId, bool isDeleted, OrderRecipient orderRecipient, List<OrderDetail> orderDetails)
        {
            this.Id = Id;
            UserId = userId;     
            OrderTypeId = orderTypeId;
            OrderRecipientId = orderRecipientId;         
            OrderStatusId = orderStatusId;
            AdditionalInstruction = additionalInstruction;
            AdditionalNotes = additionalNotes;
            LocationLink = locationLink;
            IsOrderForSelf = isOrderForSelf;
            BranchId = branchId;
            IsDeleted = isDeleted;
            OrderRecipient = orderRecipient;
            OrderDetails = orderDetails;            
        }
    }
}
