using DPizza.Application.Parameters;
using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.Features.UserDetail.Queries.GetPagedListUserDetail
{
    public class GetPagedListUserDetailQuery : PagenationRequestParameter, IRequest<PagedResponse<UserDetailDto>>
    {
        public string Name { get; set; }
    }
}
