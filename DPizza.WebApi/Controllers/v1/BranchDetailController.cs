
using DPizza.Application.Features.BranchDetail.Commands.CreateBranchDetail;
using DPizza.Application.Features.BranchDetail.Commands.DeleteBranchDetail;
using DPizza.Application.Features.BranchDetail.Commands.UpdateBranchDetail;
using DPizza.Application.Features.BranchDetail.Queries.GetBranchDetailById;
using DPizza.Application.Features.BranchDetail.Queries.GetPagedListBranchDetail;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DPizza.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class BranchDetailController : BaseApiController
    {
        [HttpGet]
        public async Task<PagedResponse<BranchDetailDto>> GetPagedListBranchDetail([FromQuery] GetPagedListBranchDetailQuery model)
           => await Mediator.Send(model);

        [HttpGet]
        public async Task<BaseResult<BranchDetailDto>> GetBranchDetailById([FromQuery] GetBranchDetailByIdQuery model)
          => await Mediator.Send(model);

        [HttpPost]
        public async Task<BaseResult<long>> CreateBranchDetail(CreateBranchDetailCommand model)
       => await Mediator.Send(model);

        [HttpPut]
        public async Task<BaseResult> UpdateBranchDetail(UpdateBranchDetailCommand model)
            => await Mediator.Send(model);

        [HttpDelete]
        public async Task<BaseResult> DeleteBranchDetail([FromQuery] DeleteBranchDetailCommand model)
            => await Mediator.Send(model);
    }
}
