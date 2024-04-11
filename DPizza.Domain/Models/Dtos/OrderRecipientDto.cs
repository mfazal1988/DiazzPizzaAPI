using DPizza.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPizza.Domain.Models.Dtos
{
    public class OrderRecipientDto
    {
        public OrderRecipientDto() { }

        public OrderRecipientDto(OrderRecipient orderRecipient) {

            Id = orderRecipient.Id;
            OrderId = orderRecipient.OrderId;
            Name = orderRecipient.Name;
            Address = orderRecipient.Address;
            City = orderRecipient.City;
            Email = orderRecipient.Email;
            ContactNumber = orderRecipient.ContactNumber;
            IsDeleted = orderRecipient.IsDeleted;
        }

        public long Id { get; set; }
        public long OrderId { get;  set; }
        public string Name { get;  set; }
        public string Address { get;  set; }
        public string City { get;  set; }
        public string Email { get;  set; }
        public string ContactNumber { get;  set; }
        public bool IsDeleted { get; set; }
    }
}
