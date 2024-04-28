using DPizza.Domain.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace DPizza.Domain.Models.Entities
{
    public class OrderRecipient : AuditableBaseEntity
    {
        private OrderRecipient()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public OrderRecipient(long orderId, string name, string address, string city, string email, string contactNumber)
        {
            OrderId = orderId;
            Name = name;
            Address = address;
            City = city;
            Email = email;
            ContactNumber = contactNumber;
        }
   
        public long OrderId { get;  set; }
        public string Name { get;  set; }
        public string Address { get;  set; }
        public string City { get;  set; }
        public string Email { get;  set; }
        public string ContactNumber { get;  set; }
       
    public void Update(long id, long orderId, string name, string address, string city, string email, string contactNumber, bool isDeleted)
        {
            Id = id;
            OrderId = orderId;
            Name = name;
            Address = address;
            City = city;
            Email = email;
            ContactNumber = contactNumber;
            IsDeleted = isDeleted;
        }
    }
}
