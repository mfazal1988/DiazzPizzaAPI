using DPizza.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPizza.Domain.Models.Dtos
{
    public class PaymentDto
    {
        public PaymentDto() { }

        public PaymentDto(Payment payment) {

            Id = payment.Id;
            OrderId = payment.OrderId;
            UserId = payment.UserId;
            PaymentTypeId = (Enums.EnumPaymentType)payment.PaymentTypeId;
            Amount = payment.Amount;
            PaymentStatusId = (Enums.EnumPaymentStatus)payment.PaymentStatusId;
            PaymentGatewayRequest = payment.PaymentGatewayRequest; 
            PaymentGatewayResponse = payment.PaymentGatewayResponse;
            AdditionalInfo = payment.AdditionalInfo;
            TransactionId = payment.TransactionId;
            IsDeleted = payment.IsDeleted;
            Order = payment.Order;
        }

        public long Id { get;  set; }
        public long OrderId { get;  set; }
        public Guid UserId { get;  set; }
        public Enums.EnumPaymentType PaymentTypeId { get;  set; }
        public decimal Amount { get;  set; }
        public Enums.EnumPaymentStatus PaymentStatusId { get;  set; }
        public string PaymentGatewayRequest { get;  set; }
        public string PaymentGatewayResponse { get;  set; }
        public string AdditionalInfo { get;  set; }
        public string TransactionId { get;  set; }
        public bool IsDeleted { get; set; }
        public Order Order { get; set; }
    }
}
