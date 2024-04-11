using DPizza.Application.Features.Payment.Queries.GetPaymentById;
using DPizza.Application.Features.Products.Queries.GetProductById;
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
        public async Task<BaseResult<PaymentDto>> GetProductById([FromQuery] GetPaymentByIdQuery model)
          => await Mediator.Send(model);
    }
}
