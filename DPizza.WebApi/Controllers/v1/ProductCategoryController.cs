using DPizza.Application.Features.ProductCategory.Commands.CreateProductCategory;
using DPizza.Application.Features.ProductCategory.Commands.DeleteProductCategory;
using DPizza.Application.Features.ProductCategory.Commands.UpdateProductCategory;
using DPizza.Application.Features.ProductCategory.Queries.GetPagedListProductCategory;
using DPizza.Application.Features.ProductCategory.Queries.GetProductCategoryById;
using DPizza.Application.Features.Products.Commands.CreateProduct;
using DPizza.Application.Features.Products.Commands.DeleteProduct;
using DPizza.Application.Features.Products.Commands.UpdateProduct;
using DPizza.Application.Features.Products.Queries.GetPagedListProduct;
using DPizza.Application.Features.Products.Queries.GetProductById;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DPizza.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class ProductCategoryController : BaseApiController
    {
        [HttpGet]
        public async Task<PagedResponse<ProductCategoryDto>> GetPagedListProductCategory([FromQuery] GetPagedListProductCategoryQuery model)
           => await Mediator.Send(model);

        [HttpGet]
        public async Task<BaseResult<ProductCategoryDto>> GetProductCategoryById([FromQuery] GetProductCategoryByIdQuery model)
          => await Mediator.Send(model);

        [HttpPost]
        public async Task<BaseResult<long>> CreateProductCategory(CreateProductCategoryCommand model)
       => await Mediator.Send(model);

        [HttpPut]
        public async Task<BaseResult> UpdateProductCategory(UpdateProductCategoryCommand model)
            => await Mediator.Send(model);

        [HttpDelete]
        public async Task<BaseResult> DeleteProductCategory([FromQuery] DeleteProductCategoryCommand model)
            => await Mediator.Send(model);
    }
}
