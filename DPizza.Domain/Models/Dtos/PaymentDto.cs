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

            Enums.EnumPaymentStatus paymentStatus = (Enums.EnumPaymentStatus)payment.PaymentStatusId;
            PaymentStatus = Enum.GetName(typeof(Enums.EnumPaymentStatus), paymentStatus);

            PaymentGatewayRequest = payment.PaymentGatewayRequest; 
            PaymentGatewayResponse = payment.PaymentGatewayResponse;
            AdditionalInfo = payment.AdditionalInfo;
            TransactionId = payment.TransactionId;
            IsDeleted = payment.IsDeleted;
           // Order = payment.Order;
        }

        public List<PaymentDto> MapList(ICollection<Payment> paymentList)
        {
            PaymentDto paymentDto = new PaymentDto();
            List<PaymentDto> paymentDtoList = new List<PaymentDto>();
            if (paymentList != null)
            {
                foreach (var payment in paymentList)
                {
                    paymentDto = new PaymentDto(payment);
                    paymentDtoList.Add(paymentDto);
                }
            }
            return paymentDtoList;
        }
        public PaymentDto Map(Payment payment)
        {
            return new PaymentDto(payment);
        }

        public long Id { get;  set; }
        public long OrderId { get;  set; }
        public Guid UserId { get;  set; }
        public Enums.EnumPaymentType PaymentTypeId { get;  set; }
        public decimal Amount { get;  set; }
        public Enums.EnumPaymentStatus PaymentStatusId { get;  set; }
        public string PaymentStatus { get;  set; }
        public string PaymentGatewayRequest { get;  set; }
        public string PaymentGatewayResponse { get;  set; }
        public string AdditionalInfo { get;  set; }
        public string TransactionId { get;  set; }
        public bool IsDeleted { get; set; }
       // public Order Order { get; set; }
    }
}
