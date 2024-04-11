using DPizza.Domain.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DPizza.Domain.Models.Entities
{
    public class ProductVarient
    {
        private ProductVarient()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ProductVarient(int id, string description, bool isDeleted)
        {
            Id = id;
            Description = description;
            IsDeleted = isDeleted;
        }
        public int Id { get; private set; }
        public string Description { get; private set; }
        public bool IsDeleted { get; private set; }

        public void Update(string description, bool isDeleted)
        {
            Description = description;
            IsDeleted = isDeleted;
        }
    }
}
