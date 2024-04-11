 using DPizza.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DPizza.Domain.Models.Entities
{

    public class ProductDetail : AuditableBaseEntity
    {
        private ProductDetail()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ProductDetail(long productId, int crustTypeId, int productVarientId, ProductPrice productPrice)
        {
            ProductId = productId;
            CrustTypeId = crustTypeId;
            ProductVarientId = productVarientId;
            //ProductPriceId = productPriceId;
            //Product = product;
            ProductPrice = productPrice;
        }

        public long ProductId { get; private set; }
        public int CrustTypeId { get; private set; }
        public int ProductVarientId { get; private set; }
        //public long ProductPriceId { get; private set; }
        //public virtual Product Product { get; set; }
        public virtual ProductPrice ProductPrice { get; set; }

        public void Update(long productId, int crustTypeId, int productVarientId, bool isDeleted)
        {
            ProductId = productId;
            CrustTypeId = crustTypeId;
            ProductVarientId = productVarientId;
            //ProductPriceId = productPriceId;
            IsDeleted = isDeleted; 
        }
    }
}
