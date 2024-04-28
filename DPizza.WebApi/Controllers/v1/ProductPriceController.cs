
using DPizza.Application.Features.ProductPrice.Commands.CreateProductPrice;
using DPizza.Application.Features.ProductPrice.Commands.DeleteProductPrice;
using DPizza.Application.Features.ProductPrice.Commands.UpdateProductPrice;
using DPizza.Application.Features.ProductPrice.Queries.GetPagedListProductPrice;
using DPizza.Application.Features.Products.Queries.GetProductPriceById;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DPizza.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class ProductPriceController : BaseApiController
    {

        [HttpGet]
        public async Task<PagedResponse<ProductPriceDto>> GetPagedListProductPrice([FromQuery] GetPagedListProductPriceQuery model)
            => await Mediator.Send(model);

        [HttpGet]
        public async Task<BaseResult<ProductPriceDto>> GetProductPriceById([FromQuery] GetProductPriceByIdQuery model)
            => await Mediator.Send(model);

        [HttpPost]
        public async Task<BaseResult<long>> CreateProductPrice(CreateProductPriceCommand model)
            => await Mediator.Send(model);

        [HttpPut]
        public async Task<BaseResult> UpdateProductPrice(UpdateProductPriceCommand model)
            => await Mediator.Send(model);

        [HttpDelete]
        public async Task<BaseResult> DeleteProductPrice([FromQuery] DeleteProductPriceCommand model)
            => await Mediator.Send(model);

    }
}