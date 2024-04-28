
using DPizza.Application.Features.ProductDetail.Commands.CreateProductDetail;
using DPizza.Application.Features.ProductDetail.Commands.DeleteProductDetail;
using DPizza.Application.Features.ProductDetail.Commands.UpdateProductDetail;
using DPizza.Application.Features.ProductDetail.Queries.GetPagedListProductDetail;
using DPizza.Application.Features.ProductDetail.Queries.GetProductDetailByVariety;
using DPizza.Application.Features.ProductDetail.Queries.GetProductDetailtById;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DPizza.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class ProductDetailController : BaseApiController
    {

        [HttpGet]
        public async Task<PagedResponse<ProductDetailDto>> GetPagedListProductDetail([FromQuery] GetPagedListProductDetailQuery model)
            => await Mediator.Send(model);

        [HttpGet]
        public async Task<BaseResult<ProductDetailDto>> GetProductDetailById([FromQuery] GetProductDetailByIdQuery model)
            => await Mediator.Send(model);

        [HttpPost]
        public async Task<BaseResult<long>> CreateProductDetail(CreateProductDetailCommand model)
            => await Mediator.Send(model);

        [HttpPut]
        public async Task<BaseResult> UpdateProductDetail(UpdateProductDetailCommand model)
            => await Mediator.Send(model);

        [HttpDelete]
        public async Task<BaseResult> DeleteProductDetail([FromQuery] DeleteProductDetailCommand model)
            => await Mediator.Send(model);

        [HttpGet]
        public async Task<BaseResult<ProductDetailDto>> GetProductDetailByVariety([FromQuery] GetProductDetailByVarietyQuery model)
            => await Mediator.Send(model);
        
    }
}