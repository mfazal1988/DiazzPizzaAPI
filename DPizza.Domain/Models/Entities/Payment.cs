using DPizza.Domain.Common;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Transactions;

namespace DPizza.Domain.Models.Entities
{
    public class Payment : AuditableBaseEntity
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Payment()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Payment(long orderId, Guid userId, long paymentTypeId, decimal amount, 
            int paymentStatusId, string paymentGatewayRequest, string paymentGatewayResponse, string additionalInfo, string transactionId
)
        {
            OrderId = orderId;
            UserId = userId;
            PaymentTypeId = paymentTypeId;
            Amount = amount;
            PaymentStatusId = paymentStatusId;
            PaymentGatewayRequest = paymentGatewayRequest;
            PaymentGatewayResponse = paymentGatewayResponse;
            AdditionalInfo = additionalInfo;
            TransactionId = transactionId;

        }
        public long OrderId { get;  set; }
        public Guid UserId { get;  set; }
        public long PaymentTypeId { get;  set; }
        public decimal Amount { get;  set; }
        public int PaymentStatusId { get;  set; }
        public string PaymentGatewayRequest { get;  set; }
        public string PaymentGatewayResponse { get; set; }
        public string AdditionalInfo { get;  set; }
        public string TransactionId { get;  set; }
        //public Order Order { get; set; }


        public void Update(long id, long orderId, Guid userId, long paymentTypeId, decimal amount,
            int paymentStatusId, string paymentGatewayRequest, string paymentGatewayResponse, string additionalInfo,
            string transactionId, bool isDeleted)
        {
            Id = id;
            OrderId = orderId;
            UserId = userId;
            PaymentTypeId = paymentTypeId;
            Amount = amount;
            PaymentStatusId = paymentStatusId;
            PaymentGatewayRequest = paymentGatewayRequest;
            PaymentGatewayResponse = paymentGatewayResponse;
            AdditionalInfo = additionalInfo;
            TransactionId = transactionId;
            IsDeleted = isDeleted;
        }
    }
}
