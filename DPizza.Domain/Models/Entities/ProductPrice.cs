using DPizza.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DPizza.Domain.Models.Entities
{
    public class ProductPrice : AuditableBaseEntity
    {
        public ProductPrice()
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
        public long ProductDetailId  { get;  set; }
        public string ValidFrom { get;  set; }
        public string ValidTo { get;  set; }
        public decimal Price { get;  set; }
        public bool IsCurrent { get;  set; }


        public void Update(long id, long productDetailId, string validFrom, string validTo, 
            decimal price, bool isCurrent, bool isDeleted)
        {
            Id = id;
            ProductDetailId = productDetailId;
            ValidFrom = validFrom;
            ValidTo = validTo;
            Price = price;
            IsCurrent = isCurrent;
            IsDeleted = isDeleted;
        }
    }
}
