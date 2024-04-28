using DPizza.Domain.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DPizza.Domain.Models.Entities
{
    public class OrderStatus
    {
        private OrderStatus()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public OrderStatus(int id, string description, bool isDeleted)
        {
            Id = id;
            Description = description;
            IsDeleted = isDeleted;
        }
        public int Id { get;  set; }
        public string Description { get;  set; }
        public bool IsDeleted { get;  set; }
      
       
    public void Update(int id, string description, bool isDeleted)
        {
            Id = id;
            Description = description;
            IsDeleted = isDeleted;
        }
    }
}
