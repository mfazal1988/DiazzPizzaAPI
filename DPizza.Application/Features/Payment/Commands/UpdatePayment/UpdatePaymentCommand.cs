using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace DPizza.Application.Features.Payment.Commands.UpdatePayment
{
    public class UpdatePaymentCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public Guid UserId { get; set; }
        public long PaymentTypeId { get; set; }
        public decimal Amount { get; set; }
        public int PaymentStatusId { get; set; }
        public string PaymentGatewayRequest { get; set; }
        public string PaymentGatewayResponse { get; set; }
        public string AdditionalInfo { get; set; }
        public string TransactionId { get; set; }
        public bool IsDeleted { get; set; }
       
    }
}
