using DPizza.Application.Wrappers;
using DPizza.Domain.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPizza.Application.Features.UserDetail.Queries.GetUserDetailById
{
    public class GetUserDetailByIdQuery : IRequest<BaseResult<UserDetailDto>>
    {
        public long Id { get; set; }
    }
}
