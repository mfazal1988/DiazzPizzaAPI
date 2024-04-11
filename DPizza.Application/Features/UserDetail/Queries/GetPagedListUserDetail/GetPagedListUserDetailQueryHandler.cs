using DPizza.Application.Features.Products.Queries.GetPagedListProduct;
using DPizza.Application.Interfaces.Repositories;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Application.Features.UserDetail.Queries.GetPagedListUserDetail
{
    public class GetPagedListUserDetailQueryHandler(IUserDetailRepository userDetailRepository) : IRequestHandler<GetPagedListUserDetailQuery, PagedResponse<UserDetailDto>>
    {
        public async Task<PagedResponse<UserDetailDto>> Handle(GetPagedListUserDetailQuery request, CancellationToken cancellationToken)
        {
            var result = await userDetailRepository.GetPagedListAsync(request.PageNumber, request.PageSize, request.Name);

            return new PagedResponse<UserDetailDto>(result, request);
        }
    }
}
