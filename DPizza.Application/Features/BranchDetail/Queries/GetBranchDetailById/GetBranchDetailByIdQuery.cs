using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;

namespace DPizza.Application.Features.BranchDetail.Queries.GetBranchDetailById
{
    public class GetBranchDetailByIdQuery : IRequest<BaseResult<BranchDetailDto>>
    {
        public long Id { get; set; }
    }
}
