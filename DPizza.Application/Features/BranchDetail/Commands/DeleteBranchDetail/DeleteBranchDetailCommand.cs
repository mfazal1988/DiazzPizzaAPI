using DPizza.Application.Wrappers;
using MediatR;

namespace DPizza.Application.Features.BranchDetail.Commands.DeleteBranchDetail
{
    public class DeleteBranchDetailCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
    }
}
