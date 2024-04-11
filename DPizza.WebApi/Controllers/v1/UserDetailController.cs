using DPizza.Application.Features.Products.Commands.CreateProduct;
using DPizza.Application.Features.Products.Commands.DeleteProduct;
using DPizza.Application.Features.Products.Commands.UpdateProduct;
using DPizza.Application.Features.Products.Queries.GetPagedListProduct;
using DPizza.Application.Features.Products.Queries.GetProductById;
using DPizza.Application.Features.UserDetail.Commands.CreateUserDetail;
using DPizza.Application.Features.UserDetail.Commands.DeleteUserDetail;
using DPizza.Application.Features.UserDetail.Commands.UpdateUserDetail;
using DPizza.Application.Features.UserDetail.Queries.GetPagedListUserDetail;
using DPizza.Application.Features.UserDetail.Queries.GetUserDetailById;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DPizza.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class UserDetailController : BaseApiController
    {
        [HttpGet]
        public async Task<PagedResponse<UserDetailDto>> GetPagedListUserDetail([FromQuery] GetPagedListUserDetailQuery model)
            => await Mediator.Send(model);

        [HttpGet]
        public async Task<BaseResult<UserDetailDto>> GetUserDetailById([FromQuery] GetUserDetailByIdQuery model)
       => await Mediator.Send(model);

        [HttpPost]
        public async Task<BaseResult<long>> CreateUserDetail(CreateUserDetailCommand model)
        => await Mediator.Send(model);

        [HttpPut]
        public async Task<BaseResult> UpdateUserDetail(UpdateUserDetailCommand model)
            => await Mediator.Send(model);

        [HttpDelete]
        public async Task<BaseResult> DeleteUserDetail([FromQuery] DeleteUserDetailCommand model)
            => await Mediator.Send(model);
    }
}
