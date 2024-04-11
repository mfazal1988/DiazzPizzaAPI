using DPizza.Application.DTOs;
using DPizza.Application.DTOs.Account.Requests;
using DPizza.Application.DTOs.Account.Responses;
using DPizza.Application.Interfaces;
using DPizza.Application.Interfaces.UserInterfaces;
using DPizza.Application.Wrappers;
using DPizza.Infrastructure.Identity.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DPizza.Infrastructure.Identity.Services
{
    public class GetUserServices(IdentityContext identityContext) : IGetUserServices
    {
        public async Task<PagedResponse<UserDto>> GetPagedUsers(GetAllUsersRequest model)
        {
            var skip = (model.PageNumber - 1) * model.PageSize;

            var users = await identityContext.Users
                .Skip(skip)
                .Take(model.PageSize)
                .Select(p => new UserDto()
                {
                    Name = p.Name,
                    Email = p.Email,
                    UserName = p.UserName,
                    PhoneNumber = p.PhoneNumber,
                    Id = p.Id,
                    Created = p.Created,
                }).ToListAsync();

            var result = new PagenationResponseDto<UserDto>(users, await identityContext.Users.CountAsync());

            return new PagedResponse<UserDto>(result, model.PageNumber, model.PageSize);
        }
    }
}
