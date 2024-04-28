using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Application.Features.BranchDetail.Queries.GetPagedListBranchDetail
{
    public class GetPagedListBranchDetailQueryHandler(IBranchDetailRepository productRepository) : IRequestHandler<GetPagedListBranchDetailQuery, PagedResponse<BranchDetailDto>>
    {
        public async Task<PagedResponse<BranchDetailDto>> Handle(GetPagedListBranchDetailQuery request, CancellationToken cancellationToken)
        {
            var result = await productRepository.GetPagedListAsync(request.PageNumber, request.PageSize, request.Name);

            return new PagedResponse<BranchDetailDto>(result, request);

        }
    }
}
