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
            decimal creditCardDiscount, decimal otherDiscount, decimal netTotal, Order order, ProductDetail productDetail
)
        {
            OrderID = orderID;
            ProductDetailID = productDetailID; 
            Quantity = quantity;
            Price = price;
            CouponDiscount = couponDiscount;
            CreditCardDiscount = creditCardDiscount;
            OtherDiscount = otherDiscount;
            NetTotal = netTotal;
            Order = order;
            ProductDetail = productDetail;
        }
        public long OrderID { get; private set; }
        public long ProductDetailID { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public decimal CouponDiscount { get; private set; }
        public decimal CreditCardDiscount { get; private set; }
        public decimal OtherDiscount { get; private set; }
        public decimal NetTotal { get; private set; }

        public virtual Order Order { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }

        public void Update(long orderID, long productDetailID, int quantity, decimal price, decimal couponDiscount,
            decimal creditCardDiscount, decimal otherDiscount, decimal netTotal, bool isDeleted)
        {
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
