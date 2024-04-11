using DPizza.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPizza.Domain.Models.Dtos
{
    public class OrderDetailDto
    {
        public OrderDetailDto() { }

        public OrderDetailDto(OrderDetail orderDetail)
        {
            Id = orderDetail.Id;
            OrderID = orderDetail.OrderID;
            ProductDetailID = orderDetail.ProductDetailID;
            Quantity = orderDetail.Quantity;
            Price = orderDetail.Price;
            CouponDiscount = orderDetail.CouponDiscount;
            CreditCardDiscount = orderDetail.CreditCardDiscount;
            OtherDiscount = orderDetail.OtherDiscount;
            NetTotal = orderDetail.NetTotal;
            IsDeleted = orderDetail.IsDeleted;
            Order = orderDetail.Order;
            ProductDetail = orderDetail.ProductDetail;
        }

        public long Id { get; set; }
        public long OrderID { get; set; }
        public long ProductDetailID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal CouponDiscount { get; set; }
        public decimal CreditCardDiscount { get; set; }
        public decimal OtherDiscount { get; set; }
        public decimal NetTotal { get; set; }
        public bool IsDeleted { get; set; }
        public Order Order { get; set; }
        public ProductDetail ProductDetail { get; set; }

    }
}