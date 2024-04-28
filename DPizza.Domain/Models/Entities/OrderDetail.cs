using DPizza.Domain.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DPizza.Domain.Models.Entities
{
    public class OrderDetail : AuditableBaseEntity
    {
        private OrderDetail()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public OrderDetail(long orderID, long productDetailID, int quantity, decimal price, decimal couponDiscount, 
            decimal creditCardDiscount, decimal otherDiscount, decimal netTotal )
        {
            OrderID = orderID;
            ProductDetailID = productDetailID; 
            Quantity = quantity;
            Price = price;
            CouponDiscount = couponDiscount;
            CreditCardDiscount = creditCardDiscount;
            OtherDiscount = otherDiscount;
            NetTotal = netTotal;
            //Order = order;
            //ProductDetail = productDetail;
        }
        public long OrderID { get;  set; }
        public long ProductDetailID { get;  set; }
        public int Quantity { get;  set; }
        public decimal Price { get;  set; }
        public decimal CouponDiscount { get;  set; }
        public decimal CreditCardDiscount { get;  set; }
        public decimal OtherDiscount { get;  set; }
        public decimal NetTotal { get;  set; }

        //public virtual Order Order { get; set; }
        //public virtual ProductDetail ProductDetail { get; set; } = new ProductDetail();
        //public Product Product { get; set; } = new Product();

        public void Update(long id, long orderID, long productDetailID, int quantity, decimal price, decimal couponDiscount,
            decimal creditCardDiscount, decimal otherDiscount, decimal netTotal, bool isDeleted)
        {
            Id = id;
            OrderID = orderID;
            ProductDetailID = productDetailID;
            Quantity = quantity;
            Price = price;
            CouponDiscount = couponDiscount;
            CreditCardDiscount = creditCardDiscount;
            OtherDiscount = otherDiscount;
            NetTotal = netTotal;
            IsDeleted = isDeleted;
        }
    }
}
