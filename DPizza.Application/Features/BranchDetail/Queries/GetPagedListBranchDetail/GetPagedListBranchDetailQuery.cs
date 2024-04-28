using DPizza.Application.Parameters;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;

namespace DPizza.Application.Features.BranchDetail.Queries.GetPagedListBranchDetail
{
    public class GetPagedListBranchDetailQuery : PagenationRequestParameter, IRequest<PagedResponse<BranchDetailDto>>
    {
        public string Name { get; set; }
    }
}
