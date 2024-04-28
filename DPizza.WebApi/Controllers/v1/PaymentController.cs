using DPizza.Application.Features.Payment.Commands.CreatePayment;
using DPizza.Application.Features.Payment.Commands.DeletePayment;
using DPizza.Application.Features.Payment.Commands.UpdatePayment;
using DPizza.Application.Features.Payment.Queries.GetPagedListPayment;
using DPizza.Application.Features.Payment.Queries.GetPaymentById;

using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DPizza.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class PaymentController : BaseApiController
    {
        [HttpGet]
        public async Task<PagedResponse<PaymentDto>> GetPagedListPayment([FromQuery] GetPagedListPaymentQuery model)
               => await Mediator.Send(model);

        [HttpGet]
        public async Task<BaseResult<PaymentDto>> GetPaymentById([FromQuery] GetPaymentByIdQuery model)
            => await Mediator.Send(model);

        [HttpPost]
        public async Task<BaseResult<long>> CreatePayment(CreatePaymentCommand model)
            => await Mediator.Send(model);

        [HttpPut]
        public async Task<BaseResult> UpdatePayment(UpdatePaymentCommand model)
            => await Mediator.Send(model);

        [HttpDelete]
        public async Task<BaseResult> DeletePayment([FromQuery] DeletePaymentCommand model)
            => await Mediator.Send(model);
    }
}
