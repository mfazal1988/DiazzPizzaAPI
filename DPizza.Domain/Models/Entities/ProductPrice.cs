using DPizza.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DPizza.Domain.Models.Entities
{
    public class ProductPrice : AuditableBaseEntity
    {
        private ProductPrice()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ProductPrice(long productDetailId  ,string validFrom, string validTo,
            decimal price, bool isCurrent)
        {
            ProductDetailId = productDetailId;
            ValidFrom = validFrom;
            ValidTo = validTo;
            Price = price;
            IsCurrent = isCurrent;
        }
        public long ProductDetailId  { get; private set; }
        public string ValidFrom { get; private set; }
        public string ValidTo { get; private set; }
        public decimal Price { get; private set; }
        public bool IsCurrent { get; private set; }


        public void Update(string validFrom, string validTo, 
            decimal price, bool isCurrent, bool isDeleted)
        {
            ValidFrom = validFrom;
            ValidTo = validTo;
            Price = price;
            IsCurrent = isCurrent;
            IsDeleted = isDeleted;
        }
    }
}
