using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.Features.Payment.Queries.GetPaymentById
{
    public class GetPaymentByIdQuery : IRequest<BaseResult<PaymentDto>>
    {
        public long Id { get; set; }
    }
}
